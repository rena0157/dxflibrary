// GeoPolyline.cs
// By: Adam Renaud
// Created on: 2019-01-13

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using DxfLibrary.GeoMath;

namespace DxfLibrary.Geometry
{
    /// <summary>
    /// Class that represents a collection of Geolines
    /// </summary>
    public class GeoPolyline : GeoBase, IGeoLength, IGeoArea, IEnumerable<GeoLine>
    {
        #region Private Members

        /// <summary>
        /// Private backing field for lines
        /// </summary>
        private List<GeoLine> _lines;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for the GeoPolyline that takes in Lists of
        /// X, y and z coodinates
        /// </summary>
        /// <param name="X">The X coordinates</param>
        /// <param name="Y">The Y Coordinates</param>
        /// <param name="bulges">The bulge values</param>
        /// <param name="isClosed">True if the polyline is closed</param>
        public GeoPolyline(List<double> x, List<double> y, List<double> bulges, bool isClosed)
        {
            // If the numbers do not match then throw an error
            if (x.Count != y.Count || x.Count != bulges.Count)
                throw new IndexOutOfRangeException("All coordinates must be the same size");
            
            // If there are less than 2 points then the polyline cannot be defined
            if (x.Count < 2)
                throw new ArgumentException("Need more than two points to define a polyline");

            _lines = new List<GeoLine>();

            // Iterate through and create new lines
            for (var index = 0; index < x.Count - 1; ++index)
            {
                var point0 = new GeoPoint(x[index], y[index]);
                var point1 = new GeoPoint(x[index + 1], y[index + 1]);
                var bulge = new Bulge(bulges[index]);

                _lines.Add(new GeoLine(point0, point1, bulge));
            }

            // If the polyline is closed then reconnect the last point
            // to the first point
            if (isClosed)
            {
                var point0 = new GeoPoint(x.Last(), y.Last());
                var point1 = new GeoPoint(x.First(), y.First());
                var bulge = new Bulge(bulges.Last());
                _lines.Add(new GeoLine(point0, point1, bulge));
            }

            // Determine the draw direction using the first and second
            // line by converting them to vectors and crossing them.
            if (_lines.Count > 1)
                DrawDirection = _lines[0].ToVector()
                    .Cross( _lines[1].ToVector() ).Z;
        }

        /// <summary>
        /// Create a GeoPolyline with no Bulges
        /// </summary>
        /// <param name="x">The X Coordinates</param>
        /// <param name="y">The Y Coordinates</param>
        public GeoPolyline(List<double> x, List<double> y, bool isClosed) 
            : this(x, y, new List<double>(Enumerable.Repeat(0.0, x.Count)), isClosed)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Get the total length of all the lines
        /// </summary>
        public double Length => _lines.Select(l => l.Length).Sum();

        /// <summary>
        /// Get the total area of all the lines
        /// </summary>
        public double Area => CalcArea();

        /// <summary>
        /// The Draw direction of the polyline.
        /// If the value is >0 then the draw direction is counterclockwise
        /// If the value is less than 0 then the direction is clockwise
        /// </summary>
        public double DrawDirection {get;}

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Get the enumerator for the lines in the polyline
        /// </summary>
        /// <returns>Returns the Enumberator for the lines in the polyline</returns>
        public IEnumerator<GeoLine> GetEnumerator()
        {
            return _lines.GetEnumerator();
        }

        /// <summary>
        /// Gets the enumerator for the polyline class
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        #endregion

        #region Private Methods

        private double CalcArea()
        {
            double sum = 0.0d;

            // Need to iterate through the lines to caluclate the 
            // Total area
            for (int index = 0; index < _lines.Count; ++index)
            {
                // The current segment
                var segment = _lines[index];

                // If the segment does not have a bulge then
                // Add the area from the object to the sum
                if (!segment.HasBulge)
                {
                    sum += segment.Area;
                    continue;
                }

                // First add the area of the Trapizoid
                sum += new GeoLine(segment.Point0, segment.Point1).Length;

                // This value will determine if we are to add or subtract the segment area
                var segmentAreaSwtich = DrawDirection * segment.Bulge.Value;

                if (segmentAreaSwtich > 0)
                    sum += segment.Area;

                else if (segmentAreaSwtich < 0)
                    sum -= segment.Area;
                
            }

            return sum;
        }



        #endregion
    }
}
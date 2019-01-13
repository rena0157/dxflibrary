// GeoPolyline.cs
// By: Adam Renaud
// Created on: 2019-01-13

using System;
using System.Collections.Generic;
using System.Linq;

namespace DxfLibrary.Geometry
{
    public class GeoPolyline : GeoBase, IGeoLength, IGeoArea
    {
        /// <summary>
        /// Private backing field for lines
        /// </summary>
        private List<GeoLine> _lines;

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
                throw new IndexOutOfRangeException();
            
            _lines = new List<GeoLine>();

            // Iterate through and create new lines
            for (var index = 0; index < x.Count - 1; ++index)
            {
                var point0 = new GeoPoint(x[index], x[index + 1]);
                var point1 = new GeoPoint(y[index], y[index + 1]);
                var bulge = new Bulge(bulges[index]);

                _lines.Add(new GeoLine(point0, point1, bulge));
            }

            // If the polyline is closed then reconnect the last point
            // to the first point
            if (isClosed)
            {
                var point0 = new GeoPoint(x.Last(), x.First());
                var point1 = new GeoPoint(y.Last(), y.First());
                var bulge = new Bulge(bulges.Last());
                _lines.Add(new GeoLine(point0, point1, bulge));
            }
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

        /// <summary>
        /// Get the total length of all the lines
        /// </summary>
        public double Length => _lines.Select(l => l.Length).Sum();

        /// <summary>
        /// Get the total area of all the lines
        /// </summary>
        public double Area => _lines.Select(l => l.Area).Sum();
    }
}
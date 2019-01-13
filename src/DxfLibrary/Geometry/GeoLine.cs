// GeoLine.cs
// Created By: Adam Renaud
// Created on: 2019-01-09

using System;
using System.Collections.Generic;
using System.Linq;

namespace DxfLibrary.Geometry
{
    /// <summary>
    /// Geometric class that defines a segment.
    /// This segment can either be a line or an arc
    /// </summary>
    public class GeoLine : GeoBase, IGeoLength, IGeoArea
    {
        #region Constructors

        /// <summary>
        /// Default Constructor for the Point
        /// </summary>
        public GeoLine()
        {
            Point0 = new GeoPoint(0, 0, 0);
            Point1 = new GeoPoint(0,0,0);
        }

        /// <summary>
        /// Constructor from two points
        /// </summary>
        /// <param name="p0">First Point</param>
        /// <param name="p1">Second Point</param>
        public GeoLine(GeoPoint p0, GeoPoint p1)
        {
            Point0 = p0;
            Point1 = p1;
        }

        public GeoLine(GeoPoint p0, GeoPoint p1, Bulge bulge)
        {
            this.Bulge = bulge;
            Point0 = p0;
            Point1 = p1;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Starting point of the line
        /// </summary>
        public GeoPoint Point0 {get; set;}

        /// <summary>
        /// Ending Point of the line
        /// </summary>
        public GeoPoint Point1 {get; set;}

        /// <summary>
        /// The Bulge of the segment
        /// </summary>
        public Bulge Bulge {get;}

        /// <summary>
        /// Get the length of the Line
        /// </summary>
        public double Length => CalcLength();

        /// <summary>
        /// Area of the Segment
        /// </summary>
        public double Area => CalcArea();

        #endregion

        #region Public Methods

        /// <summary>
        /// Override of the ToString Method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"P0({Point0.X}, {Point0.Y}, {Point0.Z}), P1({Point1.X}, {Point1.Y}, {Point1.Z})";
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Calculate the length of the line
        /// </summary>
        /// <returns>The length of the line</returns>
        private double CalcLength() => Math.Sqrt(Math.Pow(Point1.X - Point0.X, 2.0)
            + Math.Pow(Point1.Y - Point0.Y, 2.0)
            + Math.Pow(Point1.Z - Point0.Z, 2.0));

        private double CalcArea()
        {
            // TODO: Finish this
            return 0;
        }

        #endregion
    }
}
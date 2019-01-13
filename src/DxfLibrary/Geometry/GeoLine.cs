// GeoLine.cs
// Created By: Adam Renaud
// Created on: 2019-01-09

using System;
using System.Collections.Generic;
using System.Linq;

using DxfLibrary.GeoMath;

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

        /// <summary>
        /// Constructor for the geoline that takes two points
        /// and a bulge
        /// </summary>
        /// <param name="p0">Starting point</param>
        /// <param name="p1">Ending point</param>
        /// <param name="bulge">The Bulge</param>
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
        /// Area of the Segment. The Area of the segment
        /// Is the area of a trapizoid that is bounded by the two points of the
        /// line.
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
        private double CalcLength()
        {
            // If the line has no bulge then calculate the straight length
            // between the two points
            if (Bulge.Value == 0) return BasicGeometry.Distance(Point0, Point1);

            // TODO: Need to implement the case where there is a bulge
            else throw new NotImplementedException();
        }

        /// <summary>
        /// Calculate the area of the shape that
        /// bounds the line and the x axis.
        /// Note that the shape can include the area of the chord
        /// if the line is an arc
        /// </summary>
        /// <returns>The area of the shape that is defined above</returns>
        private double CalcArea()
        {
            // If there is no bulge then treat as a regular line
            if (Bulge.Value == 0) return BasicGeometry.TrapzArea(this);

            // TODO: Need to implement the area in the case where there is a bulge
            else throw new NotImplementedException();
        }

        #endregion
    }
}
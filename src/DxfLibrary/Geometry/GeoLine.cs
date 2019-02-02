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
    public class GeoLine : GeoBase, IGeoLength, IGeoArea, IVectorable
    {
        #region Constructors

        /// <summary>
        /// Default Constructor for the Point
        /// </summary>
        public GeoLine() 
            : this(new GeoPoint(0,0), new GeoPoint(0,0), new Bulge(0))
        {
        }

        /// <summary>
        /// Constructor from two points
        /// </summary>
        /// <param name="p0">First Point</param>
        /// <param name="p1">Second Point</param>
        public GeoLine(GeoPoint p0, GeoPoint p1) 
            : this(p0, p1, new Bulge(0))
        {
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
        /// Returns True if the line has a bulge, and false
        /// if the file does not have a bulge
        /// </summary>
        public bool HasBulge => Bulge.Value == 0;

        /// <summary>
        /// The Length of the Line.
        /// </summary>
        /// <remarks>
        /// If the Bulge is 0: The length will return the distance
        /// from point 0 to point 1
        /// 
        /// If the Bulge is not 0: The length will return the arc
        /// length from by an arc from point 0 to point 1 with a 
        /// Bulge of the Bulge.Value
        /// </remarks>
        public double Length => CalcLength();

        /// <summary>
        /// Area of the Segment. The Area of the segment
        /// Is the area of a trapizoid that is bounded by the two points of the
        /// line. Note that if the segment is an arc then the area is the area
        /// bounded by that arc.
        /// </summary>
        public double Area => CalcArea();

        /// <summary>
        /// Radius of the Arc, if the Bulge is not 0.
        /// If the Bulge is 0 this should return positive infinity
        /// </summary>
        public double Radius 
            => Bulge.Value != 0 ? Bulge.Radius(Point0, Point1) : double.PositiveInfinity;

        /// <summary>
        /// The angle that the arc makes.
        /// If the bulge is zero then the angle will return 
        /// positive infinity
        /// </summary>
        /// <remarks>
        /// If there is no arc then the segment is a line and
        /// will then have an angle of PI (180 degrees). This angle will be returned 
        /// in radians.
        /// </remarks>
        public double Angle
            => Bulge.Value != 0 ? Bulge.Angle : Math.PI;

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

        /// <summary>
        /// Convert this entity to a vector
        /// </summary>
        /// <returns>A new vector</returns>
        public Vector ToVector() => new Vector(Point0, Point1);

        #endregion

        #region Private Methods

        /// <summary>
        /// Calculate the length of the Segment.
        /// </summary>
        /// <returns>The length of the line</returns>
        private double CalcLength()
        {
            // If the line has no bulge then calculate the straight length
            // between the two points
            if (Bulge.Value == 0) return BasicGeometry.Distance(Point0, Point1);

            // Return the arc length of the arc if the Bulge is not equal to 0
            return BasicGeometry.ArcLength(Bulge.Radius(Point0, Point1), Bulge.Angle);
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

            // If the bulge value is not equal to 0 then return the 
            // Area of the circle segment
            return BasicGeometry.CircleSegmentArea(Bulge.Radius(Point0, Point1), Bulge.Angle);
        }



        #endregion
    }
}
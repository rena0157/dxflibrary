// BasicGeometry.cs
// By: Adam Renaud
// Created on: 2019-01-13

using System;

using DxfLibrary.Geometry;

namespace DxfLibrary.GeoMath
{
    /// <summary>
    /// A static class that holds general geometric functions
    /// </summary>
    public static class BasicGeometry
    {
        /// <summary>
        /// Calculate the Distance Between two points in space
        /// </summary>
        /// <param name="p0">Starting Point</param>
        /// <param name="p1">Ending Point</param>
        /// <returns>The Distance from Point 0  to Point 1</returns>
        public static double Distance(GeoPoint p0, GeoPoint p1)
            => Math.Sqrt(Math.Pow(p1.X - p0.X, 2.0)
            + Math.Pow(p1.Y - p0.Y, 2.0)
            + Math.Pow(p1.Z - p0.Z, 2.0));

        /// <summary>
        /// Returns the area of a Trapizoid that is formed between 
        /// A line and the x axis
        /// </summary>
        /// <param name="line">The line that bounds the Trapizoid</param>
        /// <returns>The area in the square units of the length</returns>
        public static double TrapzArea(GeoLine line)
            => (line.Point1.X - line.Point0.X) * 0.5 * (line.Point0.Y + line.Point1.Y);

        /// <summary>
        /// Calculate the arc length given a radius and angle
        /// </summary>
        /// <param name="radius">The radius of the arc</param>
        /// <param name="Angle">The angle of the arc</param>
        /// <returns>The total arc length given by the arc</returns>
        public static double ArcLength(double radius, double Angle) => radius * Angle;
    }
}
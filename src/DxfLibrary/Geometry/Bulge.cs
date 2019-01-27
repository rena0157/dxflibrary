// Bulge.cs
// By: Adam Renaud
// Created on: 2019-01-13

using System;

using DxfLibrary.GeoMath;

namespace DxfLibrary.Geometry
{
    /// <summary>
    /// Struct for the Bulge type
    /// </summary>
    public struct Bulge
    {
        /// <summary>
        /// The Default Constructor
        /// </summary>
        /// <param name="bulgeValue">The value of the bulge</param>
        public Bulge(double bulgeValue)
        {
            Value = bulgeValue;
        }

        /// <summary>
        /// Construct a bulge from an angle in radians
        /// </summary>
        /// <param name="Angle">The Angle</param>
        public static Bulge FromAngle(double angle) => new Bulge(Math.Tan(angle / 4));

        /// <summary>
        /// The Value of the Bulge
        /// </summary>
        public double Value {get;}

        /// <summary>
        /// The Angle of the Bulge in radians
        /// </summary>
        public double Angle => 4 * Math.Atan(Value);

        /// <summary>
        /// The Angle of the Bulge in Degrees
        /// </summary>
        public double AngleDeg => Rad2Deg(Angle);

        /// <summary>
        /// Distance from the Chord line to the highest point of the arc,
        /// at the center
        /// </summary>
        /// <param name="p0">Starting point</param>
        /// <param name="p1">Ending point</param>
        /// <returns>The distance from the chord line to the top of the arc</returns>
        public double Sagitta(GeoPoint p0, GeoPoint p1) 
            => Value * BasicGeometry.Distance(p0, p1) * 0.5;

        /// <summary>
        /// The Radius of the arc defined by the bulge
        /// </summary>
        /// <param name="p0">Starting Point</param>
        /// <param name="p1">Ending Point</param>
        /// <returns>The Radius of the Arc</returns>
        public double Radius(GeoPoint p0, GeoPoint p1)
            => BasicGeometry.Distance(p0, p1) * 0.5 * (Math.Pow(Value, 2) + 1) / (2 * Value);

        /// <summary>
        /// Converter for rads to degs
        /// </summary>
        /// <param name="val">Val in radians</param>
        /// <returns>The value in degrees</returns>
        private double Rad2Deg(double val) => val * (180 / Math.PI);
    }
}
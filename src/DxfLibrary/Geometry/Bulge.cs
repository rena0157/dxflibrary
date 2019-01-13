// Bulge.cs
// By: Adam Renaud
// Created on: 2019-01-13

using System;

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
        /// The Value of the Bulge
        /// </summary>
        public double Value {get;}

        /// <summary>
        /// The Angle of the Bulge
        /// </summary>
        public double Angle => Math.Atan(Value / 4);

        /// <summary>
        /// The Angle of the Bulge in Degrees
        /// </summary>
        public double AngleDeg => Rad2Deg(Angle);

        /// <summary>
        /// Converter for rads to degs
        /// </summary>
        /// <param name="val">Val in radians</param>
        /// <returns>The value in degrees</returns>
        private double Rad2Deg(double val) => val * (180 / Math.PI);
    }
}
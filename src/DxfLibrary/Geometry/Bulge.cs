// Bulge.cs
// By: Adam Renaud
// Created on: 2019-01-13

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
            value = bulgeValue;
        }

        /// <summary>
        /// The Value of the Bulge
        /// </summary>
        public double value {get;}
    }
}
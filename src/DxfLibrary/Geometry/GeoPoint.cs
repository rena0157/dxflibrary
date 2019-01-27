// GeoPoint.cs
// Created By: Adam Renaud
// Created On: 2019-01-09

using System;
using DxfLibrary.GeoMath;

namespace DxfLibrary.Geometry
{
    /// <summary>
    /// A point in 3D Space
    /// </summary>
    public class GeoPoint : GeoBase
    {
        #region Constructors
        /// <summary>
        /// Default Constructor for the GeoPoint Class
        /// </summary>
        /// <param name="x">The X coordinate</param>
        /// <param name="y">The y coordinate</param>
        /// <param name="z">The Z coordinate (Default = 0)</param>
        public GeoPoint(double x, double y, double z=0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// X coordinate
        /// </summary>
        public double X {get;}

        /// <summary>
        /// Y Coordinate
        /// </summary>
        public double Y {get;}

        /// <summary>
        /// Z Coordinate
        /// </summary>
        public double Z {get;}

        #endregion

        #region Public Methods

        /// <summary>
        /// Equals override for the point type,
        /// all coordinates must be equal for the point to equal another point.
        /// </summary>
        /// <param name="obj">The object to compare to</param>
        /// <returns>True: objects are equal, False: objects are not equal</returns>
        public override bool Equals(object obj)
        {
            // Cast the object
            var line = obj as GeoPoint;

            // If it cannot be casted then return false
            if (line == null)
                return false;

            // Compare the values
            return BasicGeometry.DoubleCompare(line.X, X) &&
                BasicGeometry.DoubleCompare(line.Y, Y) && 
                BasicGeometry.DoubleCompare(line.Z, Z);
        }

        /// <summary>
        /// Override for the gethashcode method
        /// </summary>
        /// <returns>A hash that is dependant on the public properties of the 
        /// object</returns>
        public override int GetHashCode()
        {
            int hash = 982451653;

            hash = (hash * 817504243) + X.GetHashCode();
            hash = (hash * 817504243) + Y.GetHashCode();
            hash = (hash * 817504243) + Z.GetHashCode();

            return hash;
        }

        /// <summary>
        /// Public override of the ToString method
        /// The ToString method returns a formatted string
        /// with the X, Y and Z coordinates of the point
        /// </summary>
        /// <returns>A Formatted string with the xyz coordinates</returns>
        public override string ToString() => $"X:{X}, Y:{Y}, Z:{Z}";

        #endregion
    }
}
// GeoPoint.cs
// Created By: Adam Renaud
// Created On: 2019-01-09

using System;

namespace DxfLibrary.Geometry
{
    /// <summary>
    /// A point in 3D Space
    /// </summary>
    public class GeoPoint : GeoBase
    {
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
    }
}
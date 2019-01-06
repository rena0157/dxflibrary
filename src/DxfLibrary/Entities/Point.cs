// Point.cs
// Created by: Adam Renaud
// Created on: 2019-01-06

using DxfLibrary.IO;
using DxfLibrary.Parse;
using DxfLibrary.Parse.Sections;

namespace DxfLibrary.Entities
{
    /// <summary>
    /// The Point Entity.
    /// </summary>
    public class Point : Entity, IDxfParsable
    {
        /// <summary>
        /// Default Constructor for the point entity. The Default for
        /// z is zero and is optional.
        /// </summary>
        /// <param name="x">The x coordinate for the point</param>
        /// <param name="y">The y coordinate for the point</param>
        /// <param name="z">The z coordinate for the point</param>
        public Point(double x, double y, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// The x coordinate of the point
        /// </summary>
        public double X {get; private set;}

        /// <summary>
        /// The y coordinate of the point
        /// </summary>
        public double Y {get; private set;}

        /// <summary>
        /// The z coordinate of the point
        /// </summary>
        /// <value></value>
        public double Z {get; private set;}

        /// <summary>
        /// Set property function
        /// </summary>
        /// <param name="name">The name of the property</param>
        /// <param name="value">The value of the property</param>
        public override void SetProperty(string name, object value)
        {

        }
    }
}
// Vector.cs
// By Adam Renaud
// Created on 2019-01-15

using System;

using DxfLibrary.Geometry;

namespace DxfLibrary.GeoMath
{
    /// <summary>
    /// A vector is an entity that as a start and end point
    /// known as the origin and the destination.
    /// </summary>
    public class Vector : IGeoLength
    {   

        #region Constructors

        /// <summary>
        /// Default Constructor for the vector class
        /// </summary>
        /// <param name="origin">The starting point of the vector</param>
        /// <param name="destination">The ending point or destination of the vector.
        /// This is also know as the point of application in some circumstances</param>
        public Vector(GeoPoint origin, GeoPoint destination)
        {
            Origin = origin;
            Destination = destination;
            X = destination.X - origin.X;
            Y = destination.Y - Origin.Y;
            Z = destination.X - origin.Z;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The Starting point of the Vector
        /// </summary>
        public GeoPoint Origin {get;}

        /// <summary>
        /// The ending point of the vector
        /// </summary>
        /// <value></value>
        public GeoPoint Destination {get;}

        /// <summary>
        /// The X Component of the vector
        /// </summary>
        public double X {get; protected set;}

        /// <summary>
        /// The Y Component of the vector
        /// </summary>
        public double Y {get; protected set;}

        /// <summary>
        /// The Z Component of the vector
        /// </summary>
        public double Z {get; protected set;}

        /// <summary>
        /// The Length of the vector. This is also known as
        /// the Magnitude of the vector
        /// </summary>
        /// <returns>The Length of the vector</returns>
        public double Length => BasicGeometry.Distance(Origin, Destination);

        #endregion

        #region Public Methods

        /// <summary>
        /// Rotate counterclockwise about the Z axis angle radians
        /// </summary>
        /// <param name="angle">The Angle to rotate</param>
        public void RotateZ(double angle) 
        {
            X = X * Math.Cos(angle) - Math.Sin(angle);
            Y = X * Math.Sin(angle) + Y * Math.Cos(angle);
        }

        /// <summary>
        /// returns a new vector that is a copy of this vector but translated
        /// to a new origin
        /// </summary>
        /// <param name="origin">The new origin</param>
        public Vector Translate(GeoPoint origin)
        {
            return new Vector(origin,
             new GeoPoint(origin.X + X, origin.Y + Y, origin.Z + Z));
        }

        #endregion

        #region UnitVectors

        /// <summary>
        /// return the unit vector of this vector
        /// </summary>
        /// <returns>A new vector that is a unit vector that is in the same orientation of this vector</returns>
        public Vector UnitVector 
            => new Vector(new GeoPoint(0,0), new GeoPoint(X / Length, Y / Length, Z / Length));

        /// <summary>
        /// X Unit Vector. A vector that as a unit length that is located at the 
        /// Origin and only has an x component of 1
        /// </summary>
        public static Vector UnitVectorX => new Vector(new GeoPoint(0,0), new GeoPoint(1,0));

        /// <summary>
        /// Y Unit Vector. A vector that has a unit length that is located at the Origin and only
        /// has a y component of 1
        /// </summary>
        public static Vector UnitVectorY => new Vector(new GeoPoint(0,0), new GeoPoint(0,1));

        /// <summary>
        /// Z Unit Vector. A vector that has a unit length of 1 that is located at the origin and
        /// the magnitude is 1.
        /// </summary>
        public static Vector UnitVectorZ => new Vector(new GeoPoint(0,0), new GeoPoint(0,0,1));

        #endregion
    }
}
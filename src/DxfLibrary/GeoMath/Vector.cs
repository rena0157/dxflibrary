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
            // Set origin and destination
            Origin = origin;
            Destination = destination;
        }

        /// <summary>
        /// Constructor that creates a vector with its tail at the origin
        /// and the destination given by a <see cref="GeoPoint">.
        /// </summary>
        /// <param name="destination">The GeoPoint for the destination</param>
        public Vector(GeoPoint destination) : this(new GeoPoint(0,0), destination)
        {

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
        public GeoPoint Destination {get; protected set;}

        /// <summary>
        /// The X Component of the vector
        /// </summary>
        public double X => Destination.X - Origin.X;

        /// <summary>
        /// The Y Component of the vector
        /// </summary>
        public double Y => Destination.Y - Origin.Y;

        /// <summary>
        /// The Z Component of the vector
        /// </summary>
        public double Z => Destination.Z - Origin.Z;

        /// <summary>
        /// The Length of the vector. This is also known as
        /// the Magnitude of the vector
        /// </summary>
        /// <returns>The Length of the vector</returns>
        public double Length => BasicGeometry.Distance(Origin, Destination);

        #endregion

        #region Public Methods

        /// <summary>
        /// Rotate counterclockwise about the Z axis angle radians.
        /// This rotation will occur at the origin.
        /// </summary>
        /// <param name="angle">The Angle to rotate in radians</param>
        public void RotateZ(double angle) 
        {
            // Rotate the vector componets
            Destination = new GeoPoint(Destination.X * Math.Cos(angle) - Destination.Y*Math.Sin(angle),
                Destination.X*Math.Sin(angle) + Destination.Y*Math.Cos(angle), Destination.Z);
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

        /// <summary>
        /// Dot product of the vector and another vector
        /// </summary>
        /// <param name="other">The other vector to dot with</param>
        /// <returns>Returns: The result of the dot product</returns>
        public double Dot(Vector other) => X * other.X + Y * other.Y + Z * other.Z;

        /// <summary>
        /// The Cross Product of this vector and another vector.
        /// Note that this returns a new vector where this origin is the same
        /// as this vector.
        /// </summary>
        /// <param name="v2">The other vector that is being crossed</param>
        /// <returns>Returns: A new vector</returns>
        public Vector Cross(Vector v2) => new Vector(Origin, 
            new GeoPoint(Origin.X + Y*v2.Z - v2.Y*Z,
            Origin.Y + v2.X*Z - X*v2.Z,
            Origin.Z + (X*v2.Y - v2.X*Y)));

        #endregion

        #region Overrides

        /// <summary>
        /// Overloaded operator + for the vector type
        /// </summary>
        /// <param name="a">The first vector</param>
        /// <param name="b">The second vector</param>
        /// <returns>Returns a new vector which is the addition of the two vectors</returns>
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(new GeoPoint(a.Origin.X + b.Origin.X, a.Origin.Y + b.Origin.Y, a.Origin.Z + b.Origin.Z),
                new GeoPoint(a.Destination.X + b.Destination.X,
                a.Destination.Y + b.Destination.Y, a.Destination.Z + b.Destination.Z));
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
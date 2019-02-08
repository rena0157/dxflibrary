// Hatch.cs
// By: Adam Renaud
// Created on: 2019-02-03

using System;
using DxfLibrary.Geometry;

namespace DxfLibrary.Entities
{
    /// <summary>
    /// Hatch class. Hatches are space filling entities that
    /// have many properties that include color, area and patterns.
    /// </summary>
    public class Hatch : Entity, IGeoArea
    {
        #region Private Properties

        #endregion

        #region Constructors

        /// <summary>
        /// Internal Constructor for the Hatch Entity
        /// </summary>
        /// <param name="structure">The Hatch Structure</param>
        internal Hatch(HatchStructure structure) : base(structure)
        {
            ElevationPoint = new GeoPoint(structure.ElevationX, structure.ElevationY, structure.ElevationZ);
            PatternName = structure.PatternName;
            HasSolidFill = structure.SolidFillFlag;
            IsAssociative = structure.AssociativityFlag;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The Elevation Point for the hatch
        /// </summary>
        public GeoPoint ElevationPoint {get;}

        /// <summary>
        /// The Pattern Name of the Hatch
        /// </summary>
        public string PatternName {get;}

        /// <summary>
        /// Returns true if the hatch has solid fill
        /// </summary>
        public bool HasSolidFill {get;}

        /// <summary>
        /// Returns true if the Hatch is associated with
        /// another object that defines it's geometry
        /// </summary>
        public bool IsAssociative {get;}

        /// <summary>
        /// Area of the Hatch
        /// </summary>
        /// <returns>Returns: The total area of the hatch</returns>
        public double Area => ((IGeoArea)_geometricBase).Area;

        #endregion
    }

    /// <summary>
    /// Internal Entity Structure for Hatches
    /// </summary>
    internal class HatchStructure : EntityStruct
    {
        #region Basic Properties

        /// <summary>
        /// X coordinate of the Elevation Point
        /// </summary>
        public double ElevationX {get;set;}

        /// <summary>
        /// Y Coordinate of the Elevation Point
        /// </summary>
        public double ElevationY {get;set;}

        /// <summary>
        /// Z Coordinate of the Elevation Point
        /// </summary>
        public double ElevationZ {get;set;}

        /// <summary>
        /// The Pattern Name of the Hatch
        /// </summary>
        public string PatternName {get; set;}

        /// <summary>
        /// Flag for solid Fill
        /// </summary>
        public bool SolidFillFlag {get; set;}

        /// <summary>
        /// The Flag for associativity
        /// </summary>
        public bool AssociativityFlag {get; set;}

        /// <summary>
        /// Override for the set property function. This is used
        /// for non-trival cases for this entity
        /// </summary>
        /// <param name="name">The name of the property</param>
        /// <param name="value">The value of the property</param>
        public override void SetProperty(string name, object value)
        {
            // Switch for non-trivial properties that
            // require more than just a simple conversion
            switch(name)
            {
                // no implicit way to convert an int to a bool
                case nameof(SolidFillFlag):
                    SolidFillFlag = (int)Convert.ChangeType(value, typeof(int)) != 0;
                break;

                // no implicity way to convert an int to a bool
                case nameof(AssociativityFlag):
                    AssociativityFlag = (int)Convert.ChangeType(value, typeof(int)) != 0;
                break;

                // Default is to use the base set property function
                default:
                    base.SetProperty(name, value);
                return;
            }
        }

        #endregion
        
    }
}
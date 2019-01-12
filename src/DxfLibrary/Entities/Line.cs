// Line.cs
// Created By: Adam Renaud
// Created on: 2019-01-07

using System;
using System.Collections.Generic;

using DxfLibrary.Geometry;

namespace DxfLibrary.Entities
{
    /// <summary>
    /// The LINE entity
    /// </summary>
    public class Line : Entity, IGeoLength
    {

        #region Constructors

        /// <summary>
        /// Internal Structure Constructor
        /// </summary>
        /// <param name="structure">The Structure</param>
        internal Line(LineStructure structure) : base(structure)
        {
            // Create the geometric base
            _geometricBase = new GeoLine(new GeoPoint(structure.X1, structure.Y1),
                new GeoPoint(structure.X2, structure.Y2));
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Line()
        {

        }
        #endregion

        #region Public Members

        /// <summary>
        /// The Starting Point
        /// </summary>
        public GeoPoint StartPoint => ((GeoLine)_geometricBase).Point0;

        /// <summary>
        /// The End Point
        /// </summary>
        public GeoPoint EndPoint => ((GeoLine)_geometricBase).Point1;

        /// <summary>
        /// The length of the line as defined in the geometric base
        /// </summary>
        public double Length => ((GeoLine)_geometricBase).Length;


        #endregion
    }

    /// <summary>
    /// Internal Class used to construct the Line Entity
    /// </summary>
    internal class LineStructure : Entity
    {
        public double X1 {get; set;}

        public double Y1 {get; set;}

        public double X2 {get; set;}

        public double Y2 {get; set;}

        /// <summary>
        /// The Set Property Function
        /// </summary>
        /// <param name="name">The name of the property</param>
        /// <param name="value">The value of the property</param>
        public override void SetProperty(string name, object value)
        {
            // Get the property
            var property = this.GetType().GetProperty(name);

            // Get the type of the property
            var type = property.PropertyType;

            // Converty the object to the type of the property
            var settingValue = Convert.ChangeType(value, type);

            // Set the property
            this.GetType().GetProperty(name).SetValue(this, settingValue);
        }

    }
}
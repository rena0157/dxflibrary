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
    internal class LineStructure : EntityStruct
    {
        /// <summary>
        /// First X Coordinate
        /// </summary>
        public double X1 {get; set;}

        /// <summary>
        /// First Y Coordinate
        /// </summary>
        public double Y1 {get; set;}

        /// <summary>
        /// Second X Coordinate
        /// </summary>
        /// <value></value>
        public double X2 {get; set;}

        /// <summary>
        /// Second Y Coordinate
        /// </summary>
        /// <value></value>
        public double Y2 {get; set;}

    }
}
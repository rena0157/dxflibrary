// LwPolyline.cs
// Created by: Adam Renaud
// Created on: 2019-01-13

using System;
using System.Collections.Generic;
using System.Linq;

using DxfLibrary.Geometry;

namespace DxfLibrary.Entities
{
    /// <summary>
    /// Class representing the LwPolyline Entity
    /// </summary>
    public class LwPolyline : Entity, IGeoLength, IGeoArea
    {
        
        #region Constructors

        /// <summary>
        /// Internal Constructer used in the parsing of the
        /// LWPOlyline
        /// </summary>
        /// <param name="structure">The Structure</param>
        internal LwPolyline(LwPolylineStructure structure) : base(structure)
        {

        }

        /// <summary>
        /// Default Constructor for the LwPolyline
        /// </summary>
        public LwPolyline()
        {

        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The Total Length of the LwPolyline
        /// </summary>
        public double Length => throw new NotImplementedException();

        /// <summary>
        /// The Total Area of the LwPolyline
        /// </summary>
        public double Area => throw new NotImplementedException();

        /// <summary>
        /// The number of vertices in the Polyline
        /// </summary>
        public int NumberOfVerticies {get; set;}

        /// <summary>
        /// The Polyline Flag, 1 = Closed, 0 = Open
        /// </summary>
        public bool PolylineFlag {get; set;}

        /// <summary>
        /// Constant with of the polyline
        /// </summary>
        public double ConstWidth {get; set;}

        /// <summary>
        /// The Elevation of the polyline
        /// </summary>
        public double Elevation {get; set;}

        /// <summary>
        /// Thickness of the Polyline
        /// </summary>
        /// <value></value>
        public double Thickness {get; set;}

        /// <summary>
        /// Starting width
        /// </summary>
        public double StartWidth {get; set;}

        /// <summary>
        /// Ending Width
        /// </summary>
        public double EndWidth {get; set;}

        #endregion

    }
    
    /// <summary>
    /// Internal Structure for the LwPolyline
    /// </summary>
    internal class LwPolylineStructure : Entity
    {
        /// <summary>
        /// The number of vertices in the Polyline
        /// </summary>
        public int NumberOfVerticies {get; set;}

        /// <summary>
        /// The Polyline Flag, 1 = Closed, 0 = Open
        /// </summary>
        public bool PolylineFlag {get; set;}

        /// <summary>
        /// Constant with of the polyline
        /// </summary>
        public double ConstWidth {get; set;}

        /// <summary>
        /// The Elevation of the polyline
        /// </summary>
        public double Elevation {get; set;}

        /// <summary>
        /// Thickness of the Polyline
        /// </summary>
        /// <value></value>
        public double Thickness {get; set;}

        /// <summary>
        /// X Coordinates of the Polyline
        /// </summary>
        public List<double> XCoordinate {get; set;} = new List<double>();

        /// <summary>
        /// Y Coordinates of the polyline
        /// </summary>
        public List<double> YCoordinate {get; set;} = new List<double>();

        /// <summary>
        /// Bulges of the polyline
        /// </summary>
        public List<double> Bulge {get; set;} = new List<double>();

        /// <summary>
        /// Vertex ID
        /// </summary>
        public List<int> VertexId {get; set;} = new List<int>();

        /// <summary>
        /// Starting width
        /// </summary>
        public double StartWidth {get; set;}

        /// <summary>
        /// Ending Width
        /// </summary>
        public double EndWidth {get; set;}

        /// <summary>
        /// Override for the LwPolyline structure to deal with lists
        /// </summary>
        /// <param name="name">The name of the property</param>
        /// <param name="value">The value of the property</param>
        public override void SetProperty(string name, object value)
        {
            // Switch statement for members that are not simply 
            // Assignments and need other logic
            switch(name)
            {
                case nameof(XCoordinate):
                    XCoordinate.Add(double.Parse(value as string));

                    // Make sure that the number of bulges is the same as
                    // the number of points
                    Bulge.Add(0);
                return;

                case nameof(YCoordinate):
                    YCoordinate.Add(double.Parse(value as string));
                return;

                case nameof(Bulge):
                    Bulge.RemoveAt(Bulge.Count - 1);
                    Bulge.Add(double.Parse(value as string));
                return;

                default:
                    base.SetProperty(name, value);
                return;
            }
        }
    }
}
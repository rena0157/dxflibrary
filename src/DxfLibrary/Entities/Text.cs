// Text.cs
// By: Adam Renaud
// Created: 2019-05-05

using System;
using DxfLibrary.Geometry;

namespace DxfLibrary.Entities
{
    public class Text : Entity
    {
        #region Constructors

        // Initialize the members of this class

        internal Text(TextStructure textStruc) : base(textStruc)
        {
            FirstAlignmentPoint 
                = new GeoPoint(textStruc.XCoordinate1, textStruc.YCoordinate1, textStruc.ZCoordinate1);

            SecondAlignmentPoint
                = new GeoPoint(textStruc.XCoordinate2, textStruc.YCoordinate2, textStruc.ZCoordinate2);

            TextHeight = textStruc.Height;

        }


        #endregion

        #region Public Properties

        /// <summary>
        /// The First Alignment point for the text
        /// </summary>
        public GeoPoint FirstAlignmentPoint { get; set; }
        
        /// <summary>
        /// The second (Optional) Alignment point for the text
        /// </summary>
        public GeoPoint SecondAlignmentPoint { get; set; }

        /// <summary>
        /// The height of the text
        /// </summary>
        public double TextHeight {get; set;}

        /// <summary>
        /// The Horizontal Alignment for the text
        /// </summary>
        public TextHorizontalAlignment HorizontalAlignment {get;}



        #endregion
    }

    /// <summary>
    /// Horizontal text justification (optional, default is left)
    /// </summary>
    public enum TextHorizontalAlignment
    {
        Left,

        Center,

        Right,

        Aligned,

        Middle,

        Fit
    }

    public enum TextVerticalAlignment
    {
        Baseline,

        Bottom,

        Middle,

        Top
    }

    /// <summary>
    /// Internal Class for the text entity, used for interop between files
    /// </summary>
    internal class TextStructure : EntityStruct
    {
        #region Trivial Properties

        public double XCoordinate1 { get; set; }

        public double YCoordinate1 { get; set; }

        public double ZCoordinate1 { get; set; }

        public double XCoordinate2 { get; set; }

        public double YCoordinate2 { get; set; }

        public double ZCoordinate2 { get; set; }

        public double Height { get; set; }

        public string Value { get; set; }

        public double TextRotation { get; set; }

        public double XScale { get; set; }

        public double ObliqueAngle { get; set; }

        public string TextStyle { get; set; }

        public int TextGenerationFlag { get; set; }

        public int HorizontalJustification { get; set; }

        public double ExtrusionX { get; set; }

        public double ExtrusionY { get; set; }

        public double ExtrusionZ { get; set; }

        public int VerticalJustification { get; set; }


        #endregion
    }
}
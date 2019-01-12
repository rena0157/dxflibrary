// SectionsContainer.cs
// By: AdamRenaud
// Created: 2019-01-01

// System Using Statements
using System;

// Internal Using Statements
using DxfLibrary.Parse.Sections;

namespace DxfLibrary.Parse
{
    /// <summary>
    /// Container for all of the sections in the DxfFile
    /// </summary>
    public class SectionsContainer
    {
        /// <summary>
        /// The Header Section
        /// </summary>
        public HeaderSection Header {get; set;}

        /// <summary>
        /// The Entity Section
        /// </summary>
        public EntitiesSection Entities {get; set;}
    }
}
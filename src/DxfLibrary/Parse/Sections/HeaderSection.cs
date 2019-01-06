// HeaderSection.cs
// Created by: Adam Renaud
// Created on: 2018-01-05

// System Using Statements
using System.Collections.Generic;
using System.Linq;
// Internal Using Statements

namespace DxfLibrary.Parse.Sections
{
    /// <summary>
    /// Class that contains all of the properties for the header of the
    /// Dxf file
    /// </summary>
    public class HeaderSection : IDxfParsable
    {

        /// <summary>
        /// The Version of the File, AutoCAD Version
        /// </summary>
        public string FileVersion {get; set;}

        /// <summary>
        /// Who the file was last saved by
        /// </summary>
        public string LastSavedBy {get; set;}

        /// <summary>
        /// Set a property in the class from the name of 
        /// the property
        /// </summary>
        /// <param name="name">The name of the the property</param>
        /// <param name="value">The value of the property</param>
        public void SetProperty(string name, object value)
        {
            switch(name)
            {
                case nameof(FileVersion):
                    FileVersion = value as string;
                    break;
                
                case nameof(LastSavedBy):
                    LastSavedBy = value as string;
                    break;

                // If nothing matches then break and return
                default:
                    break;
            }                
        }
    }

    /// <summary>
    /// Enumeration of the different AutoCAD Versions
    /// </summary>
    public enum AutoCADVersion
    {
        AC1006,
        AC1009,
        AC1032
    }
}
// DxfFile.cs
// By: Adam Renaud
// Created: 2019-01-01

// System Using Statements
using System;
using System.IO;

// Internal Using Statements
using DxfLibrary.IO;
using DxfLibrary.Parse;

namespace DxfLibrary
{
    /// <summary>
    /// The main interface class for the dxf file. This is the class that controls the
    /// reading, parsing, and displaying of information from the dxf file.
    /// </summary>
    public class DxfFile
    {
        #region Private Members

        private SectionsContainer _container;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor that assumes that the file is not binary
        /// </summary>
        /// <param name="fileStream">The filestream that points to the file</param>
        public DxfFile(FileStream fileStream)
        {
            // Load the file
            LoadFile(fileStream, false);
        }

        public DxfFile(FileStream fileStream, bool isBinary)
        {
            // Load the file
            LoadFile(fileStream, isBinary);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Load the file and populate this dxf file
        /// </summary>
        /// <param name="fileStream">The filestream where the file is</param>
        /// <param name="isBinary">If true then read the file as if it is binary</param>
        private void LoadFile(FileStream fileStream, bool isBinary)
        {
            if (!isBinary)
            {
                using (var reader = new DxfAsciiReader(fileStream))
                {
                    var parser = new DxfAsciiParser<SectionsContainer>();
                    _container = parser.Parse(reader);
                }
            }
        }

        #endregion
    }
}
// DxfFile.cs
// By: Adam Renaud
// Created: 2019-01-01

// System Using Statements
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

// Internal Using Statements
using DxfLibrary.IO;
using DxfLibrary.Parse;
using DxfLibrary.Entities;

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
        /// <param name="fileStream">The file-stream that points to the file</param>
        public DxfFile(Stream fileStream)
        {
            // Load the file
            LoadFile(fileStream, false);
        }

        /// <summary>
        /// Constructor that loads a dxfFile into memory. This constructor
        /// can be used for binary or Ascii files.
        /// </summary>
        /// <param name="fileStream">A filestream that points to the file</param>
        /// <param name="isBinary">True if the file is binary</param>
        public DxfFile(FileStream fileStream, bool isBinary)
        {
            // Load the file
            LoadFile(fileStream, isBinary);
        }

        #endregion

        #region Public Members

        /// <summary>
        /// A list of all the entities in the Dxf File
        /// </summary>
        public List<IEntity> Entities => _container.Entities.Entities;

        /// <summary>
        /// Get an Enumerable list of entities given their types
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <returns>A list of entities</returns>
        public IEnumerable<T> GetEntities<T>()
        {
            return Entities
                .Where(e => e.GetType() == typeof(T)).Cast<T>();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Load the file and populate this dxf file
        /// </summary>
        /// <param name="fileStream">The filestream where the file is</param>
        /// <param name="isBinary">If true then read the file as if it is binary</param>
        private void LoadFile(Stream fileStream, bool isBinary)
        {
            if (!isBinary)
            {
                using (var reader = new DxfAsciiReader(fileStream))
                {
                    var parser = new DxfAsciiParser();
                    _container = parser.Parse(reader);
                }
            }
            else
            {
                using (var reader = new DxfBinaryReader(fileStream))
                {
                    var parser = new DxfAsciiParser();
                    _container = parser.Parse(reader);
                }
            }
        }

        #endregion
    }
}
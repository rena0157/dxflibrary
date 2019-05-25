// EntityTestBase.cs
// By: Adam Renaud
// Created on: 2019-01-13

// System Using Statements
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

// Test Using Statements
using Xunit;
using Xunit.Abstractions;

// Internal Using Statements
using DxfLibrary.Entities;
using DxfLibrary.Geometry;

namespace DxfLibrary.Tests.Entities
{
    /// <summary>
    /// Base class for all entities. Contains the functionality 
    /// for a virual file using a memory stream. A string can be written to
    /// the stream and then passed to the dxf parser to simulate a file.
    /// </summary>
    public class EntityTestBase : MemoryStreamTestBase
    {

        /// <summary>
        /// Takes the data string, writes to the memory buffer,
        /// reads the dxffile and extracts the first entity that
        /// matches the type given.
        /// </summary>
        /// <param name="data">The data that represents a dxffile</param>
        /// <typeparam name="T">The entity type</typeparam>
        /// <returns>Returns the First Entity from the Dxf File that matches the type given</returns>
        protected T GetFirstEntity<T>(string data)
        {
            WriteMemory(data);
            var dxfFile = new DxfFile(TextMemStream);
            var entity = dxfFile.GetEntities<T>();
            return entity.FirstOrDefault();
        }

        protected T GetFirstEntity<T>(byte[] data)
        {
            WriteMemory(data);
            var dxfFile = new DxfFile(BinMemStream, true);
            var entity = dxfFile.GetEntities<T>();
            return entity.FirstOrDefault();
        }

        /// <summary>
        /// Takes the data string, writes to the memory buffer,
        /// reads the dxf file and extracts all of the entities
        /// </summary>
        /// <param name="data">The data that represents a dxf file</param>
        /// <returns>Returns: A list of all the entities from the file</returns>
        protected List<IEntity> GetAllEntities(string data)
        {
            WriteMemory(data);
            var dxfFile = new DxfFile(TextMemStream);
            return dxfFile.Entities;
        }

        protected List<IEntity> GetAllEntities(byte[] data)
        {
            WriteMemory(data);
            var dxfFile = new DxfFile(BinMemStream);
            return dxfFile.Entities;
        }

        /// <summary>
        /// Default Constructor for the EntityBaseClass.
        /// This Constructor initalizes the streams and provides a
        /// logger from the TestBase Class
        /// </summary>
        /// <param name="logger">Logger passed from XUnit</param>
        public EntityTestBase(ITestOutputHelper logger) : base(logger)
        {

        }
    }
}
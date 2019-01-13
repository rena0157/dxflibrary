// LineTests.cs
// By: Adam Renaud
// Created on: 2019-01-12

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using Xunit;
using Xunit.Abstractions;

using DxfLibrary.Entities;
using DxfLibrary.Geometry;

namespace DxfLibrary.Tests.Entities
{
    public class LineTests : TestBase, IDisposable
    {

        #region TestString

        private string testString = 
@"  0
SECTION
  2
ENTITIES
  0
LINE
  5
31B
330
1F
100
AcDbEntity
  8
TestLayer
100
AcDbLine
 10
6.820335402780456
 20
6.189017678063052
 30
0.0
 11
15.86268769259617
 21
10.24974368590587
 31
0.0
  0
ENDSEC
  0";

        #endregion


        /// <summary>
        /// The memory Stream that is used to simulate
        /// a file that is read by the dxf file
        /// </summary>
        private MemoryStream _memStream;

        /// <summary>
        /// A StreamWriter that is used to write to the memoryStream,
        /// Note that this is not disposed of until the object is distroyed to 
        /// keep the base stream alive.
        /// </summary>
        private StreamWriter _writer;

        #region Constructors

        /// <summary>
        /// Default Constructor for the LineTests Class.
        /// This constructor sets up everything that the test will need to run
        /// </summary>
        /// <param name="logger">A logger that is passed to the class during runtime</param>
        public LineTests(ITestOutputHelper logger) : base(logger)
        {
            // Open the memory stream and write the data to it
            _memStream = new MemoryStream();
            _writer = new StreamWriter(_memStream);
            _writer.Write(testString);

            // Make sure to flush the data and reset the position
            // to simulate a file that is going to be read by the dxf file
            _writer.Flush();
            _memStream.Position = 0;
        }

        #endregion

        #region TestMethods

        /// <summary>
        /// Quick test to make sure that the Get Entities function
        /// is working
        /// </summary>
        [Fact]
        public void GetEntitiesTest()
        {
            DxfFile dxfFile = new DxfFile(_memStream);
            var lines = dxfFile.GetEntities<Line>();
            Assert.Equal(1, lines.Count());
        }

        /// <summary>
        /// Test that the points are being read from the file correctly
        /// </summary>
        [Fact]
        public void PointTest()
        {
            // Read the file and extract the lines
            DxfFile dxfFile = new DxfFile(_memStream);
            var lines = dxfFile.GetEntities<Line>();

            // Set up two points and test to see if they match what was
            // read from the file
            Assert.Equal(new GeoPoint(6.820335402780456,6.189017678063052),
                lines.FirstOrDefault().StartPoint);
            Assert.Equal(new GeoPoint(15.86268769259617, 10.24974368590587),
                 lines.FirstOrDefault().EndPoint);
        }

        #endregion

        #region Dispose Methods

        /// <summary>
        /// Dispose of the streams that were used in the file
        /// </summary>
        public void Dispose()
        {
            _memStream.Dispose();
            _writer.Dispose();
        }

        #endregion
    }
}
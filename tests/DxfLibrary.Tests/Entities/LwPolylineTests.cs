// LwPolylineTests.cs
// By: Adam Renaud
// Created on: 2019-01-13

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using DxfLibrary.Entities;
using DxfLibrary.Geometry;

using Xunit;
using Xunit.Abstractions;

namespace DxfLibrary.Tests.Entities
{
    /// <summary>
    /// Tests for <see cref="LwPolyline"> class
    /// </summary>
    public class LwPolylineTests : EntityTestBase
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="logger">Logger from XUnit</param>
        public LwPolylineTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #region Tests

        /// <summary>
        /// Tests the parsing of Number of Vertices
        /// </summary>
        /// <param name="value">The string that hold the data</param>
        /// <param name="expectedNumber">The expected number of vertices</param>
        [Theory]
        [InlineData(BasicPolyline, 4)]
        [InlineData(PolylineArc, 4)]
        [InlineData(PolylineOpen, 4)]
        public void NumberOfVerticesTest(string value, int expectedNumber)
        {
            // Arrange
            WriteMemory(value);

            // Act
            DxfFile dxfFile = new DxfFile(_memoryStream);
            var polyline = dxfFile.GetEntities<LwPolyline>().FirstOrDefault();

            // Assert
            Assert.NotNull(polyline);
            Assert.Equal(expectedNumber, polyline.NumberOfVerticies);
        }

        /// <summary>
        /// Testing the parsing of the PolylineFlag
        /// </summary>
        /// <param name="value">Polyline String</param>
        /// <param name="expectedValue">The Expected Value</param>
        [Theory]
        [InlineData(BasicPolyline, true)]
        [InlineData(PolylineArc, true)]
        [InlineData(PolylineOpen, false)]
        public void PolylineFlagTest(string value, bool expectedValue)
        {
            // Arrange
            WriteMemory(value);

            // Act
            DxfFile dxfFile = new DxfFile(_memoryStream);
            var polyline = dxfFile.GetEntities<LwPolyline>().FirstOrDefault();

            // Assert
            Assert.NotNull(polyline);
            Assert.Equal(expectedValue, polyline.PolylineFlag);
        }

        /// <summary>
        /// Testing the parsing of the ConstWidth Member
        /// </summary>
        /// <param name="value">The Polyline String</param>
        /// <param name="expectedValue">The expected value</param>
        [Theory]
        [InlineData(BasicPolyline, 2.1)]
        [InlineData(PolylineArc, 0)]
        [InlineData(PolylineOpen, 0)]
        public void ConstantWidth(string value, double expectedValue)
        {
            // Arrange
            WriteMemory(value);

            // Act
            var dxfFile = new DxfFile(_memoryStream);
            var polyline = dxfFile.GetEntities<LwPolyline>().FirstOrDefault();

            // Assert
            Assert.NotNull(polyline);
            Assert.Equal(expectedValue, polyline.ConstWidth);
        }

        /// <summary>
        /// Testing the parsing of the elevation member
        /// </summary>
        /// <param name="value">The value of the file</param>
        /// <param name="expectedValue">The expected value</param>
        [Theory]
        [InlineData(BasicPolyline, 100.5)]
        [InlineData(PolylineArc, 0)]
        [InlineData(PolylineOpen, 0)]
        public void ElevationTest(string value, double expectedValue)
        {
            // Arrange
            WriteMemory(value);

            // Act
            var dxfFile = new DxfFile(_memoryStream);
            var polyline = dxfFile.GetEntities<LwPolyline>().FirstOrDefault();

            // Assert
            Assert.NotNull(polyline);
            Assert.Equal(expectedValue, polyline.Elevation);

        }

        /// <summary>
        /// Testing the parsing of the thickness member
        /// </summary>
        /// <param name="value">File string</param>
        /// <param name="expectedValue">Expected value</param>
        [Theory]
        [InlineData(BasicPolyline, 3.2)]
        [InlineData(PolylineArc, 0)]
        [InlineData(PolylineOpen, 0)]
        public void ThicknessTest(string value, double expectedValue)
        {
            // Arrange
            WriteMemory(value);

            // Act
            var dxfFile = new DxfFile(_memoryStream);
            var polyline = dxfFile.GetEntities<LwPolyline>().FirstOrDefault();

            // Assert
            Assert.NotNull(polyline);
            Assert.Equal(expectedValue, polyline.Thickness);
        }

        [Theory]
        [InlineData(BasicPolyline, 13)]
        [InlineData(PolylineOpen, 11.4031)]
        public void LengthTest(string value, double length)
        {
            // Arrange
            WriteMemory(value);

            // Act
            var dxfFile = new DxfFile(_memoryStream);
            var polyline = dxfFile.GetEntities<LwPolyline>().FirstOrDefault();

            // Assert
            Assert.NotNull(polyline);
            Assert.Equal(length, polyline.Length, 4);
        }

        #endregion

        #region BasicPolyline

        /// <summary>
        /// Basic closed polyline with 4 points
        /// </summary>
        /// <remarks>
        /// A Basic polyline that is closed with no arcs or bulges.
        /// </remarks>
        private const string BasicPolyline =
@"  0
SECTION
  2
ENTITIES
  0
LWPOLYLINE
  5
4D2
330
1F
100
AcDbEntity
  8
BasicPolyline
100
AcDbPolyline
 90
        4
 70
     1
 43
2.1
 38
100.5
 39
3.2
 10
1.0
 20
0.5
 10
2.5
 20
2.5
 10
5.0
 20
2.5
 10
6.5
 20
0.5
  0
ENDSEC
  0";

        #endregion

        #region PolyLineArc

        private const string PolylineArc = 
@"  0
SECTION
  2
ENTITIES
  0
LWPOLYLINE
  5
4D3
330
1F
100
AcDbEntity
  8
PolylineArc
100
AcDbPolyline
 90
        4
 70
     1
 43
0.0
 10
7.5
 20
0.5
 10
10.0
 20
2.5
 42
-0.2
 10
15.0
 20
2.5
 10
17.5
 20
0.5
  0
ENDSEC
  0";

        #endregion

        #region PolylineOpen
        private const string PolylineOpen = 
@"  0
SECTION
  2
ENTITIES
  0
LWPOLYLINE
  5
4D7
330
1F
100
AcDbEntity
  8
PolylineOpen
100
AcDbPolyline
 90
        4
 70
     0
 43
0.0
 10
20.0
 20
0.5
 10
22.5
 20
2.5
 10
27.5
 20
2.5
 10
30.0
 20
0.5
  0
ENDSEC
  0";


        #endregion
    }
}
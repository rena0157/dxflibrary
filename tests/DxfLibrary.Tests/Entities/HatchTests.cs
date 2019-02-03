// HatchTests.cs
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
using System.Collections;

namespace DxfLibrary.Tests.Entities
{
    public class HatchTests : EntityTestBase
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="logger">Logger DI from XUnit</param>
        public HatchTests(ITestOutputHelper logger) : base(logger)
        {
        }

        /// <summary>
        /// Helper Function that writes the test string the memory,
        /// reads the file and gets the first hatch from the list.
        /// </summary>
        /// <param name="testString">The string that is written to memory</param>
        /// <returns>Returns: The first hatch that was read from the file</returns>
        private Hatch GetFirstHatch(string testString)
        {
            WriteMemory(testString);
            var dxfFile = new DxfFile(_memoryStream);
            var hatch = dxfFile.GetEntities<Hatch>().FirstOrDefault();
            Assert.NotNull(hatch);
            return hatch;
        }

        #region TestData

        /// <summary>
        /// Class Data for the Elevation Point Tests
        /// </summary>
        public class ElevationPointTestData : IEnumerable<object[]>
        {
            // Regular Hatch Test
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    RegularHatch,
                    new GeoPoint(0,0)
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion

        #region Tests

        /// <summary>
        /// Testing the <see cref="Hatch.ElevationPoint"> Property Extraction
        /// </summary>
        /// <param name="testString">The Dxf String to test</param>
        /// <param name="expectedValue">The expected value of the Elevation Point</param>
        [Theory]
        [ClassData(typeof(ElevationPointTestData))]
        public void ElevationPointTest(string testString, GeoPoint expectedValue) 
            => Assert.Equal(expectedValue, GetFirstHatch(testString).ElevationPoint);


        #endregion


        #region Regular Hatch

        const string RegularHatch = 
@"  0
SECTION
  2
ENTITIES
  0
LWPOLYLINE
  5
323
102
{ACAD_REACTORS
330
331
102
}
330
1F
100
AcDbEntity
  8
TestLayer
100
AcDbPolyline
 90
        4
 70
     1
 43
0.0
 10
0.0
 20
0.0
 10
10.0
 20
0.0
 10
10.0
 20
10.0
 10
0.0
 20
10.0
  0
HATCH
  5
331
330
1F
100
AcDbEntity
  8
TestLayer
100
AcDbHatch
 10
0.0
 20
0.0
 30
0.0
210
0.0
220
0.0
230
1.0
  2
ANSI31
 70
     0
 71
     1
 91
        1
 92
        1
 93
        4
 72
     1
 10
0.0
 20
0.0
 11
10.0
 21
0.0
 72
     1
 10
10.0
 20
0.0
 11
10.0
 21
10.0
 72
     1
 10
10.0
 20
10.0
 11
0.0
 21
10.0
 72
     1
 10
0.0
 20
10.0
 11
0.0
 21
0.0
 97
        1
330
323
 75
     1
 76
     1
 52
0.0
 41
4.999999999999998
 77
     0
 78
     1
 53
45.0
 43
0.0
 44
0.0
 45
-0.4419417382415921
 46
0.4419417382415921
 79
     0
 98
        1
 10
0.0
 20
0.0
1001
GradientColor1ACI
1070
     5
1001
GradientColor2ACI
1070
     2
1001
ACAD
1010
0.0
1020
0.0
1030
0.0
  0
ENDSEC
  0";

        #endregion

    }
}
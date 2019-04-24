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
    /// <summary>
    /// Class for testing the extraction and creation of hatches
    /// </summary>
    public class HatchTests : EntityTestBase
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="logger">Logger DI from XUnit</param>
        public HatchTests(ITestOutputHelper logger) : base(logger)
        {
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
                    PatternHatch,
                    new GeoPoint(0,0)
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion

        #region Tests

        /// <summary>
        /// Testing the <see cref="Hatch.ElevationPoint"/> Property Extraction
        /// </summary>
        /// <param name="testString">The Dxf String to test</param>
        /// <param name="expectedValue">The expected value of the Elevation Point</param>
        [Theory]
        [ClassData(typeof(ElevationPointTestData))]
        public void ElevationPointTest(string testString, GeoPoint expectedValue) 
            => Assert.Equal(expectedValue, GetFirstEntity<Hatch>(testString).ElevationPoint);


        /// <summary>
        /// Testing the <see cref="Hatch.PatternName"/> Property Extraction
        /// </summary>
        /// <param name="testString">The Dxf String to test</param>
        /// <param name="expectedValue">The expected value of the pattern name</param>
        [Theory]
        [InlineData(PatternHatch, "ANSI31")]
        public void PatternNameTest(string testString, string expectedValue) 
            => Assert.Equal(expectedValue, GetFirstEntity<Hatch>(testString).PatternName);

        /// <summary>
        /// Testing the <see cref="Hatch.HasSolidFill"> Property Extraction
        /// </summary>
        /// <param name="testString">The Dxf String to test</param>
        /// <param name="expectedValue">The expected value of the property</param>
        [Theory]
        [InlineData(PatternHatch, false)]
        [InlineData(SolidFillHatch, true)]
        public void HasSolidFillTest(string testString, bool expectedValue) 
            => Assert.Equal(expectedValue, GetFirstEntity<Hatch>(testString).HasSolidFill);

        /// <summary>
        /// Testing the <see cref="Hatch.IsAssociative"/> Property Extraction
        /// </summary>
        /// <param name="testString">The Dxf String to test</param>
        /// <param name="expectedValue">The expected value of the property</param>
        [Theory]
        [InlineData(PatternHatch, true)]
        [InlineData(SolidFillHatch, true)]
        [InlineData(NonAssociativeHatch, false)]
        public void IsAssociativeTest(string testString, bool expectedValue) 
            => Assert.Equal(expectedValue, GetFirstEntity<Hatch>(testString).IsAssociative);

        /// <summary>
        /// Testing the <see cref="Entity.References"/> soft pointer property
        /// </summary>
        /// <param name="testString">The Dxf String to test</param>
        /// <param name="expectedValue">The expected value of the property</param>
        [Theory]
        [InlineData(SolidFillHatch, "323")]
        [InlineData(PatternHatch, "323")]
        public void SoftPointerReferencesTest(string testString, string expectedValue)
            => Assert.Equal(expectedValue,
                GetFirstEntity<Hatch>(testString).References
                .FirstOrDefault(r => r.SoftPointer == expectedValue)?.SoftPointer);

        #endregion

        #region Regular Pattern Hatch

        const string PatternHatch = 
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
     0
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

        #region Solid Fill Hatch

        /// <summary>
        /// DxfData with an LWPOLYLINE and HATCH That has solid fill.
        /// The Hatch is associative with the polyline and has references all set up
        /// </summary>
        public const string SolidFillHatch = 
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
SOLID
 70
     1
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
 98
        1
 10
0.0
 20
0.0
450
        0
451
        0
460
0.0
461
0.0
452
        0
462
0.0
453
        2
463
0.0
 63
     5
421
      255
463
1.0
 63
     2
421
 16776960
470
LINEAR
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
    
        #region Non-Associative Hatch

        const string NonAssociativeHatch = 
@"  0
SECTION
  2
ENTITIES
  0
HATCH
  5
836
330
1F
100
AcDbEntity
  8
BasicPolyline
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
SOLID
 70
     1
 71
     0
 91
        1
 92
        1
 93
        4
 72
     2
 10
-5.083333333333335
 20
18.08333333333333
 40
18.23496336406764
 50
294.573975236911
 51
320.563208820744
 73
     1
 72
     2
 10
11.25
 20
1.6875
 40
5.3125
 50
244.942384581697
 51
295.0576154183031
 73
     0
 72
     1
 10
13.5
 20
6.5
 11
17.0
 21
2.5
 72
     1
 10
17.0
 20
2.5
 11
2.5
 21
1.5
 97
        0
 75
     1
 76
     1
 98
        1
 10
0.0
 20
0.0
450
        0
451
        0
460
0.0
461
0.0
452
        0
462
0.0
453
        2
463
0.0
 63
     5
421
      255
463
1.0
 63
     2
421
 16776960
470
LINEAR
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
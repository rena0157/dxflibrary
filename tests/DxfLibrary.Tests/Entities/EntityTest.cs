// EntityTest.cs
// By: Adam Renaud
// Created: 2019-01-13

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using Xunit;
using Xunit.Abstractions;

using DxfLibrary.Entities;

namespace DxfLibrary.Tests.Entities
{
    /// <summary>
    /// Test basic <see cref="Entity"> parsing and functionality
    /// </summary>
    public class EntityTest : EntityTestBase
    {

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="logger">Logger from XUnit</param>
        public EntityTest(ITestOutputHelper logger) : base(logger)
        {
        }

        #endregion

        #region Tests

        /// <summary>
        /// Test that the layer name is being matched correctly
        /// </summary>
        [Theory]
        [InlineData(GenericEntity, "TestLayer")]
        public void LayerNameTest(string testString, string expected) 
            => Assert.Equal(expected, GetFirstEntity<Line>(testString).LayerName);

        [Theory]
        [InlineData(GenericEntity, "1F")]
        public void SoftPointerTest(string testString, string expected)
            => Assert.Equal(expected, 
                GetFirstEntity<Line>(testString)
                .References
                .FirstOrDefault()
                .SoftPointer);

        #endregion

        #region TestString

        private const string GenericEntity = 
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
    }
}
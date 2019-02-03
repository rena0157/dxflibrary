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

        public class TestStringData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    @"Test",
                    new GeoPoint(0,0)
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion

        #region Tests

        [Theory]
        [ClassData(typeof(TestStringData))]
        public void ElevationPointTest(string testString, GeoPoint expectedValue) 
            => Assert.Equal(expectedValue, GetFirstHatch(testString).ElevationPoint);


        #endregion


    }
}
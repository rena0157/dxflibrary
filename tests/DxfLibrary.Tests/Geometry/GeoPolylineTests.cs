// GeoPolylineTests.cs
// By: Adam Renaud
// 2019-01-27

using System;
using System.Collections;
using System.Collections.Generic;
using DxfLibrary.Geometry;
using Xunit;
using Xunit.Abstractions;

namespace DxfLibrary.Tests.Geometry
{
    /// <summary>
    /// Class for testing the Geopolyline
    /// </summary>
    public class GeoPolylineTests : TestBase
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public GeoPolylineTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #region TestData

        /// <summary>
        /// Class for holding the data for testing areas
        /// </summary>
        class AreaTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                // Type: Arc
                // Draw Direction: CCW
                // Bulge: +ve
                yield return new object[]
                {
                    new GeoPolyline
                    (
                        new List<double>{ 0, 5, 5, 0 }, 
                        new List<double>{ 0, 0, 2.5, 2.5 }, 
                        new List<double>{ 0, 0, 1, 0}, 
                        true
                    ),
                    22.3175
                };

                // Type: Arc
                // Draw Direction: CW
                // Bulge: -ve
                yield return new object[]
                {
                    new GeoPolyline
                    (
                        new List<double>{ 0, 0, 5, 5 },
                        new List<double>{ 0, 2.5, 2.5, 0 },
                        new List<double>{ 0, -1.0, 0, 0 },
                        true
                    ),
                    22.3175
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion

        #region Tests

        [Fact]
        public void EnumerableTest()
        {
            // A random polyline with three lines
            List<double> x = new List<double>() {0,2,5};
            List<double> y = new List<double>() {2,3,2};
            var polyline = new GeoPolyline(x, y, true);

            var count = 0;
            // Just test to see that we hit this three times
            foreach(var line in polyline)
                count++;

            Assert.Equal(3, count);
        }

        [Theory]
        [ClassData(typeof(AreaTestData))]
        public void AreaTests(GeoPolyline polyline, double expectedArea) => Assert.Equal(expectedArea, polyline.Area, 4);

        #endregion

    }
}
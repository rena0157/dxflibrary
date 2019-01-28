// GeoPolylineTests.cs
// By: Adam Renaud
// 2019-01-27

using System;
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

        #endregion
    }
}
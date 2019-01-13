// GeoPointTests.cs
// By: Adam Renaud
// Created on: 2019-01-12

using System;
using System.Collections.Generic;

using Xunit;
using Xunit.Abstractions;

using DxfLibrary.Geometry;

namespace DxfLibrary.Tests.Geometry
{
    /// <summary>
    /// Class for testing the <see cref="GeoPoint"> class
    /// </summary>
    public class GeoPointTests : TestBase
    {
        /// <summary>
        /// Default Constructor that accepts an ITestOutputHelper
        /// for logging
        /// </summary>
        /// <param name="logger">The logger</param>
        public GeoPointTests(ITestOutputHelper logger) : base(logger)
        {
        }

        /// <summary>
        /// Testing the basic equals override for a point
        /// </summary>
        [Fact]
        public void EqualsTest()
        {
            // Create some points that are the same
            var point1 = new GeoPoint(0.0, 1.0, 2.0);
            var point2 = new GeoPoint(0.0, 1.0, 2.0);
            // Assert that the equals function works
            Assert.Equal(point1, point2);
        }


        /// <summary>
        /// Test the overriden GetHash Function
        /// </summary>
        [Fact]
        public void GetHashTest()
        {
            var point1 = new GeoPoint(0,0,0);
            Assert.Equal(-1836164009, point1.GetHashCode());
        }

        /// <summary>
        /// Testing the overriden to string method
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            var point1 = new GeoPoint(32.3, 43.2, 432.2);
            var expectedString = "X:32.3, Y:43.2, Z:432.2";
            Assert.Equal(expectedString, point1.ToString());
        }
    }
}
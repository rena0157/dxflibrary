// GeoLineTests.cs
// By: Adam Renaud
// Created on: 2019-01-15

using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

using DxfLibrary.Geometry;

namespace DxfLibrary.Tests.Geometry
{
    /// <summary>
    /// Tests for the GeoLine Class
    /// </summary>
    public class GeoLineTests : TestBase
    {
        #region Constructors

        /// <summary>
        /// Default Constructer that implements basic loggin
        /// functions for the class
        /// </summary>
        /// <param name="logger">The logger that is passed from XUnit</param>
        public GeoLineTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #endregion

        #region Class Data

        /// <summary>
        /// Class for holding data that is used in the length tests
        /// </summary>
        /// <typeparam name="object[]">The array of objects that are passed to the tests</typeparam>
        public class LengthTestData : IEnumerable<object[]>
        {
            /// <summary>
            /// Passes the objects to the Tests using the Enumerator
            /// </summary>
            public IEnumerator<object[]> GetEnumerator()
            {
                // Testing a simple line that has a length of 5
                yield return new object[] 
                {
                    new GeoLine(new GeoPoint(0,0), new GeoPoint(3,4)),
                    5.0
                };

                // An Arc that starts at (0,0) and ends at (1,0) that has
                // a total angle of 180 degrees or pi radians
                yield return new object[]
                {
                    new GeoLine(new GeoPoint(0,0), new GeoPoint(1,0), Bulge.FromAngle(Math.PI)),
                    1.5708
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion

        #region Tests

        /// <summary>
        /// Testing the Length functions for the GeoLine Type
        /// </summary>
        /// <param name="testLine">The Line that is being tested</param>
        /// <param name="expectedLength">The expected length for that line</param>
        [Theory]
        [ClassData(typeof(LengthTestData))]
        public void LengthTests(GeoLine testLine, double expectedLength)
        {
            var actualLength = testLine.Length;
            Assert.Equal(expectedLength, actualLength, 4);
        }

        #endregion

    }
}
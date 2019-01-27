// VectorTests.cs
// By: Adam Renaud
// Created on: 2019-01-27

using System;
using Xunit;
using Xunit.Abstractions;

using DxfLibrary.GeoMath;
using DxfLibrary.Geometry;
using System.Collections.Generic;
using System.Collections;

namespace DxfLibrary.Tests.GeoMath
{
    /// <summary>
    /// Test class for the <see cref="Vector"> Type
    /// </summary>
    public class VectorTests : TestBase
    {
        /// <summary>
        /// Default Constructor that creates the logger
        /// in the base class
        /// </summary>
        /// <param name="logger">The Logger</param>
        public VectorTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #region Tests

        class RotationTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    90,
                    new GeoPoint(0,1)
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        [Theory]
        [ClassData(typeof(RotationTestData))]
        public static void RotationTest(double angle, GeoPoint finalDestination)
        {
            var testVec = Vector.UnitVectorX;
            testVec.RotateZ(BasicGeometry.Deg2Rad(angle));
            Assert.Equal(finalDestination, testVec.Destination);
        }

        #endregion

    }
}
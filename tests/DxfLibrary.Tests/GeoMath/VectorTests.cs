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

        #region TestData

        // Addintion test Data
        class AdditionTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    new Vector(new GeoPoint(0,0), new GeoPoint(0,1)),
                    new Vector(new GeoPoint(0,0), new GeoPoint(1,1))
                };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        /// <summary>
        /// Data for the rotation tests
        /// </summary>
        class RotationTestData : IEnumerable<object[]>
        {
            // Rotation data
            public IEnumerator<object[]> GetEnumerator()
            {
                // 90 degrees counterclockwise rotation
                yield return new object[]
                {
                    90,
                    new GeoPoint(0,1)
                };

                // 90 degrees clockwise rotation
                yield return new object[]
                {
                    -90,
                    new GeoPoint(0, -1)
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        
        #endregion

        #region Tests

        /// <summary>
        /// Test for the addition of two vectors
        /// </summary>
        [Theory]
        [ClassData(typeof(AdditionTestData))]
        public static void AdditionTest(Vector b, Vector expected)
        {
            var a = new Vector(new GeoPoint(0,0), new GeoPoint(1,0));
            var test = a + b;
            Assert.Equal(expected.Length, test.Length);
        }

        /// <summary>
        /// Test for the Rotation of a vector
        /// </summary>
        [Theory]
        [ClassData(typeof(RotationTestData))]
        public static void RotationTest(double angle, GeoPoint finalDestination)
        {
            var testVec = Vector.UnitVectorX;
            testVec.RotateZ(BasicGeometry.Deg2Rad(angle));
            Assert.Equal(finalDestination, testVec.Destination);
        }

        /// <summary>
        /// Trivial Test for the dot product of two vectors
        /// </summary>
        [Fact]
        public static void DotProdTest()
        {
            // Two Random vectors
            var vec1 = new Vector(new GeoPoint(2,3), new GeoPoint(5,2));
            var vec2 = new Vector(new GeoPoint(5,7), new GeoPoint(9,1));

            // Dot product
            var result = vec1.Dot(vec2);
            var expected = 18.0;

            Assert.Equal(expected, result);
        }

        

        #endregion

    }
}
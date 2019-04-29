// DxfTypeTests.cs
// Created By: Adam Renaud
// Created On: 2019-04-29

using System;
using Xunit;
using Xunit.Abstractions;

using DxfLibrary.Utilities;

namespace DxfLibrary.Tests.Utilities
{
    public class DxfTypeTests : TestBase
    {
        public DxfTypeTests(ITestOutputHelper logger) : base(logger)
        {
        }

        /// <summary>
        /// Test for the FromGroupCode function. This test will pass in a group code and see when the
        /// expected type is. If the type matches then the test will pass, if not then the test will fail.
        /// </summary>
        /// <param name="code">The code passed into the test</param>
        /// <param name="expectedType">The expected type that the function should return</param>
        [Theory]
        [InlineData(1, typeof(string))]
        [InlineData(22, typeof(double))]
        [InlineData(50, typeof(double))]
        [InlineData(60, typeof(Int16))]
        [InlineData(125, typeof(double))]
        [InlineData(275, typeof(Int16))]
        [InlineData(999, typeof(string))]
        public void FromGroupCodeTest(int code, Type expectedType)
            => Assert.Equal(expectedType, DxfType.FromGroupCode(code));

        [Theory]
        [InlineData(-2)]
        public void FromGroupCodeTestException(int code)
            => Assert.Throws(typeof(ArgumentException), () => {
                DxfType.FromGroupCode(code);
            });
    }
}
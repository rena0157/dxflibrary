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

        /// <summary>
        /// Test for the FromGroupCode function. This test should cause an expcetion to
        /// be thrown, because all of these group codes should be out of range of the
        /// difference cases
        /// </summary>
        /// <param name="code">The group code passed to the function that should be out of range</param>
        [Theory]
        [InlineData(-2)]
        [InlineData(502)]
        [InlineData(2000)]
        public void FromGroupCodeTestException(int code)
            => Assert.Throws(typeof(ArgumentException), () => 
            {
                DxfType.FromGroupCode(code);
            });


        /// <summary>
        /// Test for the FromGroupCode Function. It tests the ability of the funciton
        /// to parse the string into an integar.
        /// </summary>
        /// <param name="code">The code passed into the function</param>
        /// <param name="expectedType">The expected type returned by the function</param>
        [Theory]
        [InlineData("1", typeof(string))]
        [InlineData("22", typeof(double))]
        [InlineData("50", typeof(double))]
        [InlineData("60", typeof(Int16))]
        [InlineData("125", typeof(double))]
        [InlineData("275", typeof(Int16))]
        [InlineData("999", typeof(string))]
        public void FromGroupCodeTestString(string code, Type expectedType) 
            => Assert.Equal(expectedType, DxfType.FromGroupCode(code));

        /// <summary>
        /// Test for the FromGroupCode Function. This test tests to see if a garbage string
        /// is passed to the function an expcetion should be thrown
        /// </summary>
        /// <param name="code">The garbage code</param>
        [Theory]
        [InlineData("ExceptionTest1")]
        [InlineData("123.234")]
        public void FromGroupCodeTestStringException(string code)
            => Assert.Throws(typeof(ArgumentException), () => 
            {
                DxfType.FromGroupCode(code);
            });
    }
}
// TestBase.cs
// Created by: Adam Renaud
// Created on: 2019-01-05

// System Using Statements
using System;


// Internal Using Statements
using Xunit;
using Xunit.Abstractions;

namespace DxfLibrary.Tests
{
    /// <summary>
    /// A basic test class that implements the ITestOutputHelper
    /// </summary>
    public class TestBase
    {
        #region Protected Members

        /// <summary>
        /// The logger for the test class
        /// </summary>
        protected ITestOutputHelper _logger;

        protected int _doubleTolerance;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor for the testbase class
        /// This constructor will initialize the logger.
        /// </summary>
        /// <param name="logger">The logger that should be passed to the class</param>
        public TestBase(ITestOutputHelper logger)
        {
            _logger = logger;
        }

        #endregion
    }
}
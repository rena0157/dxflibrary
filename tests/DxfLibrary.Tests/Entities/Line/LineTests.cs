// LineTests.cs
// By: Adam Renaud
// Created on: 2019-01-12

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using Xunit;
using Xunit.Abstractions;

using DxfLibrary.Entities;

namespace DxfLibrary.Tests.Entities
{
    public class LineTests : TestBase, IDisposable
    {

        #region TestString

        private string testString = 
@"  0
SECTION
  2
ENTITIES
  0
LINE
  5
31B
330
1F
100
AcDbEntity
  8
TestLayer
100
AcDbLine
 10
6.820335402780456
 20
6.189017678063052
 30
0.0
 11
15.86268769259617
 21
10.24974368590587
 31
0.0
  0
ENDSEC
  0";

        #endregion


        private MemoryStream _memStream;

        private StreamWriter _writer;

        #region Constructors

        public LineTests(ITestOutputHelper logger) : base(logger)
        {
            _memStream = new MemoryStream();
            _writer = new StreamWriter(_memStream);
            _writer.Write(testString);
            _writer.Flush();
            _memStream.Position = 0;
        }

        #endregion

        #region TestMethods

        [Fact]
        public void Test()
        {
            DxfFile dxfFile = new DxfFile(_memStream);
        }

        #endregion

        #region Dispose Methods

        public void Dispose()
        {
            _memStream.Dispose();
            _writer.Dispose();
        }

        #endregion
    }
}
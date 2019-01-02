// DxfAsciiParser.cs
// By: Adam Renaud
// Created: 2019-01-01

// System using statements
using System;
using System.IO;

// Internal using statements
using DxfLibrary.IO;

namespace DxfLibrary.Parse
{
    /// <summary>
    /// The main Ascii parser. This function will be used as the main entry point for
    /// the parsing of Dxf Ascii Files
    /// </summary>
    /// <typeparam name="T">The parse type return</typeparam>
    public class DxfAsciiParser<T> : IDxfParser<T, string, object>
    {
        public T Parse(IDxfReader<string, object> reader)
        {
            throw new NotImplementedException();
        }
    }
}
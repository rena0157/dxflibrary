// IDxfParser.cs
// Created by: Adam Renaud
// Created on: 2019-01-01

// System using Statements
using System;
using System.IO;

// Internal using Statements
using DxfLibrary.IO;

namespace DxfLibrary.Parse
{
    /// <summary>
    /// Defines the interface for the IDxfParser.
    /// </summary>
    /// <typeparam name="T">The return type of the parser</typeparam>
    /// <typeparam name="G">The groupcode type for the IDxfReader</typeparam>
    /// <typeparam name="V">The Value Type for the IDxfReader</typeparam>
    public interface IDxfParser<T, G, V>
    {
        /// <summary>
        /// Parse Function. This function will return a parsed object from 
        /// the passed in reader
        /// </summary>
        /// <param name="reader">The reader for which to parse information from</param>
        /// <returns>A parsed data set that is of type T</returns>
        T Parse(IDxfReader<G, V> reader);
    }
}
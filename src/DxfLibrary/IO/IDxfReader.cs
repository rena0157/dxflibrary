// IDxfReader.cs 
// By: Adam Renaud
// Created: 2019-01-01

using System;
using System.IO;

namespace DxfLibrary.IO
{
    /// <summary>
    /// The IDxfReader interface. This interface is used to define
    /// the functionality of any Dxf Reader class. 
    /// </summary>
    /// <typeparam name="G">The type of the group code that will be used in the TaggedData</typeparam>
    /// <typeparam name="V">The type of the value that will be used in the Tagged Data</typeparam>
    public interface IDxfReader<G, V> : IDisposable
    {
        /// <summary>
        /// The Path to the file that this is reading from
        /// </summary>
        string Path {get;}

        /// <summary>
        /// The Current Position of the reader. For Ascii Files this represents
        /// the current line that the file is about to read. For binary files this reporesents
        /// the current byte that is about to be read
        /// </summary>
        long CurrentPosition {get;}

        /// <summary>
        /// Returns true if the reader has reached the end of the stream and can no
        /// longer read any more data.
        /// </summary>
        bool EndOfStream {get;}

        /// <summary>
        /// Gets the next pair of data from the stream. This can be
        /// the next two lines or the next two items in a binary file.
        /// </summary>
        /// <returns>A new <see cref="TaggedData{G, V}"> that contains the information from the stream</returns>
        TaggedData<G, V> GetNextPair();

    }
}
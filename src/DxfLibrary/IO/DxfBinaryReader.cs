// DxfBinaryReader.cs
// By: Adam Renaud
// Created: 2019-04-24

using System;
using System.IO;

namespace DxfLibrary.IO
{
    public class DxfBinaryReader : IDxfReader<byte[], byte[]>
    {

        #region Private Properties

        private BinaryReader _reader;

        #endregion

        #region Constructors

        public DxfBinaryReader(Stream stream)
        {
            _reader = new BinaryReader(stream);
        }

        #endregion

        #region Public Properties

        public string Path => (_reader.BaseStream as FileStream).Name;

        public long CurrentPosition {get; protected set;}

        public bool EndOfStream => _reader.BaseStream.Position == _reader.BaseStream.Length;

        #endregion

        #region Public Methods

        public void Dispose()
        {
            _reader.Dispose();
        }

        public TaggedData<byte[], byte[]> GetNextPair()
        {
            return new TaggedData<byte[], byte[]>(_reader.ReadBytes(2), _reader.ReadBytes(2));
        }

        public TaggedData<byte[], byte[]> PeekNextPair()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
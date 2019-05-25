// IMemoryStreamTestBase.cs
// By: Adam Renaud
// Created: 2019-05-25

using System;
using System.IO;

/// <summary>
/// An interface for writing a stream of char or bytes to memory
/// </summary>
public interface IMemoryStreamTestBase : IDisposable
{
    MemoryStream TextMemStream {get; set;}
    MemoryStream BinMemStream {get; set;}

    void WriteMemory(byte[] value);

    void WriteMemory(string value);
}
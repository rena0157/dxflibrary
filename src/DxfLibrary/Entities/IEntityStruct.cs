// IEntityStruct.cs
// By: Adam Renaud
// Created: 2019-02-07

using System;
using System.Collections.Generic;

using DxfLibrary.Parse.Sections;
using DxfLibrary.Utilities;

namespace DxfLibrary.Entities
{
    /// <summary>
    /// Interface that decalares the behaviour of
    /// an IEntity Struct
    /// </summary>
    public interface IEntityStruct : IDxfParsable, IEntity
    {
        
    }
}
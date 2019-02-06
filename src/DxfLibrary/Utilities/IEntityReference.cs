// IEntityReference.cs
// By: Adam Renaud
// Created: 2019-02-06

using System;
using DxfLibrary.Entities;

namespace DxfLibrary.Utilities
{
    /// <summary>
    /// Interface that declares the properties
    /// of an Entity Reference
    /// </summary>
    public interface IEntityReference
    {
        /// <summary>
        /// The soft pointer from the dxf file
        /// </summary>
        string SoftPointer {get;}

        /// <summary>
        /// The actual reference to the entity
        /// </summary>
        IEntity Reference {get;}

        /// <summary>
        /// Flag for telling if the entity is linked
        /// </summary>
        bool IsLinked {get;}
    }
}
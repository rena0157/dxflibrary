// EntityReference.cs
// Created: 2019-02-10
// By: Adam Renuad

using System;
using DxfLibrary.Entities;

namespace DxfLibrary.Utilities
{
    /// <summary>
    /// The Entity Reference type
    /// </summary>
    public class EntityReference : IEntityReference
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="softPointer">The soft pointer to another entity</param>
        public EntityReference(string softPointer)
        {
            SoftPointer = softPointer;
            Reference = null;
        }

        /// <summary>
        /// The soft pointer to another entity
        /// </summary>
        public string SoftPointer {get;}

        /// <summary>
        /// The actual reference to another entity
        /// </summary>
        public IEntity Reference {get; set;}

        /// <summary>
        /// Returns true if the entity is linked
        /// </summary>
        public bool IsLinked => Reference != null;
    }
}
// IEntity.cs
// Created by: Adam Renaud
// Created on: 2019-01-06

using System;

namespace DxfLibrary.Entities
{
    /// <summary>
    /// The Entity Interface
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// The type of the entity
        /// </summary>
        Type EntityType {get;}

        /// <summary>
        /// The Entity's handle or ID
        /// </summary>
        string Handle {get;}

        /// <summary>
        /// The soft pointer of the entity
        /// </summary>
        string SoftPointer {get;}

        /// <summary>
        /// The entity Layer name
        /// </summary>
        /// <value></value>
        string LayerName {get;}
    }
}
// IEntity.cs
// Created by: Adam Renaud
// Created on: 2019-01-06

using System;
using System.Collections.Generic;

using DxfLibrary.Parse;
using DxfLibrary.Parse.Entities;
using DxfLibrary.Parse.Sections;
using DxfLibrary.Geometry;
using DxfLibrary.Utilities;

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
        /// Objects that this entity references
        /// </summary>
        List<IEntityReference> References {get;}

        /// <summary>
        /// The entity Layer name
        /// </summary>
        /// <value></value>
        string LayerName {get;}
    }
}
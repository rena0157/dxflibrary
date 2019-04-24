// IDxfLinker.cs
// By: Adam Renaud
// Created: 2019-02-06

using System;
using System.Collections.Generic;
using DxfLibrary.Entities;

namespace DxfLibrary.Utilities
{
    public interface IDxfLinker
    {
        /// <summary>
        /// Link the entities in the list
        /// </summary>
        /// <param name="entities">The entities that will be linked</param>
        // /// <returns>True if successful</returns>
        bool LinkEntities(List<IEntity> entities);
    }
}
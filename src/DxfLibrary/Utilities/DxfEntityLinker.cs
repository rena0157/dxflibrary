// DxfEntityLinker.cs
// By: Adam Renaud
// Created: 2019-04-24

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DxfLibrary.Entities;

namespace DxfLibrary.Utilities
{
    /// <summary>
    /// Dxf Linker Class for entities
    /// </summary>
    public class DxfEntityLinker : IDxfLinker
    {
        public bool LinkEntities(List<IEntity> entities)
        {

            // For each entity and each entity's references
            // search for the references in the entities and link it
            // to the current entity
            foreach ( var entity in entities )
            {
                foreach ( var reference in entity.References )
                {
                    if ( reference.IsLinked )
                    {
                        continue;
                    }

                    reference.Reference 
                        = entities.First(e => e.Handle == reference.SoftPointer);

                }
            }

            return true;
        }
    }
}

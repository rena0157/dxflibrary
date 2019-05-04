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
        /// <summary>
        /// Link Entities together using softpointer and
        /// handles 
        /// </summary>
        /// <param name="entities">The list of entities that will be linked</param>
        /// <returns>Returns true if successful</returns>
        public bool LinkEntities(List<IEntity> entities)
        {

            // For each entity and each entity's references
            // search for the references in the entities and link it
            // to the current entity
            foreach ( var entity in entities )
            {
                // Remove all 1F References from this entity
                entity.References.RemoveAll(
                    r => ((IEntityReference)r).SoftPointer == "1F");

                foreach ( var reference in entity.References )
                {
                    // If the reference is already linked
                    // Don't relink it
                    if ( reference.IsLinked )
                        continue;

                    // Get the referenced entity if it exists
                    var referencedEntity = entities.FirstOrDefault(e => e.Handle == reference.SoftPointer);

                    // Make sure that it is not null
                    if (referencedEntity == null)
                        continue;

                    // Set the reference
                    reference.Reference = referencedEntity;

                    // The referenced entity's reference to the current entity
                    // If this reference does not exist this will return a null value
                    var referencedEntityRef = referencedEntity.References
                        .FirstOrDefault(r => r.SoftPointer == entity.Handle);

                    // if the referenced entity's reference to the current entity is not null and
                    // hasn't already been linked, link it
                    if ( referencedEntityRef != null && !referencedEntityRef.IsLinked)
                        referencedEntityRef.Reference = entity;
                    
                    // Else add a new reference to the referenced entity
                    else 
                        referencedEntity.References.Add(new EntityReference(entity));
                }
            }

            return true;
        }
    }
}

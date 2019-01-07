// EntityParser.cs
// Created by: Adam Renaud
// Created on: 2019-01-06

using System;
using System.Linq;
using System.Collections.Generic;

using DxfLibrary.Parse;
using DxfLibrary.Entities;
using DxfLibrary.IO;
using DxfLibrary.DxfSpec;

namespace DxfLibrary.Parse.Entities
{
    /// <summary>
    /// A base parsing class for the entity type
    /// </summary>
    public class EntityParser
    {
        /// <summary>
        /// Using a tagged data, entity and spec sets the value of any property
        /// that matches the given data.
        /// </summary>
        /// <param name="data">The current Data</param>
        /// <param name="entity">The entity that is to be set</param>
        /// <param name="spec">The specification to follow</param>
        /// <returns>True if sucessful and false if unsuccessful</returns>
        public bool EntityParse(TaggedData<string, object> data, IEntity entity, IDxfSpec<object> spec)
        {
            // Get the properties from the entity
            var properties = entity.GetType().GetProperties();

            // Find properties that match the current data and set them 
            var property = properties
                .Where(prop => spec.Properties
                .Any(s => s.Name as string == prop.Name 
                && data.GroupCode == s.Code as string))
                .FirstOrDefault();

            // If the property is not null then try to set it
            // if unable to set it return false, otherwise return true
            if (property != null)
            {
                try
                {
                    entity.SetProperty(property.Name, data.Value);
                }
                catch(Exception)
                {
                    throw;
                }
                return true;
            }

            // If unable to set a property then return
            return false;
        }
    }
}
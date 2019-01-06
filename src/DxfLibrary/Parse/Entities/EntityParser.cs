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
            var properties = entity.GetType().GetProperties();

            var property = properties
                .Where(prop => spec.Properties
                .Any(s => s.Name as string == prop.Name 
                && data.GroupCode == s.Code as string))
                .FirstOrDefault();

            if (property != null)
            {
                property.SetValue(property, data.Value);
                return true;
            }

            return false;
        }
    }
}
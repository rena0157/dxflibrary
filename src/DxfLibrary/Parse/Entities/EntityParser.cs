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
    public class EntityParser<T> : IDxfEntityParser<T, string, object, object>
    {
        /// <summary>
        /// Parser for the entity base class
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <param name="data">The data that is to be parsed</param>
        /// <param name="entitySpec">The entity specification</param>
        /// <returns>Returns true if the function was able to parse the data</returns>
        public bool BaseParse(IEntity entity, TaggedData<string, object> data, IDxfSpec<object> entitySpec)
        {
            // List all of the properties of the entity
            var properties = entity.GetType().GetProperties();

            // Find properties that match the current data and set them 
            var property = properties
                .Where(prop => entitySpec.Properties
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
                    return false;
                }
                return true;
            }

            // If unable to set a property then return
            return false;
        }

        /// <summary>
        /// Parse Entity Function
        /// </summary>
        /// <param name="entity">The Entity that is to be parsed</param>
        /// <param name="reader">The reader that data will be read from</param>
        /// <param name="entitySpec">The entity specification</param>
        /// <returns></returns>
        public T ParseEntity(IEntity entity, IDxfReader<string, object> reader, IDxfSpec<object> entitySpec)
        {
            // Get the type of the struct
            var structType = typeof(T);

            // get the properties of the return type
            var properties = structType.GetProperties();

            // Get the common spec
            var commonSpec = SpecService.GetSpec<object>(SpecService.DxfCommonSpec);

            // Get the base entity spec
            var baseEntitySpec = SpecService.GetSpec<object>(SpecService.EntitySpec);

            // Read loop
            while(!reader.EndOfStream)
            {
                var data = reader.GetNextPair();
                
                // If we reach the end of an entity then return
                if (commonSpec.Get("Sections.EndCode") as string == data.GroupCode )
                    break;

                // First check to see if the base entity can parse the data
                if (BaseParse(entity, data, baseEntitySpec))
                    continue;

                // Query the specifications to see if the current data matches
                var query = properties
                    .Where(prop => entitySpec.Properties
                    .Any(spec => spec.Name == prop.Name && spec.Code as string == data.GroupCode))
                    .FirstOrDefault();

                // If the current data matches then set the property in the
                // entity
                if (query != null)
                    entity.SetProperty(query.Name, data.Value);
            }

            return (T)entity;
        }
    }
}
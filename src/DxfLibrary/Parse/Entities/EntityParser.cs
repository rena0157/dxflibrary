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
        /// Parse Entity Function
        /// </summary>
        /// <param name="entity">The Entity that is to be parsed</param>
        /// <param name="reader">The reader that data will be read from</param>
        /// <param name="entitySpec">The entity specification</param>
        /// <returns></returns>
        public T ParseEntity(EntityStruct entity, IDxfReader<string, object> reader, IDxfSpec<object> entitySpec)
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
                // If we reach the end of an entity then return
                if (commonSpec.Get("Sections.EndCode") as string == reader.PeekNextPair().GroupCode )
                    break;

                var data = reader.GetNextPair();

                // First check against the base class spec
                var baseQuery = properties
                    .Where(prop => baseEntitySpec.Properties
                    .Any(spec => spec.Name == prop.Name && spec.Code as string == data.GroupCode))
                    .FirstOrDefault();

                // If base spec matches then set and return
                if (baseQuery != null)
                {
                    entity.SetProperty(baseQuery.Name, data.Value);
                    continue;
                }

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

            return (T)Convert.ChangeType(entity, typeof(T));
        }
    }
}
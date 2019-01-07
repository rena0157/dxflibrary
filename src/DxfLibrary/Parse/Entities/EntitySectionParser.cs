// EntityParser.cs
// Created by: Adam Renaud
// Created on: 2019-01-06

using System;
using DxfLibrary.IO;


using DxfLibrary.Parse.Sections;
using DxfLibrary.DxfSpec;
using DxfLibrary.Entities;

namespace DxfLibrary.Parse.Entities
{
    /// <summary>
    /// Parser For the Entity Section
    /// </summary>
    public class EntitySectionParser : IDxfParser<EntitiesSection, string, object>
    {
        /// <summary>
        /// The parse Function for the entity Section
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An Entity Section Object</returns>
        public EntitiesSection Parse(IDxfReader<string, object> reader)
        {
            var entitySection = new EntitiesSection();
            var sectionProperties = entitySection.GetType().GetProperties();

            // Get the entity Specification
            var entitySpec = SpecService.GetSpec<object>(SpecService.EntitySpec);
            var commonSpec = SpecService.GetSpec<object>(SpecService.DxfCommonSpec);

            // Starting Strings
            var lineString = entitySpec.Get("Entity.LineString") as string;
            var startCode = commonSpec.Get("Sections.StartCode") as string;

            while(!reader.EndOfStream)
            {
                var firstPair = reader.GetNextPair();

                if (firstPair.Value as string == commonSpec.Get("Sections.EndString") as string)
                {
                    return entitySection;
                }

                // if the following is true then start parsing a LINE
                if (firstPair.GroupCode == startCode && firstPair.Value as string == lineString)
                {   
                    var parser = new EntityParser<LineStructure>();
                    var specification = SpecService.GetSpec<object>(SpecService.LineSpec);

                    // Make the line
                    var line = new Line(parser.ParseEntity(new LineStructure(), reader, specification));
                }

            }

            throw new NotImplementedException();
        }
    }
}
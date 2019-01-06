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
    public class EntitySectionParser : IDxfParser<EntitiesSection, string, object>
    {
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

            Entity currentEntity = new Entity();

            while(!reader.EndOfStream)
            {
                var firstPair = reader.GetNextPair();

                // if the following is true then start parsing a LINE
                if (firstPair.GroupCode == startCode && firstPair.Value as string == lineString)
                {
                    var lineParser = new LineParser();
                    var line = lineParser.Parse(reader);
                }

            }

            throw new NotImplementedException();
        }
    }
}
// EntityParser.cs
// Created by: Adam Renaud
// Created on: 2019-01-06

using System;
using DxfLibrary.IO;
using DxfLibrary.Parse.Sections;

namespace DxfLibrary.Parse
{
    public class EntityParser : IDxfParser<EntitiesSection, string, object>
    {
        public EntitiesSection Parse(IDxfReader<string, object> reader)
        {
            var entitySection = new EntitiesSection();
            var sectionProperties = entitySection.GetType().GetProperties();
            
            throw new NotImplementedException();
        }
    }
}
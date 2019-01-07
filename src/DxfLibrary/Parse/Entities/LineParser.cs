// LineParser.cs
// Created by: Adam Renaud
// Created on: 2019-01-06

using System;
using DxfLibrary.Entities;
using DxfLibrary.IO;
using DxfLibrary.DxfSpec;

namespace DxfLibrary.Parse.Entities
{
    public class LineParser : EntityParser, IDxfParser<Line, string, object>
    {

        public Line Parse(IDxfReader<string, object> reader)
        {
            // The return line
            var line = new Line();

            // The entity Specification
            var entitySpec = SpecService.GetSpec<object>(SpecService.EntitySpec);
    

            while(!reader.EndOfStream)
            {
                // First send to the EntityBase Parser
                if(EntityParse(reader.GetNextPair(), line, entitySpec))
                    continue;


                
            }
            
            return line;
        }
    }
}
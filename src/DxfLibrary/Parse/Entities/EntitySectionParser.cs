// EntityParser.cs
// Created by: Adam Renaud
// Created on: 2019-01-06

// System Using Statements
using System;
using DxfLibrary.IO;

// Internal Using Statements
using DxfLibrary.Parse.Sections;
using DxfLibrary.DxfSpec;
using DxfLibrary.Entities;
using DxfLibrary.Utilities;

namespace DxfLibrary.Parse.Entities
{
    /// <summary>
    /// Parser For the Entity Section
    /// </summary>
    public class EntitySectionParser : IDxfParser<EntitiesSection, string, object>
    {
        /// <summary>
        /// The parse Function for the entity Section.
        /// </summary>
        /// <param name="reader">The reader that will read from the file</param>
        /// <returns>An Entity Section Object</returns>
        public EntitiesSection Parse(IDxfReader<string, object> reader)
        {
            // The return entity section
            var entitySection = new EntitiesSection();

            // Get the entity Specification
            var entitySpec = SpecService.GetSpec<object>(SpecService.EntitySpec);
            var commonSpec = SpecService.GetSpec<object>(SpecService.DxfCommonSpec);

            // Starting Strings - these string signify the start of a new entity
            var lineString = entitySpec.Get("Entity.LineString") as string;
            var startCode = commonSpec.Get("Sections.StartCode") as string;
            var lwPolylineString = entitySpec.Get("Entity.LwPolylineString") as string;
            var hatchString = entitySpec.Get("Entity.HatchString") as string;
            var textString = entitySpec.Get("Entity.TextString") as string;

            // Main read loop
            while(!reader.EndOfStream)
            {
                var firstPair = reader.GetNextPair();

                if (firstPair.Value as string == commonSpec.Get("Sections.EndString") as string)
                {
                    var entityLinker = new DxfEntityLinker();
                    entityLinker.LinkEntities(entitySection.Entities);
                    
                    return entitySection;
                }

                // if the following is true then start parsing a LINE
                if (firstPair.GroupCode == startCode && firstPair.Value as string == lineString)
                {   
                    var parser = new EntityParser<LineStructure>();
                    var specification = SpecService.GetSpec<object>(SpecService.LineSpec);

                    // Make the line
                    var line = new Line(parser.ParseEntity(new LineStructure(), reader, specification));
                    entitySection.Entities.Add(line);
                }

                // If the following is true then start parsing an LWPOLYLINE
                else if (firstPair.GroupCode == startCode && firstPair.Value as string == lwPolylineString)
                {
                    var parser = new EntityParser<LwPolylineStructure>();
                    var specification = SpecService.GetSpec<object>(SpecService.LwPolylineSpec);

                    // Make the LwPolyline
                    var lwPolyline = new LwPolyline(parser.ParseEntity(new LwPolylineStructure(), reader, specification));
                    entitySection.Entities.Add(lwPolyline);
                }

                // If the following is true then start parsing a HATCH
                else if (firstPair.GroupCode == startCode && firstPair.Value as string == hatchString)
                {
                    var parser = new EntityParser<HatchStructure>();
                    var specification = SpecService.GetSpec<object>(SpecService.HatchSpec);

                    // Make the hatch
                    var hatch = new Hatch(parser.ParseEntity(new HatchStructure(), reader, specification));
                    entitySection.Entities.Add(hatch);
                }

                // If the following is true then start parsing a TEXT entity
                else if (firstPair.GroupCode == startCode && firstPair.Value as string == textString)
                {

                }
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}
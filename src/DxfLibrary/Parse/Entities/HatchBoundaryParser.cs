// HatchBoundaryParser.cs
// By: Adam Renaud
// Created: 2019-04-24

using System;
using DxfLibrary.DxfSpec;
using DxfLibrary.Entities;
using DxfLibrary.Geometry;
using DxfLibrary.IO;

namespace DxfLibrary.Parse.Entities
{
    public class HatchBoundaryParser : IDxfEntityParser<GeoBase, string, object, object, GeoBase>
    {
        public GeoBase ParseEntity(GeoBase entity, IDxfReader<string, object> reader, IDxfSpec<object> entitySpec)
        {
            throw new NotImplementedException();
        }
    }
}
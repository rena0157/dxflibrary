// HeaderSpec.cs
// Created by: Adam Renaud
// Created on: 2019-01-06

// System Using Statements
using System;
using System.Collections.Generic;

// Internal Using Statements


namespace DxfLibrary.DxfSpec
{
    public class HeaderSpec : SpecBase<object>, IDxfSpec<object>
    {
        public string SpecName {get;} = "HeaderSpec";

        public Type SpecType => typeof(HeaderSpec);
    }
}
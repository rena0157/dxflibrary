// EntitiesSection.cs
// Created by: Adam Renaud
// Created on: 2019-01-06

using System;
using System.Collections.Generic;
using System.Linq;

using DxfLibrary.Entities;

namespace DxfLibrary.Parse.Sections
{
    public class EntitiesSection : IDxfParsable
    {
        /// <summary>
        /// Entities that are in the file
        /// </summary>
        public List<IEntity> Entities {get; set;}

        /// <summary>
        /// Set a property in the 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetProperty(string name, object value)
        {
            switch(name)
            {
                case nameof(Entities):
                    Entities = new List<IEntity>();
                    Entities = value as List<IEntity>;
                break;
            }
        }
    }
}
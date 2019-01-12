// Entity.cs
// Created By: Adam Renaud
// Created on: 2019-01-06

using System;

using DxfLibrary.Parse;
using DxfLibrary.Parse.Sections;
using DxfLibrary.Geometry;

namespace DxfLibrary.Entities
{
    /// <summary>
    /// Entity Base class, defines the basic
    /// Functions for an entity
    /// </summary>
    public class Entity : IEntity
    {
        #region Protected Members

        /// <summary>
        /// The entity geometric base
        /// </summary>
        protected GeoBase _geometricBase;

        #endregion

        #region Public Members

        /// <summary>
        /// The type of the Entity
        /// </summary>
        public Type EntityType {get; set;}

        /// <summary>
        /// The Entity's Handle
        /// </summary>
        public string Handle {get; set;}

        /// <summary>
        /// Soft Pointer to another entity
        /// </summary>
        public string SoftPointer {get; set;}

        /// <summary>
        /// The Entity Layer name
        /// </summary>
        public string LayerName {get; set;}

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Entity()
        {

        }

        /// <summary>
        /// Internal Constructor from a struct
        /// </summary>
        /// <param name="struc"></param>
        internal Entity(IEntity struc)
        {
            EntityType = struc.GetType();
            Handle = struc.Handle;
            SoftPointer = struc.SoftPointer;
            LayerName = struc.LayerName;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Set a property in the entity
        /// </summary>
        /// <param name="name">The name of the property</param>
        /// <param name="value">The value of the property</param>
        public virtual void SetProperty(string name, object value)
        {
            switch(name)
            {
                case nameof(EntityType):
                    EntityType = value as Type;
                break;

                case nameof(Handle):
                    Handle = value as string;
                break;

                case nameof(SoftPointer):
                    SoftPointer = value as string;
                break;

                case nameof(LayerName):
                    LayerName = value as string;
                break;

            }
        }

        #endregion
    }
}
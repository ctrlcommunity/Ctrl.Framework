﻿using System;

namespace Ctrl.Core.PetaPoco
{
    /// <summary>
    ///     Represents an attribute which can decorate a Poco property conver value from database type to property type and
    ///     conversely.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class ValueConverterAttribute : Attribute
    {
        /// <summary>
        ///     Function to convert property value to database type value.
        /// </summary>
        /// <param name="value">Property value</param>
        /// <returns>Converted database value</returns>
        public abstract object ConvertToDb(object value);

        /// <summary>
        ///     Function to convert database value to property type value.
        /// </summary>
        /// <param name="value">Database value</param>
        /// <returns>Converted property type value</returns>
        public abstract object ConvertFromDb(object value);
    }
}

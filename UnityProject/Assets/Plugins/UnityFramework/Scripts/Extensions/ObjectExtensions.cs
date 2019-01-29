using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityFramework.Attributes;

namespace UnityFramework.Extensions
{
    public static class ObjectExtensions
    {
        public static List<PropertyInfo> GetValidatedProperties(this object _object)
        {
            var validatedProperties = _object
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => HasValidatePropertyAttribute(x))
                .ToList();

            return validatedProperties;
        }

        public static bool HasValidProperties(this object _object, List<PropertyInfo> validatedProperties)
        {
            foreach (var property in validatedProperties)
            {
                if (property.GetValue(_object).ToString() == "null")
                {
                    return false;
                }
            }

            return true;
        }

        private static bool HasValidatePropertyAttribute(PropertyInfo property)
        {
            var validatePropertyAttribute = Attribute.GetCustomAttribute(property, typeof(ValidatePropertyIsNotNullAttribute));

            return validatePropertyAttribute != null ? true : false;
        }
    }
}

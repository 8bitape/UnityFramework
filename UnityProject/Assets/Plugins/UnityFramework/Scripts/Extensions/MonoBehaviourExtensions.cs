using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityFramework.Attributes;

namespace UnityFramework.Extensions
{
    public static class MonoBehaviourExtensions
    {
        public static List<PropertyInfo> GetValidatedProperties(this object _object)
        {
            var validatedProperties = _object
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => HasValidatePropertyIsNotNullAttribute(x))
                .ToList();

            return validatedProperties;
        }

        public static bool HasPropertiesWithNullValues(this object _object, List<PropertyInfo> validatedProperties)
        {
            foreach (var property in validatedProperties)
            {
                if (property.GetValue(_object).ToString() == "null")
                {
                    return true;
                }
            }

            return false;
        }

        private static bool HasValidatePropertyIsNotNullAttribute(PropertyInfo property)
        {
            var validatePropertyAttribute = Attribute.GetCustomAttribute(property, typeof(ValidatePropertyIsNotNull));

            return validatePropertyAttribute != null ? true : false;
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class Validator
{
    public static bool TryValidateObject(Object _object)
    {
        var props = GetPropertiesWithValidationAttributes(_object);

        foreach (var prop in props)
        {
            if (!GetValidationAttribute(prop).IsValid(prop.GetValue(_object)))
            {
                return false;
            }
        }

        return true;
    }

    private static List<PropertyInfo> GetPropertiesWithValidationAttributes(Object _object)
    {
        var props = _object
            .GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x => HasValidationAttribute(x))
            .ToList();

        return props;
    }

    private static ValidationAttribute GetValidationAttribute(PropertyInfo prop)
    {
        return System.Attribute.GetCustomAttribute(prop, typeof(ValidationAttribute)) as ValidationAttribute;
    }

    private static bool HasValidationAttribute(PropertyInfo prop)
    {
        return GetValidationAttribute(prop) != null ? true : false;
    }
}

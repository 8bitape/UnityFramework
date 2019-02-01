using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class Validator
{
    private static Dictionary<Type, List<PropertyInfo>> cachedProps = new Dictionary<Type, List<PropertyInfo>>();

    public static bool TryValidateObject(object _object)
    {
        if (_object == null)
        {
            return false;
        }

        var props = new List<PropertyInfo>();

        if (cachedProps.ContainsKey(_object.GetType()))
        {
            cachedProps.TryGetValue(_object.GetType(), out props);
        }
        else
        {
            props = GetPropertiesWithValidationAttributes(_object);

            cachedProps.Add(_object.GetType(), props);
        }            

        foreach (var prop in props)
        {
            if (!GetValidationAttribute(prop).IsValid(prop.GetValue(_object)))
            {
                Debug.LogWarning($"{ prop.Name } property is not valid.");

                return false;
            }
        }

        return true;
    }

    private static List<PropertyInfo> GetPropertiesWithValidationAttributes(object _object)
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

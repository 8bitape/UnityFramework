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
            foreach (var attribute in GetValidationAttributes(prop))
            {
                if (!attribute.IsValid(prop.GetValue(_object)))
                {
                    Debug.LogWarning($"{ prop.Name } property is not valid.");

                    return false;
                }
            }
        }

        return true;
    }

    private static List<PropertyInfo> GetPropertiesWithValidationAttributes(object _object)
    {
        var props = _object
            .GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x => HasValidationAttributes(x))
            .ToList();

        return props;
    }

    private static ValidationAttribute[] GetValidationAttributes(PropertyInfo prop)
    {
        return System.Attribute.GetCustomAttributes(prop, typeof(ValidationAttribute)) as ValidationAttribute[];
    }

    private static bool HasValidationAttributes(PropertyInfo prop)
    {
        return GetValidationAttributes(prop) != null ? true : false;
    }
}

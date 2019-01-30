using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

public static class Validator
{
    private static Dictionary<Type, List<PropertyInfo>> cachedProps = new Dictionary<Type, List<PropertyInfo>>();

    public static bool TryValidateObject(UnityEngine.Object _object)
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
                return false;
            }
        }

        return true;
    }

    private static List<PropertyInfo> GetPropertiesWithValidationAttributes(UnityEngine.Object _object)
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

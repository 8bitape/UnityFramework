using UnityEngine;

namespace UnityFramework.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsValidObject(this object _object)
        {
            return Validator.TryValidateObject(_object);
        }
    }
}

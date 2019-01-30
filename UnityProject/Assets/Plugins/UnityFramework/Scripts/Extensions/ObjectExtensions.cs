using UnityEngine;

namespace UnityFramework.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsValidObject(this Object _object)
        {
            return Validator.TryValidateObject(_object);
        }
    }
}

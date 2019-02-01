using System;
using System.ComponentModel.DataAnnotations;

namespace UnityFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]

    public class RequiredPropertyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            if (value.ToString() == "null")
            {
                return false;
            }

            return true;
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace UnityFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]

    public class ValidateObjectAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return Validator.TryValidateObject(value);
        }
    }
}

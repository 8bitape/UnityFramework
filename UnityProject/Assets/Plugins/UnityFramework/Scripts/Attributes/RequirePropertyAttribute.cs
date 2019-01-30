using System;
using System.ComponentModel.DataAnnotations;

namespace UnityFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]

    public class RequiredPropertyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value.ToString() != "null" ? true : false;
        }
    }
}

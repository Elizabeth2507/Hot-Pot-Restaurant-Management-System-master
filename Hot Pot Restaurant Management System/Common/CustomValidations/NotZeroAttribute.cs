using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Common.CustomValidations
{
    public class NotZeroAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            var valueType = value.GetType();
            if (!valueType.IsValueType)
                return false;

            return !value.Equals(Activator.CreateInstance(valueType));
        }

        public override string FormatErrorMessage(string name)
        {
            return "Doesn't exist" + name;
        }
    }
}
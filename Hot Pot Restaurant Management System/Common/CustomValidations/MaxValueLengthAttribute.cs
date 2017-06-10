using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hot_Pot_Restaurant_Management_System.Common.CustomValidations
{
    public class MaxValueLengthAttribute : ValidationAttribute
    {
        private int maxLength;

        public MaxValueLengthAttribute(int maxLength)
        {
            this.maxLength = maxLength;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            return value.ToString().Length <= maxLength;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("{0}Can not be greater than {1} characters", name, maxLength.ToString());
        }
    }
}
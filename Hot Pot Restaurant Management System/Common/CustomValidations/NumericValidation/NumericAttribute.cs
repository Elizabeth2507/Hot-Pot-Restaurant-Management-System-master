using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Hot_Pot_Restaurant_Management_System.Common.CustomValidations.NumericValidation
{
    internal class NumericAttribute : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            Regex regex = new Regex(@"\d+");
            return regex.IsMatch(value.ToString());
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("{0}Need a valid number", name);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule { ValidationType = "number", ErrorMessage = this.FormatErrorMessage(metadata.DisplayName) };
        }
    }
}

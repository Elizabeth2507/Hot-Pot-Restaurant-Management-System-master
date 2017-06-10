using Hot_Pot_Restaurant_Management_System.Common.CustomValidations.NumericValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hot_Pot_Restaurant_Management_System.Common.CustomValidations
{
    public class FilterableClientDataTypeModelValidatorProvider : ClientDataTypeModelValidatorProvider
    {
        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context)
        {
            var allValidators = base.GetValidators(metadata, context);
            var validators = new List<ModelValidator>();

            foreach (var v in allValidators)
            {
                if (v.GetType().Name != "NumericModelValidator")
                {
                    validators.Add(v);
                }
                else
                {
                    NumericAttribute attribute = new NumericAttribute { ErrorMessage = "{0}Need a valid number" };
                    DataAnnotationsModelValidator validator = new DataAnnotationsModelValidator(metadata, context, attribute);

                    validators.Add(validator);
                }
            }

            return validators;
        }
    }
}
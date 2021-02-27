using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace job_application_project.Validation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class ValidSalaryAttribute : ValidationAttribute/*, IClientModelValidator*/
    {
        private readonly string sfstring;
        public ValidSalaryAttribute(string sf)
        {
            sfstring = sf;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var salaryto = (decimal?)value;

            var salaryfrom_property = validationContext.ObjectType.GetProperty(sfstring);
            if (salaryfrom_property == null)
                throw new ArgumentException("Property with this name not found");

            var salaryfrom = (decimal?)salaryfrom_property.GetValue(validationContext.ObjectInstance);

            if (salaryto == null || salaryfrom == null) //if one salary is null other salary can be everything
                return ValidationResult.Success;

            if (salaryfrom > salaryto)
                return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            var error = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-error", error);
        }
    }
}

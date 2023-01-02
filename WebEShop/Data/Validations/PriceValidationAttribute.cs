using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace System.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    //[__DynamicallyInvokable]
    sealed public class PriceValidationAttribute: ValidationAttribute
    {
        private double _minValue;
        private double _maxValue;
        public PriceValidationAttribute(double minValue, double maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public override bool IsValid(object value) { //IsValid(double minValue, double maxValue)
        {
            
            bool isValid = true;

            if((double)value < _minValue || (double)value > _maxValue)
            {
                isValid = false;
            }
            return isValid;




            //if (value < decimal.Zero)
            //{
            //    isValid = false;
            //}

            //if (isValid)
            //{
            //    return ValidationResult.Success;
            //}
            //else
            //{
            //    return new ValidationResult(
            //        string.Format("The field {0} must be greater than or equal to 0.", context.MemberName),
            //        new List<string>() { context.MemberName });
            //}
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, name);
        }
    }
}
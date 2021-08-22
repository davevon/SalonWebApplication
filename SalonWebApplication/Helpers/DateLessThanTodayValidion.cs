using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Helpers
{    
    public class DateLessThanTodayValidion : ValidationAttribute
    {
        private string _errorMessage { get; set; }
        public DateLessThanTodayValidion(string errorMessage)
        {
            _errorMessage = errorMessage;
        }
        public override string FormatErrorMessage(string name)
        {
            return _errorMessage;
        }

        protected override ValidationResult IsValid(object objValue,
                                                       ValidationContext validationContext)
        {
            var dateValue = Convert.ToDateTime(objValue);

            //alter this as needed. I am doing the date comparison if the value is not null

            if (dateValue.Date >= DateTime.Now.Date)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }
    }
}

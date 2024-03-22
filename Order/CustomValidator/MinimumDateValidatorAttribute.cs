using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace OrderSolution.CustomValidator
{
     /*
      * this class is used to validate the minimum date of the order
      * the default minimum date is yesterday
      * and the default maximum date is today
      */
    public class MinimumDateValidatorAttribute : ValidationAttribute
    {
        public string? MinimumDate { get; set; } 
        public string? MaximumDate { get; set; }
        public string DefualtErrorMessage { get; set; } = "Order date should be greater than or equal to {1} and should be less than or equal {0}";
        // the defualt constructor that set the minimum date to yesterday and the maximum date to today
        public MinimumDateValidatorAttribute() {
            // minimum date is yesterday
            MinimumDate = Convert.ToString(System.DateTime.Today.AddDays(-1));
            // maximum date is today
            MaximumDate = Convert.ToString(System.DateTime.Today);
        }
        // the constructor that set the minimum date to the given date
        public MinimumDateValidatorAttribute(string minDate)
        {
            MinimumDate = minDate;
        }
        // the constructor that set the minimum date to the given date and the maximum date to the given date
        public MinimumDateValidatorAttribute(string minDate , string maxDate)
        {
            MinimumDate = minDate;
            MaximumDate = maxDate;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                // get order date
                DateTime? OrderDate = (DateTime)value;                
                if (MinimumDate != null)
                {
                    DateTime? MinimumDateValue = Convert.ToDateTime(MinimumDate);
                    if (OrderDate < MinimumDateValue)
                    {
                        return new ValidationResult(string.Format(ErrorMessage?? DefualtErrorMessage,MinimumDate));
                    }
                    if(MaximumDate != null)
                    {
                        DateTime? MaximumDateValue = Convert.ToDateTime(MaximumDate);
                        if (OrderDate > MaximumDateValue)
                        {
                            return new ValidationResult(string.Format(ErrorMessage?? DefualtErrorMessage, MaximumDateValue, MinimumDateValue));
                        }
                    }
                    return ValidationResult.Success;
                }
                // after this is null
            }
            return null;
        }
    }
}

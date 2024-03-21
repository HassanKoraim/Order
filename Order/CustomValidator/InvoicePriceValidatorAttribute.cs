using System.ComponentModel.DataAnnotations;
using OrderSolution.Models;
using System.Reflection;
using System.Collections.Generic;

namespace OrderSolution.CustomValidator
{
    public class InvoicePriceValidatorAttribute : ValidationAttribute
    {
        public string defaultMessageError { get; set; } =
            "Invoice Price should be equal to the total cost of all products (i.e. {0}) in the order.";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                // get invoice price
                double invoicePrice = (double)value;
                // get other property
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(nameof(Order.product));
                if (otherProperty != null)
                {
                    // get products
                    List<Products>? products = (List<Products>)otherProperty.GetValue(validationContext.ObjectInstance);
                   if (products != null)
                    {
                        double? total = 0;
                        foreach (Products product in products)
                        {
                            total += product.Price * product.Quantity;
                        }
                        if (invoicePrice != total)
                        {
                            return new ValidationResult(ErrorMessage ?? defaultMessageError);
                        }else
                        {
                            return ValidationResult.Success;
                        }
                    }
                }
            }
            return null;
            
        }
    }
}

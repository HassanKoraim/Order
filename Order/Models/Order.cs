using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrderSolution.CustomValidator;
using System.ComponentModel.DataAnnotations;

namespace OrderSolution.Models
{
    public class Order
    {
        [BindNever]
        public int? OrderNo { get; set; }
        [Required(ErrorMessage = "{0} should be applied")]
        [Display(Name = "Order Date")]
        [MinimumDateValidatorAttribute]
        public DateTime? OrderDate { get; set; }
        [Required(ErrorMessage = "{0} should be applied")]
        [Display(Name = "Invoice Price")]
        [InvoicePriceValidator]
        public double? InvoicePrice { get; set; }
        [Required(ErrorMessage = "{0} should be applied")]
        public List<Products>? product { get; set; } 
        public override string ToString()
        {
            return $"OrderNo: {OrderNo}";
        }
    }
}

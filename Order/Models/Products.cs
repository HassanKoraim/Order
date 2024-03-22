using System.ComponentModel.DataAnnotations;

namespace OrderSolution.Models
{
    public class Products
    {
        [Required(ErrorMessage = "{0} should be applied")]
        [Display(Name = "Product Code")]
        public int? ProductCode { get; set; }
        [Required(ErrorMessage = "{0} should be applied")]
        public double? Price { get; set; }
        [Required(ErrorMessage = "{0} should be applied")]
        public int? Quantity { get; set; }
    }
}
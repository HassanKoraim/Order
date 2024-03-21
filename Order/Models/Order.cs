using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrderSolution.CustomValidator;

namespace OrderSolution.Models
{
    public class Order
    {
        [BindNever]
        public int? OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
        [InvoicePriceValidator]
        public double? InvoicePrice { get; set; }
        public List<Products>? product { get; set; } 
        public override string ToString()
        {
            return $"OrderNo: {OrderNo}";
        }
    }
}

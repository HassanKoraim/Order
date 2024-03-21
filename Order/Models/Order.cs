﻿namespace Ordersolution.Models
{
    public class Order
    {
        public int? OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public double InvoicePrice { get; set; }
        public List<Product>? product { get; set; } 
        public override string ToString()
        {
            return $"OrderNo: {OrderNo}";
        }
    }
}

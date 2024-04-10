using NorthwindDbTest_CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindDbTest_CSharp.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } 
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}
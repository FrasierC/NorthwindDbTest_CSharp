using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindDbTest_CSharp.Models
{
    [Serializable]
    public class OrderDetail
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
    }
}
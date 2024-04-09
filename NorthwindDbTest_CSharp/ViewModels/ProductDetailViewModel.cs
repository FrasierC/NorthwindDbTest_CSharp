using NorthwindDbTest_CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindDbTest_CSharp.ViewModels
{
    public class ProductDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public bool IsAvailable { get; set; }
        public int ReorderLevel { get; set; }
        public Supplier Supplier { get; set; }
        public Category Category { get; set; }

        public HtmlString GetFormatAddress()
        {
            if (Supplier == null || Supplier.Address == null)
            {
                return new HtmlString("NA");
            }

            if (Supplier.Address.Region.ToUpper() == "NULL")
            {
                Supplier.Address.Region = "";
            }

            return new HtmlString($@"{Supplier.Address.Street} <br /> 
                      {Supplier.Address.Region} {Supplier.Address.City} {Supplier.Address.PostalCode} <br />
                      {Supplier.Address.Country}");
        }

    }
}
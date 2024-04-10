using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindDbTest_CSharp.Models
{
    [Serializable]
    public class Customer
    {   
        public string Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public Address Address { get; set; }
    }
}
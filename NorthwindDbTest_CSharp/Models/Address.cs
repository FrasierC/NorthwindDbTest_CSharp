using System;

namespace NorthwindDbTest_CSharp.Models
{
    [Serializable]
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }
}
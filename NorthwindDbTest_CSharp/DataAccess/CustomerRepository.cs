using NorthwindDbTest_CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindDbTest_CSharp.DataAccess
{
    internal class CustomerRepository : BaseRepository<Customer>
    {
        public override string Endpoint { get => NorthwindApiEndpoints.Customers; }
    }
}
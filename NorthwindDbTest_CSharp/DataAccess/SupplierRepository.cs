using NorthwindDbTest_CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindDbTest_CSharp.DataAccess
{
    internal class SupplierRepository : BaseRepository<Supplier>
    {
        public override string Endpoint {get => NorthwindApiEndpoints.Suppliers; }
    }
}
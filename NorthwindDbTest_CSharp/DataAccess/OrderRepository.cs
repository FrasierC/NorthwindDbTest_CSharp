using NorthwindDbTest_CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindDbTest_CSharp.DataAccess
{
    internal class OrderRepository : BaseRepository<Order>
    {
        public override string Endpoint { get => NorthwindApiEndpoints.Orders; }

        /// <summary>
        /// Get all orders that have the given product id in their details.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>List of orders</returns>
        public IEnumerable<Order> GetOrdersByProductId(int productId)
        {
            var orders = GetAll();
            orders = orders.Where(o => o.Details.Any(d => d.ProductId == productId));

            return orders;
        }
    }
}
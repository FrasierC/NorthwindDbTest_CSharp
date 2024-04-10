using NorthwindDbTest_CSharp.DataAccess;
using NorthwindDbTest_CSharp.Models;
using NorthwindDbTest_CSharp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindDbTest_CSharp.Services
{
    public class OrderViewModelService : IViewModelService<OrderViewModel, Order>
    {
        private int productId; 
        public OrderViewModelService(int productId)
        {
            this.productId = productId;
        }

        /// <summary>
        /// Creates a <see cref="OrderViewModel"/> from a provided <see cref="Order"/> model.
        /// </summary>
        /// <param name="source">The <see cref="Order"/> model.</param>
        /// <returns></returns>
        public OrderViewModel CreateViewModel(Order source)
        {
            using (CustomerRepository customerRepo = new CustomerRepository())
            {
                var customer = customerRepo.GetById(source.CustomerId);
                return CreateViewModel(source, new List<Customer> { customer });
            }

        }

        /// <summary>
        /// Creates a <see cref="OrderViewModel"/> from a provided <see cref="Order"/> model.
        /// </summary>
        /// <param name="source">The <see cref="Order"/> model.</param>
        /// <param name="customers">The list of all <see cref="Customer"/> models</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public OrderViewModel CreateViewModel(Order source, IEnumerable<Customer> customers)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }

            // Get customer data.
            Customer customer = null;
            customer = customers.Where(c => c.Id == source.CustomerId).FirstOrDefault();


            // Parse dates and check for null dates
            DateTime parseDate = DateTime.UtcNow;
            DateTime? orderDate = null;
            DateTime? requiredDate = null;
            DateTime? shippedDate = null;

            if (DateTime.TryParse(source.OrderDate, out parseDate))
            {
                orderDate = parseDate;
            }
            if (DateTime.TryParse(source.RequiredDate, out parseDate))
            {
                requiredDate = parseDate;
            }
            if (DateTime.TryParse(source.ShippedDate, out parseDate))
            {
                shippedDate = parseDate;
            }

            // Retrieve the order details for this product.
            OrderDetail detail = source.Details.Where(d => d.ProductId == this.productId).FirstOrDefault();

            return new OrderViewModel()
            {
                Id = source.Id,
                CustomerName = customer != null ? customer.CompanyName : "N/A",
                OrderDate = orderDate,
                RequiredDate = requiredDate,
                ShippedDate = shippedDate,
                Freight = source.Freight,
                Quantity = detail.Quantity,
                UnitPrice = detail.UnitPrice,
                Discount = detail.Discount,
                Total = (detail.UnitPrice - detail.Discount) * detail.Quantity,
            };
        }

        /// <summary>
        /// Creates a collection of <see cref="OrderViewModel"/> from a provided collection of <see cref="Order"/> models.
        /// </summary>
        /// <param name="source">The collection of <see cref="Order"/> models.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<OrderViewModel> CreateViewModel(IEnumerable<Order> source)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }

            // Fetch entire list to prevent individual calls for each order.
            IEnumerable<Customer> customers = null;
            using (CustomerRepository customerRepo = new CustomerRepository())
            {
                customers = customerRepo.GetAll();
            }

            return source.Select(prod => CreateViewModel(prod, customers));
        }
    }
}
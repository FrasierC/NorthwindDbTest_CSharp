using NorthwindDbTest_CSharp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls.Expressions;

namespace NorthwindDbTest_CSharp.DataAccess
{
    internal class ProductsRepository : BaseRepository<Product>
    {
        /// <summary>
        /// Used to apply filters to product results.
        /// </summary>
        public struct Filter
        {
            // Parameter for searching for a product by Name.
            public string NameSearch;

            // If true show only the products that are available. 
            public bool ShowOnlyAvailable;

            public Filter(string search = null, bool showOnlyAvailable = false)
            {
               NameSearch = search;
               ShowOnlyAvailable = showOnlyAvailable;
            }
        }

        /// <summary>
        /// Gets or sets the Northwind API endpoint used by this repository.
        /// </summary>
        public override string Endpoint { get => NorthwindApiEndpoints.Products; }

        /// <summary>
        /// Get a filtered result of products.
        /// </summary>
        /// <param name="filter">Filter Parameters</param>
        /// <returns>filtered list of products.</returns>
        public IEnumerable<Product> GetAllWithFilter(Filter filter) 
        {
            var products = GetAll();

            if (filter.NameSearch != null && filter.NameSearch != string.Empty) 
            {
                products = products.Where(p => p.Name.StartsWith(filter.NameSearch, System.StringComparison.CurrentCultureIgnoreCase));
            }

            if (filter.ShowOnlyAvailable)
            {
                products = products.Where(p => !p.Discontinued);
            }


            return products;
        }

        /// <summary>
        /// Gets a count of all products.
        /// </summary>
        /// <returns>Count of all Products</returns>
        public int AllCount()
        {
            var products = GetAll();
            return products.Count();
        }
    }
}
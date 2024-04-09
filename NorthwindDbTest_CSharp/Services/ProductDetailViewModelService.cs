using NorthwindDbTest_CSharp.DataAccess;
using NorthwindDbTest_CSharp.Models;
using NorthwindDbTest_CSharp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindDbTest_CSharp.Services
{
    public class ProductDetailViewModelService : IViewModelService<ProductDetailViewModel, Product>
    {
        public ProductDetailViewModelService()
        {

        }

        /// <summary>
        /// Creates a <see cref="ProductDetailViewModel"/> from a provided <see cref="Product"/> model.
        /// </summary>
        /// <param name="source">The <see cref="Product"/> model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public ProductDetailViewModel CreateViewModel(Product source)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }

            #region Fetch data if is was not part of the initial API call.
            Category category = source.Category;
            if (category == null)
            {
                using(CategoryRepository catRepo = new CategoryRepository())
                {
                    category = catRepo.GetById(source.CategoryId);
                }
            }

            Supplier supplier = source.Supplier;
            if (supplier == null)
            {
                using(SupplierRepository supRepo = new SupplierRepository())
                {
                    supplier = supRepo.GetById(source.SupplierId);
                }
            }
            #endregion

            return new ProductDetailViewModel()
            {
                Id = source.Id,
                Name = source.Name,
                IsAvailable = !source.Discontinued,
                QuantityPerUnit = source.QuantityPerUnit,
                UnitsOnOrder = source.UnitsOnOrder,
                UnitPrice = source.UnitPrice,
                UnitsInStock = source.UnitsInStock,
                Supplier = supplier,
                Category = category,
            };
        }

        /// <summary>
        /// Creates a collection of <see cref="ProductDetailViewModel"/> from a provided collection of <see cref="Product"/> models.
        /// </summary>
        /// <param name="source">The collection of <see cref="Product"/> models.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<ProductDetailViewModel> CreateViewModel(IEnumerable<Product> source)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }

            return source.Select(prod => CreateViewModel(prod));
        }
    }
}
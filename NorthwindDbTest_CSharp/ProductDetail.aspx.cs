using NorthwindDbTest_CSharp.DataAccess;
using NorthwindDbTest_CSharp.Models;
using NorthwindDbTest_CSharp.Services;
using NorthwindDbTest_CSharp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthwindDbTest_CSharp
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        protected int ID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            int productID = 0;
            int.TryParse(Page.RouteData.Values["id"] as string, out productID);
            ID = productID;
        }

        public ProductDetailViewModel GetProduct()
        {
            using (ProductsRepository productRepo = new ProductsRepository())
            {
                var productViewModelService = new ProductDetailViewModelService();
                var product = productRepo.GetById(ID);
                return productViewModelService.CreateViewModel(product);
            }

        }
    }
}
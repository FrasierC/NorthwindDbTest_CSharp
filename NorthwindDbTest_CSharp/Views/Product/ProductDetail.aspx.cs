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

namespace NorthwindDbTest_CSharp.Views
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        protected int productId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!int.TryParse(Page.RouteData.Values["id"] as string, out productId))
            {
                HttpNotFound();
            }

            if (!Page.IsPostBack)
            {
                LoadOrders();
            }
        }

        private void HttpNotFound()
        {
            Response.Clear();
            Response.StatusCode = 404;
            Response.End();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        public ProductDetailViewModel GetProduct()
        {
            using (ProductsRepository productRepo = new ProductsRepository())
            {
                var productViewModelService = new ProductDetailViewModelService();
                var product = productRepo.GetById(productId);
                if(product == null)
                {
                    HttpNotFound();
                }
                return productViewModelService.CreateViewModel(product);
            }

        }

        private void LoadOrders()
        {

            using (OrderRepository orderRepo = new OrderRepository())
            {
                var orders = orderRepo.GetOrdersByProductId(productId);

               if (orders != null)
                {
                    var orderViewModelService = new OrderViewModelService(productId);
                    gvOrders.DataSource = orderViewModelService.CreateViewModel(orders).OrderByDescending(o => o.OrderDate);
                    gvOrders.DataBind();
                }
            }

        }

        protected void gvOrders_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;

            if ((gv.ShowHeader == true && gv.Rows.Count > 0) || (gv.ShowHeaderWhenEmpty == true))
            {
                // Force GridView to use <thead> instead of <tbody>
                // This allows the Bootstrap styles to be applied appropriately
                gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            if (gv.ShowFooter == true && gv.Rows.Count > 0)
            {
                // Force GridView to use <tfoot> instead of <tbody>
                // This allows the Bootstrap styles to be applied appropriately
                gv.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}
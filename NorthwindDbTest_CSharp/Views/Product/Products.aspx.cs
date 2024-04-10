using NorthwindDbTest_CSharp.DataAccess;
using NorthwindDbTest_CSharp.Models;
using NorthwindDbTest_CSharp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthwindDbTest_CSharp.Views
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadProducts();
            }
        }

        /// <summary>
        /// Load all Products into the grid.
        /// </summary>
        private void LoadProducts()
        {

            var products = GetProducts();

            if (products != null)
            {
                ProductViewModelService productViewModelService = new ProductViewModelService();
                gvProducts.DataSource = productViewModelService.CreateViewModel(products).OrderBy(x => x.Name);
                gvProducts.DataBind();
            }

        }

        protected void gvProducts_PreRender(object sender, EventArgs e)
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

        protected void gvProducts_DataBound(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            using (ProductsRepository productRepo = new ProductsRepository())
            {
                var allCount = productRepo.AllCount();
                var msg = "";
                if(gv.Rows.Count > 0)
                {
                    msg = $"Showing 1 to {gv.Rows.Count} of {allCount} entries";
                }
                else
                {
                    msg = $"Showing 0 of {allCount} entries";
                }

                lblRecordCount.Text = msg;
                
            }
        }

        protected void products_filter(object sender, EventArgs e)
        {
            LoadProducts();
        }
        /// <summary>
        /// Gets a list of projects with the filtered fields applied.
        /// </summary>
        /// <returns>List of filtered products.</returns>
        protected IEnumerable<Product> GetProducts()
        {
            using (ProductsRepository productRepo = new ProductsRepository())
            {
                var filter = new ProductsRepository.Filter(txtSearch.Text, chkAvailableOnly.Checked);
                var products = productRepo.GetAllWithFilter(filter);
                return products;
            }
        }
    }
}
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace NorthwindDbTest_CSharp
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapPageRoute("Products", "products", "~/Views/Product/Products.aspx");
            RouteTable.Routes.MapPageRoute("Product", "product/{id}", "~/Views/Product/ProductDetail.aspx");

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
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
            RouteTable.Routes.MapPageRoute("Product", "product/{id}", "~/ProductDetail.aspx");

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
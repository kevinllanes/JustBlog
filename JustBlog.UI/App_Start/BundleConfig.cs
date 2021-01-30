using System.Web;
using System.Web.Optimization;

namespace JustBlog.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                         "~/Scripts/jquery-3.5.1.js",
                         "~/Scripts/blogs/jquery-ui.min.js", 
                         "~/Scripts/blogs/jquery.dataTables.min.js",
                         "~/Scripts/blogs/dataTables.bootstrap4.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                     "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/layout").Include(
                      "~/Scripts/toggle.js"));

            bundles.Add(new ScriptBundle("~/bundles/blogs").Include(
                     "~/Scripts/JustBlog/page.js",
                     "~/Scripts/JustBlog/post.js",
                     "~/Scripts/JustBlog/category.js",
                     "~/Scripts/JustBlog/dashboard.js",
                     "~/Scripts/moment.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                       "~/Content/datatables/dataTables.bootstrap4.min.css",
                       "~/Content/font-awesome.css",
                      "~/Content/header.css",
                      "~/Content/site.css"));
        }
    }
}

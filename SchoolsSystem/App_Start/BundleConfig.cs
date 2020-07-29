using System.Web;
using System.Web.Optimization;

namespace SchoolsSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/AdminAsset/assets/libs/jquery/dist/jquery.min.js",
                        "~/AdminAsset/assets/libs/popper.js/dist/umd/popper.min.js",
                        "~/AdminAsset/assets/libs/bootstrap/dist/js/bootstrap.min.js",
                        "~/AdminAsset/assets/libs/perfect-scrollbar/dist/perfect-scrollbar.jquery.min.js",
                        "~/AdminAsset/assets/extra-libs/sparkline/sparkline.js",
                        "~/AdminAsset/dist/js/waves.js",
                        "~/AdminAsset/assets/extra-libs/DataTables/datatables.min.js",
                        "~/AdminAsset/dist/js/sidebarmenu.js",
                        "~/Scripts/toastr.js",
                        "~/AdminAsset/dist/js/custom.min.js",
                        "~/AdminAsset/assets/libs/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js" ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/AdminAsset/dist/css").Include(
                      "~/AdminAsset/assets/libs/flot/css/float-chart.css",
                      "~/AdminAsset/assets/libs/datatables.net-bs4/css/dataTables.bootstrap4.css",
                      "~/Content/toastr.css",
                      "~/AdminAsset/dist/css/style.min.css",
                      "~/AdminAsset/assets/libs/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css" ));
        }
    }
}

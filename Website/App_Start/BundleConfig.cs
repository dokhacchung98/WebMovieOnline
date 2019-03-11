using System.Web;
using System.Web.Optimization;

namespace Website
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-easing").Include(
                        "~/Scripts/jquery.easing.min.js"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jsadmin").Include(
                    "~/Scripts/Admin/sb-admin-2.js"
                    ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/fontawesome/all.css"));
            bundles.Add(new StyleBundle("~/Content/admincss").Include(
                    "~/Content/sb-admin-2.min.css",
                      "~/Content/fontawesome/all.css"
                ));
            bundles.Add(new StyleBundle("~/Content/unauthorized").Include(
                    "~/Content/unauthorized/unauthorized.css"
                ));

            bundles.Add(new StyleBundle("~/Content/style-bootstrap3").Include(
                    "~/Content/stylewebsite/bootstrap.css",
                    "~/Content/stylewebsite/style.css",
                    "~/Content/stylewebsite/contactstyle.css",
                    "~/Content/stylewebsite/faqstyle.css",
                    "~/Content/stylewebsite/single.css",
                    "~/Content/stylewebsite/medile.css",
                    "~/Content/stylewebsite/jquery.slidey.min.css",
                    "~/Content/stylewebsite/popuo-box.css",
                    "~/Content/stylewebsite/owl.carousel.css",
                    "~/Content/fontawesome/all.css"
                ));

            bundles.Add(new ScriptBundle("~/Script/script-website").Include(
                    "~/Scripts/ScriptWebsite/jquery-2.1.4.min.js",
                    "~/Scripts/ScriptWebsite/owl.carousel.js",
                    "~/Scripts/ScriptWebsite/move-top.js",
                    "~/Scripts/ScriptWebsite/easing.js",
                    "~/Scripts/ScriptWebsite/jquery.slidey.js",
                    "~/Scripts/ScriptWebsite/jquery.dotdotdot.min.js",
                    "~/Scripts/ScriptWebsite/bootstrap.min.js"
                ));

        }
    }
}
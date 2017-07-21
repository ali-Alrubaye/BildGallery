using System.Web.Optimization;

namespace Gallery_UI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/migrate").Include(
            //            "~/Scripts/jquery-migrate-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/jqueryunobtrusive").Include(
                "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui")
                .Include("~/Scripts/jquery-ui-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/myScript/GallerSecript").Include(
                "~/myScript/ImgPost.js",
                "~/myScript/ImgGet.js",
                "~/myScript/AlbGet.js",
                "~/myScript/AlbPost.js"
            ));
            //"~/myScript/AlbPost.js",
            //           "~/myScript/albumGet.js"
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css",
                "~/myScript/Img.css"));

            //bundles.Add(new ScriptBundle("~/bundles/mybundle").Include(
            //    "~/Scripts/jquery-1.7.1.min.js",
            //    "~/Scripts/jquery-ui-1.8.16.min.js",
            //    "~/Scripts/jquery.validate.min.js",
            //    "~/Scripts/jquery.validate.unobtrusive.min.js",
            //    "~/Scripts/jquery.unobtrusive-ajax.min.js",
            //    "~/Scripts/jquery-ui-timepicker-addon.js"));
        }
    }
}
using System.Web;
using System.Web.Optimization;

namespace QuoteCalculator
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/datatable/jquery.dataTables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/Table").Include(
                        "~/Scripts/datatable/jquery.dataTables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/jquery/jquery.min.js",
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/jquery.gritter.js",
                      "~/Scripts/gritter.js"));

            bundles.Add(new ScriptBundle("~/bundles/SystemJS").Include(
                        "~/Scripts/SystemJS.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/jquery.gritter.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css2").Include(
                      "~/Content/jquery.gritter.css",
                      "~/Content/site.css"));

            //Default
            bundles.Add(new StyleBundle("~/Default/theme").Include("~/Content/bootstrap.css"));

            //Cerulean
            bundles.Add(new StyleBundle("~/Cerulean/theme").Include("~/Content/Cerulean/bootstrap.css"));

            //Cosmo
            bundles.Add(new StyleBundle("~/Cosmo/theme").Include("~/Content/Cosmo/bootstrap.css"));

            //Flatly
            bundles.Add(new StyleBundle("~/Flatly/theme").Include("~/Content/Flatly/bootstrap.css"));

            //Spacelab
            bundles.Add(new StyleBundle("~/Spacelab/theme").Include("~/Content/Spacelab/bootstrap.css"));

            //Cyborg
            bundles.Add(new StyleBundle("~/Cyborg/theme").Include("~/Content/Cyborg/bootstrap.css"));

            //Darkly
            bundles.Add(new StyleBundle("~/Darkly/theme").Include("~/Content/Darkly/bootstrap.css"));

            //Journal
            bundles.Add(new StyleBundle("~/Journal/theme").Include("~/Content/Journal/bootstrap.css"));

            //Lumen
            bundles.Add(new StyleBundle("~/Lumen/theme").Include("~/Content/Lumen/bootstrap.css"));

            //Paper
            bundles.Add(new StyleBundle("~/Paper/theme").Include("~/Content/Paper/bootstrap.css"));

            //Readable
            bundles.Add(new StyleBundle("~/Readable/theme").Include("~/Content/Readable/bootstrap.css"));

            //Sandstone
            bundles.Add(new StyleBundle("~/Sandstone/theme").Include("~/Content/Sandstone/bootstrap.css"));

            //Simplex
            bundles.Add(new StyleBundle("~/Simplex/theme").Include("~/Content/Simplex/bootstrap.css"));

            //Slate
            bundles.Add(new StyleBundle("~/Slate/theme").Include("~/Content/Slate/bootstrap.css"));

            //Superhero
            bundles.Add(new StyleBundle("~/Superhero/theme").Include("~/Content/Superhero/bootstrap.css"));

            //United
            bundles.Add(new StyleBundle("~/United/theme").Include("~/Content/United/bootstrap.css"));

            //Yeti
            bundles.Add(new StyleBundle("~/Yeti/theme").Include("~/Content/Yeti/bootstrap.css"));
        }
    }
}

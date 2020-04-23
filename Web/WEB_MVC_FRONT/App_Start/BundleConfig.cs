using System.Web;
using System.Web.Optimization;

namespace WEB_MVC_FRONT
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css")); 
          
            // Añado el js que yo he creado
            bundles.Add(new ScriptBundle("~/bundles/MenuLateral").Include(
                     "~/barra_lateral/gulpfile.js",
                     "~/barra_lateral/src/js/main.js"));

            bundles.Add(new StyleBundle("~/barra_lateral/css").Include(
                     "~/barra_lateral/src/css/*.css")); // Añado el que yo he creado


            bundles.Add(new StyleBundle("~/barra_lateral/sass").Include(
                     "~/barra_lateral/src/sass/*.scss")); // Añado el que yo he creado
        }
    }
}

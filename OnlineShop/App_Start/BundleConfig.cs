using System.Web;
using System.Web.Optimization;

namespace OnlineShop
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //js 
            bundles.Add(new ScriptBundle("~/bundles/jscore").Include(
                     
                        "~/assets/client/js/jquery-1.11.3.min.js",
                       
                        "~/assets/client/js/jquery-ui.js",
                        "~/assets/client/js/bootstrap.min.js",
                     //   "~/assets/client/js/jquery-1.7.2.min.js",
                        "~/assets/client/js/move-top.js",
                        "~/assets/client/js/easing.js",
                        "~/assets/client/js/startstop-slider.js",
                     //   "~/assets/client/nivo-slider/demo/scripts/jquery-1.9.0.min.js",
                        "~/assets/client/nivo-slider/jquery.nivo.slider.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/controller").Include(
                "~/assets/client/js/controller/baseController.js"
               
                ));
            //css o day
        
          bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/assets/client/css/bootstrap.css",
                      "~/assets/client/css/social-buttons.css",
                      "~/assets/client/css/font-awesome.min.css",
                      "~/assets/client/css/bootstrap-theme.css",
                      "~/assets/client/css/jquery-ui.css",
                      "~/assets/client/css/style.css",
                       "~/assets/client/css/slider.css",//
                  "~/assets/client/nivo-slider/themes/default/default.css",
                 "~/assets/client/nivo-slider/themes/light/light.css",
                "~/assets/client/nivo-slider/themes/dark/dark.css",
                "~/assets/client/nivo-slider/themes/bar/bar.css",
                "~/assets/client/nivo-slider/nivo-slider.css",
                "~/assets/client/nivo-slider/demo/style1.css"

                      ));
         
            BundleTable.EnableOptimizations = true;
        }
    }
}

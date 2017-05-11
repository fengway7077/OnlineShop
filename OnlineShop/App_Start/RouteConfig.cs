using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Products All",
                url: "san-pham",//
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop.Controllers" }
            );


            routes.MapRoute(
                name: "Product Category",
                url: "san-pham/{metatitle}-{cateid}",//ProductController dung cateid
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop.Controllers" }
            );
            routes.MapRoute(
              name: "Product Detail",
              url: "chi-tiet/{metatitle}-{dtid}",//ProductController dung dtid
              defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
              namespaces: new[] { "OnlineShop.Controllers" }
          );
            routes.MapRoute(
              name: "About",
              url: "them-gio-hang",//trang khong co tham so gioi thieu
              defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
              namespaces: new[] { "OnlineShop.Controllers" }
          );
            routes.MapRoute(
              name: "Content",
              url: "tin-tuc",//trang khong co tham so tin tuc
              defaults: new { controller = "Content", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "OnlineShop.Controllers" }
          );
            routes.MapRoute(
             name: "Contact",
             url: "lien-he",//trang khong co tham so lien he
             defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "OnlineShop.Controllers" }
         );
            routes.MapRoute(
            name: "Login",
            url: "dang-nhap",//trang khong co tham so 
            defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
            namespaces: new[] { "OnlineShop.Controllers" }
        );
            routes.MapRoute(
           name: "Sign In",
           url: "dang-ky",//trang khong co tham so 
           defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
           namespaces: new[] { "OnlineShop.Controllers" }
       );
            routes.MapRoute(
           name: "Search",
           url: "tim-kiem",//trang khong co tham so
           defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
           namespaces: new[] { "OnlineShop.Controllers" }
       );
            routes.MapRoute(
             name: "Cart",
             url: "gio-hang",//trang khong co tham so
             defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "OnlineShop.Controllers" }
         );
            routes.MapRoute(
            name: "Payment",
            url: "thanh-toan",//trang khong co tham so
            defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
            namespaces: new[] { "OnlineShop.Controllers" }
        );
            routes.MapRoute(
              name: "Add Cart",
              url: "gioi-thieu",//trang khong co tham so
              defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "OnlineShop.Controllers" }
          );
            routes.MapRoute(
            name: "Payment Success",
            url: "hoan-thanh",//trang khong co tham so
            defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
            namespaces: new[] { "OnlineShop.Controllers" }
        );
            //Default luon de duoi cung
            routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "OnlineShop.Controllers" }//chi ra controller chay mat dinh
         );
        }
    }
}

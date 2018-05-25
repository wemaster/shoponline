using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Product More",
                url: "san-pham/{Metatitle}-{id}",
                defaults: new { controller = "Product", action = "ProductViewAll", id = UrlParameter.Optional },
                namespaces: new[] { "ShopOnline.Controllers" }
            );
            routes.MapRoute(
                name: "Product Detail",
                url: "chi-tiet/{Metatitle}-{id}",
                defaults: new { controller = "Product", action = "DetailView", id = UrlParameter.Optional },
                namespaces: new[] { "ShopOnline.Controllers" }
            );

            routes.MapRoute(
                name: "Add Cart",
                url: "add-cart",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new[] { "ShopOnline.Controllers" }
            );

            routes.MapRoute(
              name: "Update Cart",
              url: "Index",
              defaults: new { controller = "Cart", action = "Update", id = UrlParameter.Optional },
              namespaces: new[] { "ShopOnline.Controllers" }
          );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ShopOnline.Controllers" }
            );
        }
    }
}

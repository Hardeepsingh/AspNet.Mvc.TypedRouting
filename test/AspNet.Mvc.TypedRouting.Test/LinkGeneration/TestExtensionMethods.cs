using System;
using System.Linq.Expressions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace AspNet.Mvc.TypedRouting.Test.LinkGeneration
{
    public static class TestExtensionMethods
    {
        public class Site
        {
            public string Shortcut { get; set; }
        }

        public static string SiteAction<TController>(this IUrlHelper url, Expression<Action<TController>> action,
            Site site, RouteValueDictionary additionalRouteValues = null)
            where TController : Controller
        {
            additionalRouteValues = additionalRouteValues ?? new RouteValueDictionary();
            additionalRouteValues["SiteShortcut"] = site.Shortcut;

            var result = url.Action(action, additionalRouteValues);
            return result;
        }
    }
}
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ecom
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_PreSendRequestHeaders()
        {
            Response.Headers.Remove("Server");
            Response.Headers.Remove("X-AspNet-Version");
            Response.Headers.Remove("X-AspNetMvc-Version");
            Response.AddHeader("Strict-Transport-Security", "max-age=300");
            Response.AddHeader("X-Frame-Options", "SAMEORIGIN");
        }

        protected void Application_Start()
        {
            // Removing all the view engines
            ViewEngines.Engines.Clear();

            //Add Custom Razor Engine
            ViewEngines.Engines.Add(new CSharpRazorViewEngine());

            //ConfigureAntiForgeryTokens();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public class CSharpRazorViewEngine : RazorViewEngine
        {
            public CSharpRazorViewEngine()
            {
                base.AreaViewLocationFormats = new string[] {
                    "~/Areas/{2}/Views/{1}/{0}.cshtml",
                    "~/Areas/{2}/Views/Shared/{0}.cshtml" };
                base.AreaMasterLocationFormats = new string[] {
                    "~/Areas/{2}/Views/{1}/{0}.cshtml",
                    "~/Areas/{2}/Views/Shared/{0}.cshtml" };
                base.AreaPartialViewLocationFormats = new string[] {
                    "~/Areas/{2}/Views/{1}/{0}.cshtml",
                    "~/Areas/{2}/Views/Shared/{0}.cshtml" };
                base.ViewLocationFormats = new string[] {
                    "~/Views/{1}/{0}.cshtml",
                    "~/Views/Shared/{0}.cshtml" };
                base.MasterLocationFormats = new string[] {
                    "~/Views/{1}/{0}.cshtml",
                    "~/Views/Shared/{0}.cshtml" };
                base.PartialViewLocationFormats = new string[] {
                    "~/Views/{1}/{0}.cshtml",
                    "~/Views/Shared/{0}.cshtml" };

                base.FileExtensions = new string[] { "cshtml" };
            }

            private static string GlobalizeViewPath(ControllerContext controllerContext, string viewPath)
            {
                var request = controllerContext.HttpContext.Request;
                var lang = request.Cookies["language"];
                if (lang != null &&
                    !string.IsNullOrEmpty(lang.Value) &&
                    !string.Equals(lang.Value, "en", StringComparison.InvariantCultureIgnoreCase))
                {
                    string localizedViewPath = Regex.Replace(
                        viewPath,
                        "^~/Views/",
                        string.Format("~/Views/Globalization/{0}/",
                        lang.Value
                        ));
                    if (File.Exists(request.MapPath(localizedViewPath)))
                    {
                        viewPath = localizedViewPath;
                    }
                }
                return viewPath;
            }

            protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
            {
                partialPath = GlobalizeViewPath(controllerContext, partialPath);
                return base.CreatePartialView(controllerContext, partialPath);
            }

            protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
            {
                viewPath = GlobalizeViewPath(controllerContext, viewPath);
                return base.CreateView(controllerContext, viewPath, masterPath);
            }
        }

        /// <summary>
        /// Configures the anti-forgery tokens. See 
        /// http://www.asp.net/mvc/overview/security/xsrfcsrf-prevention-in-aspnet-mvc-and-web-pages
        /// </summary>
        private static void ConfigureAntiForgeryTokens()
        {
            // Rename the Anti-Forgery cookie from "__RequestVerificationToken" to "f". This adds a little security 
            // through obscurity and also saves sending a few characters over the wire. Sadly there is no way to change 
            // the form input name which is hard coded in the @Html.AntiForgeryToken helper and the 
            // ValidationAntiforgeryTokenAttribute to  __RequestVerificationToken.
            // <input name="__RequestVerificationToken" type="hidden" value="..." />
            AntiForgeryConfig.CookieName = "_f";

            // If you have enabled SSL. Uncomment this line to ensure that the Anti-Forgery 
            // cookie requires SSL to be sent across the wire. 
            // AntiForgeryConfig.RequireSsl = true;
        }
    }
}

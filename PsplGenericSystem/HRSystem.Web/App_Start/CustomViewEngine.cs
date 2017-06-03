using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRSystem.Web.App_Start
{
    public class CustomViewEngine : RazorViewEngine
    {
        private List<string> _plugins = new List<string>();

        public CustomViewEngine(List<string> pluginFolders)
        {
            _plugins = pluginFolders;

            ViewLocationFormats = GetViewLocations();
            MasterLocationFormats = GetMasterLocations();
            PartialViewLocationFormats = GetViewLocations();
        }

        public string[] GetViewLocations()
        {
            var views = new List<string>();
            views.Add("~/Views/{1}/{0}.cshtml");

            _plugins.ForEach(plugin =>
                views.Add("~/Modules/" + plugin + "/Views/{1}/{0}.cshtml")
            );
            return views.ToArray();
        }

        public string[] GetMasterLocations()
        {
            var masterPages = new List<string>();

            masterPages.Add("~/Views/Shared/{0}.cshtml");

            _plugins.ForEach(plugin =>
                masterPages.Add("~/Modules/" + plugin + "/Views/Shared/{0}.cshtml")
            );

            return masterPages.ToArray();
        }
    }
}
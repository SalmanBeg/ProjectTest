using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;
using System.Web.Mvc;

namespace HRSystem.Web.App_Start
{
    public class AssemblyVirtualPathProvider : VirtualPathProvider
    {
        private readonly Assembly assembly;
        private readonly IEnumerable<VirtualPathProvider> providers;

        public AssemblyVirtualPathProvider(Assembly assembly)
        {
            var engines = ViewEngines.Engines.OfType<VirtualPathProviderViewEngine>().ToList();

            this.providers = engines.Select(x => x.GetType().GetProperty("VirtualPathProvider", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(x, null) as VirtualPathProvider).Distinct().ToList();
            this.assembly = assembly;
        }

        public override CacheDependency GetCacheDependency(String virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            if (this.FindFileByPath(this.CorrectFilePath(virtualPath)) != null)
            {
                return (new AssemblyCacheDependency(assembly));
            }
            else
            {
                return (base.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart));
            }
        }

        public override Boolean FileExists(String virtualPath)
        {
            foreach (var provider in this.providers)
            {
                if (provider.FileExists(virtualPath) == true)
                {
                    return (true);
                }
            }

            var exists = this.FindFileByPath(this.CorrectFilePath(virtualPath)) != null;

            return (exists);
        }

        public override VirtualFile GetFile(String virtualPath)
        {
            var resource = null as Stream;

            foreach (var provider in this.providers)
            {
                var file = provider.GetFile(virtualPath);

                if (file != null)
                {
                    try
                    {
                        resource = file.Open();
                        return (file);
                    }
                    catch
                    {
                    }
                }
            }

            var resourceName = this.FindFileByPath(this.CorrectFilePath(virtualPath));

            return (new AssemblyVirtualFile(virtualPath, this.assembly, resourceName));
        }

        protected String FindFileByPath(String virtualPath)
        {
            var resourceNames = this.assembly.GetManifestResourceNames();

            return (resourceNames.SingleOrDefault(r => r.EndsWith(virtualPath, StringComparison.OrdinalIgnoreCase) == true));
        }

        protected String CorrectFilePath(String virtualPath)
        {
            return (virtualPath.Replace("~", String.Empty).Replace('/', '.'));
        }
    }

    public class AssemblyVirtualFile : VirtualFile
    {
        private readonly Assembly assembly;
        private readonly String resourceName;

        public AssemblyVirtualFile(String virtualPath, Assembly assembly, String resourceName)
            : base(virtualPath)
        {
            this.assembly = assembly;
            this.resourceName = resourceName;
        }

        public override Stream Open()
        {
            return (this.assembly.GetManifestResourceStream(this.resourceName));
        }
    }

    public class AssemblyCacheDependency : CacheDependency
    {
        private readonly Assembly assembly;

        public AssemblyCacheDependency(Assembly assembly)
        {
            this.assembly = assembly;
            this.SetUtcLastModified(File.GetCreationTimeUtc(assembly.Location));
        }
    }
}

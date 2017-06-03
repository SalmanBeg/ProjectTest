using HRSystem.Services.Interfaces;
using HRSystem.Services.Repositories;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HRSystem.Web.App_Start
{
    public static class IocConfigurator
    {
        public static void ConfigureIocUnityContainer()
        {
            IUnityContainer container = new UnityContainer();
            registerServices(container);
            DependencyResolver.SetResolver(new UnitDependencyResolver(container));
        }

        private static void registerServices(IUnityContainer container)
        {
            container.RegisterType<ICompanyDashboard, CompanyDashboard>();
            container.RegisterType<IAccounts, UserDetailsRepository>();
            container.RegisterType<IChat, ChatRepository>();
        }
    }

    public class UnitDependencyResolver : IDependencyResolver
    {
        private IUnityContainer _unityContainer;
        public UnitDependencyResolver(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _unityContainer.Resolve(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _unityContainer.ResolveAll(serviceType);
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ExternalServices.BO;
using ExternalServices.Interfaces;
using ExternalServices.Stubs;
using website.Controllers;

namespace website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteTable.Routes.MapMvcAttributeRoutes();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DependencyResolver.SetResolver(new BasicDependencyResolver());
        }

        public class BasicDependencyResolver : IDependencyResolver
        {
            public object GetService(Type serviceType)
            {
                //return serviceType == typeof(TariffController) ?
                //    new TariffController(new CustomerServiceStub(), new AccountsServiceStub(), new PackageServiceStub()) :
                //    null;

                return serviceType == typeof(TariffController) ?
                    new TariffController(new GetCustomersBestDiscount(new InitializeDiscounts( new CustomerServiceStub(), new PackageServiceStub(), new AccountsServiceStub())),new TariffServiceStub()) :
                    null;

            }

            IEnumerable<object> IDependencyResolver.GetServices(Type serviceType)
            {
                return new object[0];
            }
        }
    }
}

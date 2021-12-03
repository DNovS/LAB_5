using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using BLL.Util;
using Ninject;
using Ninject.Web.Mvc;
using LAB_5.Util;

namespace LAB_5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var kernel = new StandardKernel(new NinjectRegistration(), new ServiceModul("ModelContext"));
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}

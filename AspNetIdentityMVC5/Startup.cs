﻿using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: OwinStartup("DefaultConfiguration", typeof(AspNetIdentityMVC5.Startup))]

namespace AspNetIdentityMVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureAuth(app);
        }
    }
}

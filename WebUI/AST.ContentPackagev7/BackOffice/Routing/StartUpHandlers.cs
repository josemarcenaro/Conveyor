﻿namespace AST.ContentPackagev7.BackOffice.Routing
{
    using System.Web.Routing;

    using Umbraco.Core;

    public class StartUpHandlers : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
﻿using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using Trul.Application.UI.Helper;
using Trul.Framework.Security;
using Trul.Infrastructure.Crosscutting.Security;
using Trul.WebUI.Helper;
using Trul.WebUI.IoC;

namespace Trul.WebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Bootstrapper.Initialise();
            CrosscuttingHelper.Initialise();
            MapperHelper.Initialise();

            MiniProfilerEF.Initialize();
        }

        protected void Application_BeginRequest()
        {
            if (Request.IsLocal) { MiniProfiler.Start(); } //or any number of other checks, up to you 
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop(); //stop as early as you can, even earlier with MvcMiniProfiler.MiniProfiler.Stop(discardResults: true);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            AuthenticationFactory.CreateAuthentication().PostAuthenticateRequest();
        }
    }
}
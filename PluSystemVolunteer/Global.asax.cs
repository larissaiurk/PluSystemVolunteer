﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace PluSystemVolunteer
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
           GlobalConfiguration.Configure(WebApiConfig.Register);
           AreaRegistration.RegisterAllAreas();
           RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
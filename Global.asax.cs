using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MatStore.Domain.Entities;
using MatStore.Domain.Abstract;
using System.Data.Entity;
using MatStore.Domain.Concrete;

namespace MatStore.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }     
    }
}

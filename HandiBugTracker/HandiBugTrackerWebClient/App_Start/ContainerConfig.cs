using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using HandiBugTrackerWebClient.Library.Api;

namespace HandiBugTrackerWebClient.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            //For MVC, use RegisterApiControllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<APIHelper>().
                    As<IAPIHelper>().
                    SingleInstance();
            var container = builder.Build();
            //For MVC, use DependencyResolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
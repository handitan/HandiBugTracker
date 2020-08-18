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
            registerTypes(builder);
            var container = builder.Build();
            //For MVC, use DependencyResolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void registerTypes(ContainerBuilder pContainerBuilder)
        {
            pContainerBuilder.RegisterType<CompBugAllOptionsEndPoint>().
                    As<ICompBugAllOptionsEndPoint>().
                    SingleInstance();

            pContainerBuilder.RegisterType<BugDetailEndpoint>().
                    As<IBugDetailEndpoint>().
                    SingleInstance();

            pContainerBuilder.RegisterType<BugListEndpoint>().
                    As<IBugListEndpoint>().
                    SingleInstance();

            pContainerBuilder.RegisterType<APIHelper>().
                    As<IAPIHelper>().
                    SingleInstance();
        }
    }
}
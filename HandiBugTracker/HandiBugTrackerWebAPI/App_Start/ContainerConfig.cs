using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using HandiBugTrackerDataManager.DataAccess;
using HandiBugTrackerDataManager.Internal.DataAccess;

namespace HandiBugTrackerWebAPI.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            //For Web API, we use RegisterApiControllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<SqlDataAccess>().
                   As<ISqlDataAccess>().
                   InstancePerRequest();

            builder.RegisterType<ProductHardwareData>().
                    As<IProductHardwareData>().
                    InstancePerRequest();

            var container = builder.Build();
            //For Web API, we use GlobalConfiguration
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
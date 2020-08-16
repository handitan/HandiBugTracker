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

            registerTypes(builder);

            var container = builder.Build();
            //For Web API, we use GlobalConfiguration
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void registerTypes(ContainerBuilder pBuilder)
        {
            pBuilder.RegisterType<ComponentBugOptionsData>().
                    As<IComponentBugOptionsData>().
                    InstancePerRequest();

            pBuilder.RegisterType<BugCommentData>().
                    As<IBugCommentData>().
                    InstancePerRequest();

            pBuilder.RegisterType<BugPriorityData>().
                    As<IBugPriorityData>().
                    InstancePerRequest();

            pBuilder.RegisterType<BugSeverityData>().
                    As<IBugSeverityData>().
                    InstancePerRequest();

            pBuilder.RegisterType<BugStatusData>().
                    As<IBugStatusData>().
                    InstancePerRequest();

            pBuilder.RegisterType<BugStatusSubStateData>().
                    As<IBugStatusSubStateData>().
                    InstancePerRequest();

            pBuilder.RegisterType<BugTypeData>().
                    As<IBugTypeData>().
                    InstancePerRequest();

            pBuilder.RegisterType<ComponentBugData>().
                    As<IComponentBugData>().
                    InstancePerRequest();

            pBuilder.RegisterType<ComponentData>().
                    As<IComponentData>().
                    InstancePerRequest();

            pBuilder.RegisterType<UserData>().
                    As<IUserData>().
                    InstancePerRequest();

            pBuilder.RegisterType<ProductVersionData>().
                    As<IProductVersionData>().
                    InstancePerRequest();

            pBuilder.RegisterType<ProductOSData>().
                    As<IProductOSData>().
                    InstancePerRequest();

            pBuilder.RegisterType<ProductData>().
                    As<IProductData>().
                    InstancePerRequest();

            pBuilder.RegisterType<ProductHardwareData>().
                    As<IProductHardwareData>().
                    InstancePerRequest();

            pBuilder.RegisterType<SqlDataAccess>().
                   As<ISqlDataAccess>().
                   InstancePerRequest();
        }
    }
}
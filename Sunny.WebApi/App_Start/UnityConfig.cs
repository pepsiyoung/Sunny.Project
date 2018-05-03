using Microsoft.Practices.Unity.Configuration;
using Sunny.Business.Interface;
using Sunny.Business.Service;
using Sunny.EF.Model;
using System;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Web.Http;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.WebApi;

namespace Sunny.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //container.RegisterType<DbContext, MyContext>();
            //container.RegisterType<IBaseService<User>, BaseService<User>>();
            //container.RegisterType<IUserService, UserService>();
            //container.AddNewExtension<Interception>().Configure<Interception>().SetInterceptorFor<IUserService>(new InterfaceInterceptor());

            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config.xml");
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            UnityConfigurationSection configSection = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
            configSection.Configure(container, "defaultContainer");

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
using Microsoft.Practices.Unity.Configuration;
using Sunny.EF.Model;
using Sunny.Framework.AOP.Attribute;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Attributes;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;

namespace Sunny.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //IUnityContainer container = new UnityContainer();
            //container.RegisterType<IPhone, AndroidPhone>();//声明UnityContainer并注册IPhone
            //container.RegisterType<ICamera, Camera>();
            //container.AddNewExtension<Interception>().Configure<Interception>().SetInterceptorFor<IPhone>(new InterfaceInterceptor());
            //IPhone phone = container.Resolve<IPhone>();
            //phone.Call();

            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config.xml");//找配置文件的路径
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
            IUnityContainer container = new UnityContainer();
            section.Configure(container, "testContainer");


            IPhone phone = container.Resolve<IPhone>();
            phone.Call();
            System.Console.ReadKey();
        }
    }

    [LogHandler(Order = 1)]
    public interface IPhone
    {      
        void Call();
    }

    [LogHandler(Order = 1)]
    public interface ICamera
    {
        [LogHandler(Order = 10)]
        void Use();
    }

    public class AndroidPhone : IPhone
    {
        [Dependency]
        public ICamera camera { get; set; }
        public void Call()
        {
            System.Console.WriteLine("用安卓手机打电话");
            camera.Use();
        }
    }

    public class Camera : ICamera
    {
        public void Use()
        {
            System.Console.WriteLine("使用摄像头");
        }
    }


}

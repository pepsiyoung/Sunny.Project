using Sunny.Business.Interface;
using Sunny.Business.Service;
using Sunny.EF.Model;
using Sunny.Web.Utility.Filter;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.Attributes;

namespace Sunny.Web.Controllers
{
    public class LoginController : Controller
    {
        [Dependency]
        public IUserService IUserService { get; set; }

        // GET: Login
        [MyActionFilter]
        public ActionResult Index()
        {
            return View();
        }

        [MyAuthorizeFilter]
        public JsonResult Select(int id)
        {
            {
                //IUnityContainer container = new UnityContainer();
                //container.RegisterType<DbContext, MyContext>();
                //container.RegisterType<IBaseService<User>, BaseService<User>>();
                //container.RegisterType<IUserService, UserService>();
                //IUserService userService = container.Resolve<IUserService>();
                //var user = userService.Find(id);
                //return Json(user, JsonRequestBehavior.AllowGet);
            }

            {
                var user = IUserService.Find(id);
                return Json(user, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult SelectAll()
        {
            List<User> list = IUserService.GetVip();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}



//打开VS中工具有个NuGet包管理器中选择程序包管理器控制台，输入：Enable-Migrations

//第二步：添加Migrations，在程序包管理器控制台输入Add-Migration AddUrl，后面的AddUrl，依据自己的要求编写
//第三步：更新数据库：在程序包管理器控制台输入 Update-Database 命令，就能看到数据库中多了要操作的表了
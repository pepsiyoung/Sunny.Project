using Sunny.Framework.LogHelper;
using Sunny.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sunny.Web.Utility.Filter
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class LogExceptionFilterAttribute:HandleErrorAttribute
    {
        private Logger logger = Logger.CreateLogger(typeof(LogExceptionFilterAttribute));
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)//异常有没有被处理过
            {
                string controllerName = (string)filterContext.RouteData.Values["controller"];
                string actionName = (string)filterContext.RouteData.Values["action"];
                string msgTemplate = "在执行 controller[{0}] 的 action[{1}] 时产生异常";
                logger.Error(string.Format(msgTemplate, controllerName, actionName), filterContext.Exception);

                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult()
                    {
                        Data = new AjaxResult()
                        {
                            Result = DoResult.Failed,
                            PromptMsg = "系统出现异常，请联系管理员",
                            DebugMessage = filterContext.Exception.Message
                        }//这个就是返回的结果
                    };
                }
                else
                {
                    filterContext.Result = new ViewResult()
                    {
                        ViewName = "~/Views/Shared/Error.cshtml",
                        ViewData = new ViewDataDictionary<string>(filterContext.Exception.Message)
                    };
                }
                filterContext.ExceptionHandled = true;
            }
        }
    }
}
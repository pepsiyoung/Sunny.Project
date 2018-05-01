using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sunny.Web.Utility.Filter
{
    public class MyActionFilterAttribute:ActionFilterAttribute
    {
        private Stopwatch timer = new Stopwatch();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer.Start();
            filterContext.HttpContext.Response.Write("<div>这里是MyActionFilter,在执行操作方法前</div>");
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
            filterContext.HttpContext.Response.Write("<div>这里是MyActionFilter,在执行操作方法后</div>");
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<div>这里是MyActionFilter,在执行操作结果前</div>");
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            timer.Stop();
            filterContext.HttpContext.Response.Write($"<div>这里是MyActionFilter,在执行操作结果后,用时:{timer.ElapsedMilliseconds}</div>");
        }
    }
}
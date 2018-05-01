using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sunny.Web.Utility.Filter
{
    /// <summary>
    /// 检验登陆和权限的Filter
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = true)]
    public class MyAuthorizeFilterAttribute: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<div>已执行权限检验</div>");
        }
    }
}
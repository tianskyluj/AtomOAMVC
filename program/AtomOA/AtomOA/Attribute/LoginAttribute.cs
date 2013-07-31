using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// 验证是否登录
namespace AtomOA.Attribute
{
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true,
    AllowMultiple = true)]
    public class LoginAttribute : ActionFilterAttribute 
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AtomOA.Common.DataSession.GetUserSession().Id == 0)
                filterContext.RequestContext.HttpContext.Response.Redirect("~/Home/Login");
        }
       
    }
}
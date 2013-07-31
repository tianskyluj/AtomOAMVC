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
    public class LoginAttribute : AuthorizeAttribute  
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (AtomOA.Common.DataSession.GetUserSession().Id == 0)
                filterContext.RequestContext.HttpContext.Response.Redirect("~/Home/Login");
        }
       
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using AtomOA.Models;
using AtomOA.IBLL;
using AtomOA.Attribute;
using Spring.Context.Support;

namespace AtomOA.Controllers
{

    [HandleError]
    public class AccountController : Controller
    {

        public ISystemUserService SystemUserService { get; set; }

        [LoginAttribute]
        public ActionResult Index()
        {
            var webApplicationContext =
                          ContextRegistry.GetContext() as WebApplicationContext;
            SystemUserService =
                webApplicationContext.GetObject("SystemUserService") as ISystemUserService;

            return View();
        }

        /// <summary>
        /// 修改个人资料
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateProfile(AtomOA.Model.SystemUser userModel)
        {
            var webApplicationContext =
                          ContextRegistry.GetContext() as WebApplicationContext;
            SystemUserService =
                webApplicationContext.GetObject("SystemUserService") as ISystemUserService;//从spring配置中获取Userservice

            AtomOA.Model.SystemUser initModel = SystemUserService.GetModelById(userModel.Id);

            initModel.Phone = userModel.Phone;
            initModel.Email = userModel.Email;
            initModel.QQ = userModel.QQ;

            bool echo = SystemUserService.Update(initModel);

            return Content(echo ? "1" : "0");
        }
    }
}

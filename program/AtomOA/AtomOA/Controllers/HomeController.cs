using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spring.Context.Support;
using AtomOA.IBLL;
using System.IO;
using System.Text;
using AtomOA.Attribute;

namespace AtomOA.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ISystemUserService SystemUserService { get; set; }
        public IGlobalSettingService GlobalSettingService { get; set; }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        
        [LoginAttribute]
        public ActionResult Index()
        {
            var webApplicationContext =
                          ContextRegistry.GetContext() as WebApplicationContext;
            GlobalSettingService =
                webApplicationContext.GetObject("GlobalSettingService") as IGlobalSettingService;//从spring配置中获取Userservice
            SystemUserService =
                webApplicationContext.GetObject("SystemUserService") as ISystemUserService;//从spring配置中获取Userservice

            ViewData["CompanyName"] = GlobalSettingService.GetGlobalSettingValue("companyName");
            ViewData["name"] = AtomOA.Common.DataSession.GetUserSession().Name.ToString();
            ViewData["userId"] = AtomOA.Common.DataSession.GetUserSession().Id.ToString();

            string avatarString = SystemUserService.GetUserAvatar();
            ViewData["avatar"] = avatarString == "" ? "../../Upload/Avatar/DefaultAvatar.jpg" : avatarString;

            ViewData["visible"] = (AtomOA.Common.DataSession.GetUserSession().IfAdmin == 1);
            
            return View();
        }

        /// <summary>
        /// 显示登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            var webApplicationContext =
                        ContextRegistry.GetContext() as WebApplicationContext;
            GlobalSettingService =
                webApplicationContext.GetObject("GlobalSettingService") as IGlobalSettingService;//从spring配置中获取Userservice

            ViewData["CompanyName"] = GlobalSettingService.GetGlobalSettingValue("companyName");
            return View();
        }

        /// <summary>
        /// 用户登出
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginOut()
        {
            AtomOA.Common.DataSession.destroySession();
            return RedirectToAction("Login");
        }

        /// <summary>
        /// 点击登录操作
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DoLogin(AtomOA.Model.SystemUser userModel)
        {
            var webApplicationContext =
                          ContextRegistry.GetContext() as WebApplicationContext;
            SystemUserService =
                webApplicationContext.GetObject("SystemUserService") as ISystemUserService;//从spring配置中获取Userservice
            
            bool echo = SystemUserService.CheckLogin(userModel);
            
            return Content(echo ? "1" : "0");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spring.Context.Support;
using AtomOA.IBLL;

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
        public ActionResult Index()
        {
            ViewData["CompanyName"] = AtomOA.Common.DataSession.GetGlobalSession().CompanyName.ToString();
            ViewData["name"] = AtomOA.Common.DataSession.GetUserSession().Name.ToString();
            
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
            AtomOA.Common.DataSession.SetGlobaSession(GlobalSettingService.GetAllList()[0]);
            ViewData["CompanyName"] = AtomOA.Common.DataSession.GetGlobalSession().CompanyName.ToString();
            return View();
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

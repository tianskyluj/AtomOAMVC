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

            ViewData["CompanyName"] = GlobalSettingService.GetGlobalSettingValue("companyName");
            ViewData["name"] = AtomOA.Common.DataSession.GetUserSession().Name.ToString();
            string fileUrl = AtomOA.Common.inc.getApplicationPath() + "/Upload/Avatar/" + AtomOA.Common.DataSession.GetUserSession().Id.ToString() + "_avatar.txt";
            string avatarString = "";

            StreamReader sr;
            if (System.IO.File.Exists(HttpContext.Server.MapPath(fileUrl)))
            {
                sr = System.IO.File.OpenText(HttpContext.Server.MapPath(fileUrl));
                avatarString = sr.ReadLine();
                sr.Close();
                sr.Dispose();
            }
           
            ViewData["avatar"] = avatarString == "" ? "../../Upload/Avatar/DefaultAvatar.jpg" : avatarString;

            return View();
        }

        /// <summary>
        /// 显示登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            if (AtomOA.Common.DataCache.GetGlobalCache() == null)
            {
                var webApplicationContext =
                          ContextRegistry.GetContext() as WebApplicationContext;
                GlobalSettingService =
                    webApplicationContext.GetObject("GlobalSettingService") as IGlobalSettingService;//从spring配置中获取Userservice
                AtomOA.Common.DataCache.SetGlobalCache(GlobalSettingService.GetAllList()[0]);
            }

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

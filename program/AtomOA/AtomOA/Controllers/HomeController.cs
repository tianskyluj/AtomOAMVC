﻿using System;
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
            ViewData["name"] = "唐富伟";
            
            return View();
        }

        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            var webApplicationContext =
                           ContextRegistry.GetContext() as WebApplicationContext;
            GlobalSettingService =
                webApplicationContext.GetObject("GlobalSettingService") as IGlobalSettingService;//从spring配置中获取Userservice
            ViewData["CompanyName"] = GlobalSettingService.GetAllList()[0].CompanyName;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}

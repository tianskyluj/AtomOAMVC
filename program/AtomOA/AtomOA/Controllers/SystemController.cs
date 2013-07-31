using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spring.Context.Support;
using AtomOA.IBLL;
using AtomOA.Attribute;

namespace AtomOA.Controllers
{
    public class SystemController : Controller
    {
        public IGlobalSettingService GlobalSettingService { get; set; }
        //
        // GET: /System/

        public ActionResult Index()
        {
            var webApplicationContext =
                          ContextRegistry.GetContext() as WebApplicationContext;
            GlobalSettingService =
                webApplicationContext.GetObject("GlobalSettingService") as IGlobalSettingService;//从spring配置中获取Userservice

            ViewData["companyName"] = GlobalSettingService.GetAllList()[0].CompanyName;

            return View();
        }

        [HttpPost]
        public ActionResult UpdateGolbal(AtomOA.Model.GlobalSetting globalModel)
        {
            var webApplicationContext =
                          ContextRegistry.GetContext() as WebApplicationContext;
            GlobalSettingService =
                webApplicationContext.GetObject("GlobalSettingService") as IGlobalSettingService;//从spring配置中获取Userservice

            bool echo = GlobalSettingService.Update(globalModel);

            return Content(echo ? "1" : "0");
        }

    }
}

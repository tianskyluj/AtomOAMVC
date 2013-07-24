using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AtomOA.IBLL;

namespace AtomOA.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        //
        // 获取用户服务
        private ISystemUserService systemUserService;

        public ISystemUserService SystemUserService
        {
            get { return this.systemUserService; }
            set { this.systemUserService = value; }
        }

        public ActionResult Index()
        {
            ViewData["name"] = "唐富伟";
            
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}

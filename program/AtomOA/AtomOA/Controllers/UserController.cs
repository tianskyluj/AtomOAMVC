using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Spring.Context.Support;
using AtomOA.IBLL;

namespace AtomOA.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        private ISystemUserService systemUserService;

        public ISystemUserService SystemUserService
        {
            get { return this.systemUserService; }
            set { this.systemUserService = value; }
        }

        public ActionResult Index()
        {
            var webApplicationContext =
                           ContextRegistry.GetContext() as WebApplicationContext;
            SystemUserService =
                webApplicationContext.GetObject("systemUserService") as ISystemUserService;//从spring配置中获取Userservice
            IList<AtomOA.Model.SystemUser> users = SystemUserService.GetAllList();
            ViewData["Users"] = users;
            return View("ShowAllUsers");
        }

    }
}

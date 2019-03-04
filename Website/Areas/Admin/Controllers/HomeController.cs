using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Configuaration;

namespace Website.Areas.Admin.Controllers
{
    [CustomRoleAuthorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
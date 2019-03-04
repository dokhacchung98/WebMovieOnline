using ApplicationCore.Services;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web.Mvc;
using Website.Configuaration;

namespace Website.Areas.Admin.Controllers
{
    [CustomRoleAuthorize(Roles = "Admin")]
    public class ManagerRolesController : Controller
    {
        private readonly IRoleService _roleService;

        public ManagerRolesController(IRoleService service)
        {
            _roleService = service;
        }

        public ActionResult Index()
        {
            var model = _roleService.GetAll();
            return View(model);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IdentityRole role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _roleService.Create(role);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(role);
        }
    }
}
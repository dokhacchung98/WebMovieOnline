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

        public ActionResult AddRole()
        {
            return PartialView("_AddNewRole");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRole(IdentityRole role)
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


        public ActionResult EditRole(string id)
        {
            var role = _roleService.Find(id);
            return PartialView("_EditRole", role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRole(IdentityRole role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _roleService.Update(role, role.Id);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(role);
        }

        public ActionResult DeleteRole(string id)
        {
            var role = _roleService.Find(id);
            return PartialView("_DeleteRole", role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRole(IdentityRole role)
        {
            try
            {
                _roleService.Delete(role);

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
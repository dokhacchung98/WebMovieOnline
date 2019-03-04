using ApplicationCore.Services;
using AutoMapper;
using Infrastructure.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Web.Mvc;
using Website.Configuaration;
using Website.Models;
using System.Linq;


namespace Website.Areas.Admin.Controllers
{
    [CustomRoleAuthorize(Roles = "Admin")]
    public class ManagerUsersController : Controller
    {
        private readonly IApplicationUserService _userService;
        private readonly IRoleService _roleService;

        public ManagerUsersController(IApplicationUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        // GET: Admin/ManagerUsers
        public ActionResult Index()
        {
            var models = _userService.GetAll();
            return View(models);
        }

        public ActionResult Edit(string id)
        {
            ApplicationUser user = _userService.Find(id);
            var viewUser = Mapper.Map<UpdateUserViewModel>(user);
            return View(viewUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdateUserViewModel viewUser)
        {
            var user = Mapper.Map<ApplicationUser>(viewUser);
            _userService.UpdateUser(user, user.Id);
            return RedirectToAction("Index");
        }

        [CustomRoleAuthorize(Roles = "Admin")]
        public ActionResult EditRole(string Id)
        {
            var model = _userService.Find(Id);

            IEnumerable<IdentityRole> roles = _userService.GetRolesByUserId(Id);

            IList<IdentityRole> listRole = _roleService.GetAll().ToList();
            ViewBag.ArrayRole = listRole;

            ViewBag.Roles = new SelectList(roles, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToRole(string userId, string roleId)
        {
            if (roleId != null && userId != null)
            {
                _userService.AddRoleToUser(userId, roleId);
            }

            return RedirectToAction("Index");
        }
        [CustomRoleAuthorize(Roles = "Admin")]
        public ActionResult Delete(string Id)
        {
            var model = _userService.Find(Id);
            if (model != null)
            {
                _userService.Delete(model);
            }
            return RedirectToAction("Index");
        }
        
    }
}
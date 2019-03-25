using ApplicationCore.Services;
using AutoMapper;
using Extension.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.ViewModel;

namespace Website.Areas.Admin.Controllers
{
    public class BaseAdminController : Controller
    {
        private readonly IApplicationUserService _userService;

        public BaseAdminController(IApplicationUserService userService)
        {
            _userService = userService;
        }

        // GET: Admin/BaseAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UploadImage()
        {
            return View();
        }
       

        public ActionResult ViewProfile(string userName)
        {
            var user = _userService.GetUserFromUserName(userName);
            var userProfile = Mapper.Map<ProfileUserViewModel>(user);

            return View(userProfile);
        }
    }
}
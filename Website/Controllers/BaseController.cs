using ApplicationCore.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.ViewModel;

namespace Website.Controllers
{
    public class BaseController : Controller
    {
        private INewsService _service;

        private readonly IApplicationUserService _userService;

        public BaseController(INewsService service, IApplicationUserService userService)
        {
            _service = service;
            _userService = userService;
        }

        // GET: Base
        public ActionResult SlideBarTopView()
        {
            var items = _service.GetNumberOfListNews(7);
            return View(items);
        }

        public ActionResult ViewProfile(string userName)
        {
            var user = _userService.GetUserFromUserName(userName);
            var userProfile = Mapper.Map<ProfileUserViewModel>(user);

            return PartialView(userProfile);
        }
    }
}
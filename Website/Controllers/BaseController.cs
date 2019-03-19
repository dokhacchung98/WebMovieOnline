using ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class BaseController : Controller
    {
        private INewsService _service;

        public BaseController(INewsService service)
        {
            _service = service;
        }

        // GET: Base
        public ActionResult SlideBarTopView()
        {
            var items = _service.GetNumberOfListNews(7);
            return View(items);
        }
    }
}
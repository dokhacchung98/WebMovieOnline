
using ApplicationCore.Services;
using AutoMapper;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Website.ViewModel;

namespace Website.Areas.Admin.Controllers
{
    public class ManagerNewsController : Controller
    {
        private readonly INewsService _service;

        public ManagerNewsController(INewsService service)
        {
            _service = service;
        }

        // GET: Admin/ManagerNews
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(NewsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var news = Mapper.Map<News>(model);

            _service.Create(news);

            return  RedirectToAction("Index");
        }
    }
}
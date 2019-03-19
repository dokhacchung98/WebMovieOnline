
using ApplicationCore.Services;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Create(News model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _service.Create(model);

            return  RedirectToAction("Index");
        }
    }
}
using ApplicationCore.Services;
using AutoMapper;
using Common.Utils;
using Extension.Extensions;
using Infrastructure.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website.Configuaration;
using Website.ViewModel;

namespace Website.Areas.Admin.Controllers
{
    [CustomRoleAuthorize(Roles = "Admin")]
    public class ManagerResolutionsController : Controller
    {
        private readonly IResolutionService _resolutionService;
        private IList<ResolutionViewModel> _listresolutionViewModel;

        public ManagerResolutionsController(IResolutionService resolutionService)
        {
            _resolutionService = resolutionService;

            var resolutions = _resolutionService.GetAll();
            if (resolutions != null)
            {
                var resolutionViewModels = Mapper.Map<IEnumerable<ResolutionViewModel>>(resolutions);

                _listresolutionViewModel = resolutionViewModels.ToList();
            }
        }

        public ActionResult Index(string name)
        {
            if (name == null)
            {
                Session["PageList"] = null;
            }
            else
            {
                Session["PageList"] = name;
            }
            if (_listresolutionViewModel == null)
            {
                return View();
            }
            return View(_listresolutionViewModel);
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resolution resolution = _resolutionService.Find(id);

            if (resolution == null)
            {
                return HttpNotFound();
            }

            ResolutionViewModel resolutionViewModel = Mapper.Map<ResolutionViewModel>(resolution);
            return View(resolutionViewModel);
        }

        public ActionResult Create(Guid? id)
        {
            return PartialView("_CreateResolution");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(ResolutionViewModel resolutionViewModel)
        {
            if (ModelState.IsValid)
            {
                resolutionViewModel.Id = Guid.NewGuid();

                Resolution resolution = Mapper.Map<Resolution>(resolutionViewModel);

                _resolutionService.Create(resolution);

                return RedirectToAction("Index");
            }

            return PartialView("_CreateResolution", resolutionViewModel);
        }

        public ActionResult Edit(Guid id)
        {
            Resolution resolution = _resolutionService.Find(id);
            ResolutionViewModel resolutionViewModel = Mapper.Map<ResolutionViewModel>(resolution);
            return View("_EditResolution", resolutionViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(ResolutionViewModel resolutionViewModel)
        {
            if (ModelState.IsValid)
            {
                Resolution resolution = Mapper.Map<Resolution>(resolutionViewModel);

                _resolutionService.Update(resolution, resolution.Id);
                return RedirectToAction("Index");
            }
            return View(resolutionViewModel);
        }

        public ActionResult Delete(Guid? id)
        {
            Resolution resolution = _resolutionService.Find(id);

            ResolutionViewModel resolutionViewModel = Mapper.Map<ResolutionViewModel>(resolution);
            return PartialView("_DeleteResolution", resolutionViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            Resolution resolution = _resolutionService.Find(id);

            if (resolution == null)
            {
                return HttpNotFound();
            }

            _resolutionService.Delete(resolution);

            return RedirectToAction("Index");
        }

        public PartialViewResult GetPaging(int? page)
        {
            int pageSize = 5;

            int pageNumber = (page ?? 1);

            if (Session["PageList"] != null)
            {
                var name = Session["PageList"].ToString();
                var listSearch = _resolutionService.SearchByName(name);
                var listSearchModel = AutoMapper.Mapper.Map<IEnumerable<ResolutionViewModel>>(listSearch);
                return PartialView("_PartialViewResolution", listSearchModel.ToPagedList(pageNumber, pageSize));
            }

            return PartialView("_PartialViewResolution", _listresolutionViewModel.ToPagedList(pageNumber, pageSize));
        }
    }
}
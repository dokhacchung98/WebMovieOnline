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
    public class ManagerDirectorsController : Controller
    {
        private readonly IDirectorService _directorService;
        private IList<DirectorViewModel> _listDirectorViewModel;

        public ManagerDirectorsController(IDirectorService directorService)
        {
            _directorService = directorService;

            var directors = _directorService.GetAll();
            if (directors != null)
            {
                var directorViewModels = Mapper.Map<IEnumerable<DirectorViewModel>>(directors);

                _listDirectorViewModel = directorViewModels.ToList();
            }
        }

        public ActionResult Index()
        {
            if (_listDirectorViewModel == null)
            {
                return View();
            }
            return View(_listDirectorViewModel);
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = _directorService.Find(id);

            if (director == null)
            {
                return HttpNotFound();
            }

            DirectorViewModel directorViewModel = Mapper.Map<DirectorViewModel>(director);
            return View(directorViewModel);
        }

        public ActionResult Create(Guid? id)
        {
            return PartialView("_CreateDirector");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(DirectorViewModel directorViewModel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                directorViewModel.Id = Guid.NewGuid();

                Director director = Mapper.Map<Director>(directorViewModel);
                if (image != null)
                {
                    if (CheckImageUploadExtension.CheckImagePath(image.FileName) == true)
                    {
                        var path = Path.Combine(Server.MapPath("~/Images/Upload"), image.FileName);
                        image.SaveAs(path);
                        director.Thumbnail = VariableUtils.UrlUpLoadImage + image.FileName;
                    }
                }
                _directorService.Create(director);

                return RedirectToAction("Index");
            }

            return PartialView("_CreateDirector", directorViewModel);
        }

        public ActionResult Edit(Guid id)
        {
            Director director = _directorService.Find(id);
            DirectorViewModel directorViewModel = Mapper.Map<DirectorViewModel>(director);
            return View("_EditDirector", directorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(DirectorViewModel directorViewModel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                Director oldDirector = _directorService.Find(directorViewModel.Id);
                if (oldDirector == null)
                {
                    return HttpNotFound();
                }
                Director director = Mapper.Map<Director>(directorViewModel);
                if (image != null)
                {
                    if (CheckImageUploadExtension.CheckImagePath(image.FileName) == true)
                    {
                        var path = Path.Combine(Server.MapPath("~/Images/Upload"), image.FileName);
                        image.SaveAs(path);
                        director.Thumbnail = VariableUtils.UrlUpLoadImage + image.FileName;
                    }
                }
                else
                {
                    if (oldDirector.Thumbnail != null)
                    {
                        director.Thumbnail = oldDirector.Thumbnail;
                    }
                }
                _directorService.Update(director, director.Id);
                return RedirectToAction("Index");
            }
            return View(directorViewModel);
        }

        public ActionResult Delete(Guid? id)
        {
            Director director = _directorService.Find(id);

            DirectorViewModel directorViewModel = Mapper.Map<DirectorViewModel>(director);
            return PartialView("_DeleteDirector", directorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            Director director = _directorService.Find(id);

            if (director == null)
            {
                return HttpNotFound();
            }

            _directorService.Delete(director);

            return RedirectToAction("Index");
        }

        public PartialViewResult GetPaging(int? page)
        {
            int pageSize = 5;

            int pageNumber = (page ?? 1);
            return PartialView("_PartialViewDirector", _listDirectorViewModel.ToPagedList(pageNumber, pageSize));
        }
    }
}
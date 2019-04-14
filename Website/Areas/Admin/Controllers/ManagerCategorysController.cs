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
using System.Web.Routing;
using System.Web.Mvc;
using Website.ViewModel;

namespace Website.Areas.Admin.Controllers
{
    public class ManagerCategorysController : Controller
    {
        private readonly ICategorysService _categorysService;
        private IList<CategorysViewModel> _listCategorysViewModel;
        public ManagerCategorysController(ICategorysService categoryService)
        {
            _categorysService = categoryService;
            var category = _categorysService.GetAll();
            if (category != null)
            {
                var categorysViewModels = Mapper.Map<IEnumerable<CategorysViewModel>>(category);
                _listCategorysViewModel = categorysViewModels.ToList();
            }
        }
        // GET: Admin/ManagerCategorys
        public ActionResult Index(string name)
        {

            if (name == null)
            {
                Session["KeyWordSearch"] = null;
            }
            else
            {
                Session["KeyWordSearch"] = name;
            }
            if (_listCategorysViewModel == null)
            {
                return View();
            }
            return View(_listCategorysViewModel);
        }
        public ActionResult Details (Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _categorysService.Find(id);
            if (category == null) return HttpNotFound();
            CategorysViewModel categorysViewModel = Mapper.Map<CategorysViewModel>(category);
            return View(categorysViewModel);
        }

        public ActionResult Create (Guid? id)
        {
            return PartialView("_CreateCategorys");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(CategorysViewModel categorysViewModel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                categorysViewModel.Id = Guid.NewGuid();
                Category category = Mapper.Map<Category>(categorysViewModel);
                if (image != null)
                {
                    if (CheckImageUploadExtension.CheckImagePath(image.FileName) == true)
                    {
                        var path = Path.Combine(Server.MapPath("~/Images/Upload"), image.FileName);
                        image.SaveAs(path);
                        category.Thumbnail = VariableUtils.UrlUpLoadImage + image.FileName;
                    }
                }
                _categorysService.Create(category);
                return RedirectToAction("Index");
            }
            return PartialView("_CreateCategorys", categorysViewModel);
        }

        public ActionResult Edit (Guid id)
        {
            Category category = _categorysService.Find(id);
            CategorysViewModel categorysViewModel = Mapper.Map<CategorysViewModel>(category);
            return View("_EditCategorys", categorysViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit (CategorysViewModel categorysViewModel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                Category oldCategory = _categorysService.Find(categorysViewModel.Id);
                if (oldCategory == null)
                {
                    return HttpNotFound();
                }
                Category category = Mapper.Map<Category>(categorysViewModel);
                if (image != null)
                {
                    if (CheckImageUploadExtension.CheckImagePath(image.FileName) == true)
                    {
                        var path = Path.Combine(Server.MapPath("~/Images/Upload"), image.FileName);
                        image.SaveAs(path);
                        category.Thumbnail = VariableUtils.UrlUpLoadImage + image.FileName;
                    }
                }
                else
                {
                    if (oldCategory.Thumbnail != null) category.Thumbnail = oldCategory.Thumbnail;

                }
                _categorysService.Update(category, category.Id);
                return RedirectToAction("Index");
            }
            return View(categorysViewModel);
        }

        public ActionResult Delete (Guid? id)
        {
            Category category = _categorysService.Find(id);
            CategorysViewModel categorysViewModel = Mapper.Map<CategorysViewModel>(category);
            return PartialView("_DeleteCategorys", categorysViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (Guid id)
        {
            Category category = _categorysService.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            _categorysService.Delete(category);
            return RedirectToAction("Index");
        }

        public PartialViewResult GetPaging (int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialViewCategorys", _listCategorysViewModel.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult GetPageSearch(int? page)
        {
            int pageSize = VariableUtils.pageSize;

            int pageNumber = (page ?? 1);

            if (Session["KeyWordSearch"] != null)
            {
                var name = Session["KeyWordSearch"].ToString();
                var listSearch = _categorysService.SearchCategoryByName(name);
                var listSearchModel = AutoMapper.Mapper.Map<IEnumerable<CategorysViewModel>>(listSearch);
                return PartialView("_PartialViewCategorys", listSearchModel.ToPagedList(pageNumber, pageSize));
            }

            return PartialView("_PartialViewCategorys",
                _listCategorysViewModel.ToPagedList(pageNumber, pageSize));
        }
    }
}
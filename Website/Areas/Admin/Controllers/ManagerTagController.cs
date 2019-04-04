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
    public class ManagerTagController : Controller
    {
        private readonly ITagService _tagService;
        private IList<TagViewModel> _listTagViewModel;
        public ManagerTagController(ITagService tagService)
        {
            _tagService = tagService;
            var tag = _tagService.GetAll();
            if (tag != null)
            {
                var tagViewModel = Mapper.Map<IEnumerable<TagViewModel>>(tag);
                _listTagViewModel = tagViewModel.ToList();
            }
        }


        // GET: Admin/ManagerTag
        public ActionResult Index()
        {
            if (_listTagViewModel == null) return View();
            else return View(_listTagViewModel);
        }

        public ActionResult Details (Guid? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Tag tag = _tagService.Find(id);
            if (tag == null) return HttpNotFound();
            TagViewModel tagViewModel = Mapper.Map<TagViewModel>(tag);
            return View(tagViewModel);
        }
        public ActionResult Create (Guid?id)
        {
            return PartialView("_CreateTag");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create (TagViewModel tagViewModel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                tagViewModel.Id = Guid.NewGuid();
                Tag tag = Mapper.Map<Tag>(tagViewModel);
                if (image != null)
                {
                    if (CheckImageUploadExtension.CheckImagePath(image.FileName) == true)
                    {
                        var path = Path.Combine(Server.MapPath("~/Images/Upload"), image.FileName);
                        image.SaveAs(path);
                        tag.Thumbnail = VariableUtils.UrlUpLoadImage + image.FileName;
                    }
                }               
                _tagService.Create(tag);
                return RedirectToAction("Index");
            }
            return PartialView("_CreateTag", tagViewModel);
        }
    
        public ActionResult Edit (Guid id)
        {
            Tag tag = _tagService.Find(id);
            TagViewModel tagViewModel = Mapper.Map<TagViewModel>(tag);
            return View("_editTag", tagViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit (TagViewModel tagViewModel, HttpPostedFileBase image)
        {
            Tag oldTag = _tagService.Find(tagViewModel.Id);
            if (oldTag == null) return HttpNotFound();
            Tag tag = Mapper.Map<Tag>(tagViewModel);
            if (image != null)
            {
                if (CheckImageUploadExtension.CheckImagePath(image.FileName) == true)
                {
                    var path = Path.Combine(Server.MapPath("~/Images/Upload"), image.FileName);
                    image.SaveAs(path);
                    tag.Thumbnail = VariableUtils.UrlUpLoadImage + image.FileName;
                }
            }
            else
            {
                if (oldTag.Thumbnail != null)
                {
                    tag.Thumbnail = oldTag.Thumbnail;
                }
            }
            _tagService.Update(tag, tag.Id);
            return RedirectToAction("Index");
        }

        public ActionResult Delete (Guid? id)
        {
            Tag tag = _tagService.Find(id);
            TagViewModel tagViewModel = Mapper.Map<TagViewModel>(tag);
            return PartialView("_DeleteTag", tagViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            Tag tag = _tagService.Find(id);
            if (tag == null) HttpNotFound();
            _tagService.Delete(tag);
            return RedirectToAction("Index");
        }

        public PartialViewResult GetPaging(int? page)
        {
            int pageSize = 5;

            int pageNumber = (page ?? 1);
            return PartialView("_PartialViewTag", _listTagViewModel.ToPagedList(pageNumber, pageSize));
        }
    }

}
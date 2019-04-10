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
            if (_listTagViewModel == null)
            {
                return View();
            }
            return View(_listTagViewModel);
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
        public ActionResult Create (TagViewModel tagViewModel)
        {
            if (ModelState.IsValid)
            {
                tagViewModel.Id = Guid.NewGuid();
                Tag tag = Mapper.Map<Tag>(tagViewModel);
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
        public ActionResult Edit (TagViewModel tagViewModel)
        {
            Tag tag = Mapper.Map<Tag>(tagViewModel);
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

        public ActionResult GetPageSearch(int? page)
        {
            int pageSize = VariableUtils.pageSize;

            int pageNumber = (page ?? 1);

            if (Session["KeyWordSearch"] != null)
            {
                var name = Session["KeyWordSearch"].ToString();
                var listSearch = _tagService.SearchTagByName(name);
                var listSearchModel = AutoMapper.Mapper.Map<IEnumerable<TagViewModel>>(listSearch);
                return PartialView("_PartialViewTag", listSearchModel.ToPagedList(pageNumber, pageSize));
            }

            return PartialView("_PartialViewTag",
                _listTagViewModel.ToPagedList(pageNumber, pageSize));
        }
    }

}
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
    public class ManagerProducerController : Controller
    {
        private readonly IProducerService _producerService;
        private IList<ProducerViewModel> _listProducerViewModel;

        public ManagerProducerController(IProducerService producerService)
        {
            _producerService = producerService;

            var producer = _producerService.GetAll();
            if (producer != null)
            {
                var producerViewModel = Mapper.Map<IEnumerable<ProducerViewModel>>(producer);

                _listProducerViewModel = producerViewModel.ToList();
            }
        }

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
            if (_listProducerViewModel == null)
            {
                return View();
            }
            return View(_listProducerViewModel);
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producer producer = _producerService.Find(id);

            if (producer == null)
            {
                return HttpNotFound();
            }

            ProducerViewModel producerViewModel = Mapper.Map<ProducerViewModel>(producer);
            return View(producerViewModel);
        }

        public ActionResult Create(Guid? id)
        {
            return PartialView("_CreateProducer");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(ProducerViewModel producerViewModel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                producerViewModel.Id = Guid.NewGuid();

                Producer producer = Mapper.Map<Producer>(producerViewModel);
                if (image != null)
                {
                    if (CheckImageUploadExtension.CheckImagePath(image.FileName) == true)
                    {
                        var path = Path.Combine(Server.MapPath("~/Images/Upload"), image.FileName);
                        image.SaveAs(path);
                        producer.Thumbnail = VariableUtils.UrlUpLoadImage + image.FileName;
                    }
                }
                _producerService.Create(producer);

                return RedirectToAction("Index");
            }

            return PartialView("_CreateProducer", producerViewModel);
        }

        public ActionResult Edit(Guid id)
        {
            Producer producer = _producerService.Find(id);
            ProducerViewModel producerViewModel = Mapper.Map<ProducerViewModel>(producer);
            return View("_EditProducer", producerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(ProducerViewModel producerViewModel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {

                Producer oldProducer = _producerService.Find(producerViewModel.Id);
                if (oldProducer == null)
                {
                    return HttpNotFound();
                }
                Producer producer = Mapper.Map<Producer>(producerViewModel);
                if (image != null)
                {
                    if (CheckImageUploadExtension.CheckImagePath(image.FileName) == true)
                    {
                        var path = Path.Combine(Server.MapPath("~/Images/Upload"), image.FileName);
                        image.SaveAs(path);
                        producer.Thumbnail = VariableUtils.UrlUpLoadImage + image.FileName;
                    }
                }
                else
                {
                    if (oldProducer.Thumbnail != null)
                    {
                        producer.Thumbnail = oldProducer.Thumbnail;
                    }
                }
                _producerService.Update(producer, producer.Id);
                return RedirectToAction("Index");
            }
            return View(producerViewModel);
        }

        public ActionResult Delete(Guid? id)
        {
            Producer producer = _producerService.Find(id);

            ProducerViewModel producerViewModel = Mapper.Map<ProducerViewModel>(producer);
            return PartialView("_DeleteProducer", producerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            Producer producer = _producerService.Find(id);

            if (producer == null)
            {
                return HttpNotFound();
            }

            _producerService.Delete(producer);

            return RedirectToAction("Index");
        }

        public PartialViewResult GetPaging(int? page)
        {
            int pageSize = 5;

            int pageNumber = (page ?? 1);
            return PartialView("_PartialViewProducer", _listProducerViewModel.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult GetPageSearch(int? page)
        {
            int pageSize = VariableUtils.pageSize;
            int pageNumber = (page ?? 1);
            if (Session["KeyWordSearch"] != null)
            {
                var name = Session["KeyWordSearch"].ToString();
                var listSearch = _producerService.SearchProducerByName(name);
                var listSearchModel = AutoMapper.Mapper.Map<IEnumerable<ProducerViewModel>>(listSearch);
                return PartialView("_PartialViewProducer", listSearchModel.ToPagedList(pageNumber, pageSize));
            }

            return PartialView("_PartialViewProducer",
                _listProducerViewModel.ToPagedList(pageNumber, pageSize));
        }
    }
}
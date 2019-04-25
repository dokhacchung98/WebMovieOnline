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
using Website.ViewModel;

namespace Website.Areas.Admin.Controllers
{
    public class ManagerTrailersController : Controller
    {
        private readonly ITrailerService _trailerService;
        private readonly IMoviesService _moviesService;
        private IList<TrailerViewModel> _listTrailerViewModels;
        public ManagerTrailersController(ITrailerService trailerService, IMoviesService moviesService)
        {
            _trailerService = trailerService;
            _moviesService = moviesService;

            var trailers = _trailerService.GetAll();
            if (trailers != null)
            {
                var trailerViewModels = Mapper.Map<IEnumerable<TrailerViewModel>>(trailers);
                foreach(var trailer in trailerViewModels)
                {
                    var movie = _moviesService.Find(trailer.MovieId);
                    var movieViewModel = Mapper.Map<MoviesViewModel>(movie);
                    trailer.MoviesViewModel = movieViewModel;
                }
                _listTrailerViewModels = trailerViewModels.ToList();
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
            if (_listTrailerViewModels == null)
            {
                return View();
            }
            return View(_listTrailerViewModels);
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Trailer trailer = _trailerService.Find(id);
            if (trailer == null) return HttpNotFound();
            TrailerViewModel trailerViewModel = Mapper.Map<TrailerViewModel>(trailer);
            return View(trailerViewModel);
        }

        public ActionResult Create(Guid? id)
        {
            var movies = _moviesService.GetAll();
            var movieViewModels = Mapper.Map<IEnumerable<MoviesViewModel>>(movies);
            ViewBag.Movies = new SelectList(movieViewModels, "Id", "Name");
            return PartialView("_CreateTrailer");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(TrailerViewModel trailerViewModel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null &&
                                    image.FileName != null &&
                                    CheckImageUploadExtension.CheckImagePath(image.FileName) == true)
                {
                    var path = Path.Combine(Server.MapPath("~/Images/Upload"), image.FileName);
                    image.SaveAs(path);
                    trailerViewModel.Thumbnail = VariableUtils.UrlUpLoadImage + image.FileName;
                }

                
                trailerViewModel.Id = Guid.NewGuid();
                Trailer trailer = Mapper.Map<Trailer>(trailerViewModel);
                _trailerService.Create(trailer);
                return RedirectToAction("Index");
            }
            return PartialView("_CreateTrailer", trailerViewModel);
        }

        public ActionResult Edit(Guid id)
        {
            Trailer trailer = _trailerService.Find(id);
            TrailerViewModel trailerViewModel = Mapper.Map<TrailerViewModel>(trailer);

            var movies = _moviesService.GetAll();
            var movieViewModels = Mapper.Map<IEnumerable<MoviesViewModel>>(movies);
            ViewBag.Movies = new SelectList(movieViewModels, "Id", "Name", trailer.MovieID);

            return View("_EditTrailer", trailerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(TrailerViewModel trailerViewModel, HttpPostedFileBase image)
        {
            if (image != null &&
                                    image.FileName != null &&
                                    CheckImageUploadExtension.CheckImagePath(image.FileName) == true)
            {
                var path = Path.Combine(Server.MapPath("~/Images/Upload"), image.FileName);
                image.SaveAs(path);
                trailerViewModel.Thumbnail = VariableUtils.UrlUpLoadImage + image.FileName;
            }

            Trailer trailer = Mapper.Map<Trailer>(trailerViewModel);
            _trailerService.Update(trailer, trailer.Id);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid? id)
        {
            Trailer trailer = _trailerService.Find(id);
            TrailerViewModel trailerViewModel = Mapper.Map<TrailerViewModel>(trailer);
            return PartialView("_DeleteTrailer", trailerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            Trailer trailer = _trailerService.Find(id);
            if (trailer == null) HttpNotFound();
            _trailerService.Delete(trailer);
            return RedirectToAction("Index");
        }

        public PartialViewResult GetPaging(int? page)
        {
            int pageSize = 5;

            int pageNumber = (page ?? 1);
            return PartialView("_PartialViewTrailer", _listTrailerViewModels.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult GetPageSearch(int? page)
        {
            int pageSize = VariableUtils.pageSize;

            int pageNumber = (page ?? 1);

            if (Session["KeyWordSearch"] != null)
            {
                var name = Session["KeyWordSearch"].ToString();
                var listSearch = _trailerService.SearchTrailerByName(name);
                var listSearchModel = AutoMapper.Mapper.Map<IEnumerable<TrailerViewModel>>(listSearch);

                foreach (var item in listSearchModel)
                {
                    var movie = _moviesService.Find(item.MovieId);
                    var movieViewModel = Mapper.Map<MoviesViewModel>(movie);
                    item.MoviesViewModel = movieViewModel;
                }

                return PartialView("_PartialViewTrailer", listSearchModel.ToPagedList(pageNumber, pageSize));
            }

            return PartialView("_PartialViewTrailer",
                _listTrailerViewModels.ToPagedList(pageNumber, pageSize));
        }
    }
}
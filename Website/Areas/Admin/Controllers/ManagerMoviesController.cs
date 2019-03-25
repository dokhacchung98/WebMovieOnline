using ApplicationCore.Services;
using AutoMapper;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using Website.Configuaration;
using Website.ViewModel;

namespace Website.Areas.Admin.Controllers
{
    [CustomRoleAuthorize(Roles = "Admin")]
    public class ManagerMoviesController : Controller
    {
        private readonly IMoviesService _moviesService;

        public ManagerMoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        public ActionResult Index()
        {
            var movies = _moviesService.GetAll();
            if (movies != null)
            {
                var movieViewModels = Mapper.Map<IEnumerable<MoviesViewModel>>(movies);
                return View(movieViewModels);
            }

            return View();
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _moviesService.Find(id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var movieViewModels = Mapper.Map<MoviesViewModel>(movie);
            return View(movie);
        }

        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,DatePublish,LengthTime,Language,Country,IsHot,NameEn,EnableAge,Thumbnail,Description,CreatedDate")] MoviesViewModel moviesViewModel)
        {
            if (ModelState.IsValid)
            {
                moviesViewModel.Id = Guid.NewGuid();

                var movie = Mapper.Map<Movie>(moviesViewModel);

                _moviesService.Create(movie);

                return RedirectToAction("Index");
            }

            return View(moviesViewModel);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _moviesService.Find(id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            MoviesViewModel moviesViewModel = Mapper.Map<MoviesViewModel>(movie);
            return View(moviesViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DatePublish,LengthTime,Language,Country,IsHot,NameEn,EnableAge,Thumbnail,Description,CreatedDate")] MoviesViewModel moviesViewModel)
        {
            if (ModelState.IsValid)
            {
                var movie = Mapper.Map<Movie>(moviesViewModel);

                _moviesService.Update(movie, movie.Id);

                return RedirectToAction("Index");
            }
            return View(moviesViewModel);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _moviesService.Find(id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            _moviesService.Delete(movie);
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _moviesService.Find(id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            _moviesService.Delete(movie);
            return RedirectToAction("Index");
        }
    }
}
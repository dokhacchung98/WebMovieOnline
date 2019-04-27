using ApplicationCore.Services;
using Infrastructure.DataContext;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Website.ViewModel;

namespace Website.Controllers
{
    public class MoviesController : Controller
    {
        private MovieDbContext db = new MovieDbContext();

        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        // GET: Movie/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            MoviesViewModel movieViewModel = AutoMapper.Mapper.Map<MoviesViewModel>(movie);

            ICollection<MoviesViewModel> list = (ICollection<MoviesViewModel>) Session["MoviesSeen"] 
                                                ?? new List<MoviesViewModel>();

            bool existItem = list.Any(item => item.Id == movieViewModel.Id);
            if (existItem == false)
            {
                list.Add(movieViewModel);
            }

            Session["MoviesSeen"] = list;

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movieViewModel);
        }

        public ActionResult GetNewestMovies()
        {
            var newestMovies = _moviesService.GetNewestMovies(5);
            var newestMovieViewModels = AutoMapper.Mapper.Map<IEnumerable<MoviesViewModel>>(newestMovies);
            return PartialView("_NewestMovies", newestMovieViewModels);
        }
    }
}
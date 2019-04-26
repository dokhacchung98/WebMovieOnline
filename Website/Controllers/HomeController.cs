using ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.ViewModel;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMoviesService _moviesService;

        public HomeController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        public ActionResult Index()
        {
            var listFeatureFilm = _moviesService.GetCountFeatureFilm(12);
            var listSeriesMovie = _moviesService.GetCountSeriesMovies(12);

            var listFeatureFilmViewModel = AutoMapper.Mapper.Map<IEnumerable<MoviesViewModel>>(listFeatureFilm);
            var listSeriesMovieViewModel = AutoMapper.Mapper.Map<IEnumerable<MoviesViewModel>>(listSeriesMovie);

            ViewBag.ListFeatureFilm = listFeatureFilmViewModel;
            ViewBag.ListSeriesMovie = listSeriesMovieViewModel;

            return View();
        }
    }
}
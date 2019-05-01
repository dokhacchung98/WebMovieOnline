using ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Configuaration;

namespace Website.Areas.Admin.Controllers
{
    [CustomRoleAuthorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IMoviesService _moviesService;
        private readonly IApplicationUserService _applicationUserService;
        private readonly ICategoryMovieService _categoryMovieService;
        private readonly IFilmService _filmService;

        public HomeController(IMoviesService moviesService,
                              IApplicationUserService applicationUserService,
                              ICategoryMovieService categoryMovieService,
                              IFilmService filmService)
        {
            _moviesService = moviesService;
            _applicationUserService = applicationUserService;
            _categoryMovieService = categoryMovieService;
            _filmService = filmService;
        }

        public ActionResult Index()
        {
            var countUser = _applicationUserService.Count();
            var countMovie = _moviesService.Count();
            var countFilm = _filmService.Count();
            var countCategoty = _categoryMovieService.Count();

            ViewBag.CountUser = countUser;
            ViewBag.CountMovie = countMovie;
            ViewBag.CountFilm = countFilm;
            ViewBag.CountCategory = countCategoty;

            return View();
        }
    }
}
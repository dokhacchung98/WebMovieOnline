using ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.ViewModel;

namespace Website.Areas.Admin.Controllers
{
    public class ManagerFeatureFilmController : Controller
    {
        private readonly IMoviesService _movieService;
        private readonly IFilmService _filmService;
        private IList<FeatureFilmViewModel> _listFeatureFilmViewModels;

        public ManagerFeatureFilmController(IMoviesService movieService, IFilmService filmService)
        {
            _movieService = movieService;
            _filmService = filmService;

            var listMovies = _movieService.GetAll();
            var listFilm = _filmService.GetAll();
        }

        public ActionResult Index()
        {

            return View();
        }
    }
}
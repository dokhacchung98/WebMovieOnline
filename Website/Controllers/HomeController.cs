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
        private readonly ITrailerService _trailersService;


        public HomeController(ITrailerService trailersService, IMoviesService moviesService)
        {
            _trailersService = trailersService;
            _moviesService = moviesService; 
        }

        public ActionResult Index()
        {            
            var listNewTrailer = _trailersService.GetNewTrailerByNumber(10);
            var listNewTrailerViewModel = AutoMapper.Mapper.Map<ICollection<TrailerViewModel>>(listNewTrailer);
            ViewBag.ListNewTrailer = listNewTrailerViewModel;

            var listMovie = _moviesService.GetAll();
            var listMovieViewModel = AutoMapper.Mapper.Map<ICollection<MoviesViewModel>>(listMovie);
            
            return View(listMovieViewModel);
        }

    }
}
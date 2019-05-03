using ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.ViewModel;

namespace Website.Controllers
{
    public class TrailersController : Controller
    {
        private readonly ITrailerService _trailerService;

        public TrailersController()
        {
        }

        public TrailersController(
            ITrailerService trailerService)
        {
            _trailerService = trailerService;
        }

        public ActionResult NewestTrailers()
        {
            var trailers = _trailerService.GetNewTrailerByNumber(10);

            var trailerViewModels = AutoMapper.Mapper.Map<IEnumerable<TrailerViewModel>>(trailers);
            for (int i = 0; i < trailers.Count(); i++)
            {
                var movie = trailers.ToList()[i].Movie;
                var movieViewModel = AutoMapper.Mapper.Map<MoviesViewModel>(movie);
                trailerViewModels.ToList()[i].MoviesViewModel = movieViewModel;
            }

            return PartialView("_NewestTrailers", trailerViewModels);
        }
    }
}
using ApplicationCore.Services;
using Common.Utils;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.ViewModel;

namespace Website.Controllers
{
    public class TrailerController : Controller
    {
        private readonly IMoviesService _moviesService;
        private readonly ITrailerService _trailerService;

        public TrailerController(IMoviesService moviesService, ITrailerService trailerService)
        {
            _moviesService = moviesService;
            _trailerService = trailerService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("Trailer");
            }

            var trailer = _trailerService.Find(id);
            var trailerViewModel = AutoMapper.Mapper.Map<TrailerViewModel>(trailer);

            var model = new TrailerMovieViewModel()
            {
                TrailerViewModel = trailerViewModel
            };

            if (trailer.MovieID != null)
            {
                var movie = _moviesService.Find(trailer.MovieID);
                var movieViewModel = AutoMapper.Mapper.Map<MoviesViewModel>(movie);
                model.MoviesViewModel = movieViewModel;
            }

            return View(model);
        }
        public ActionResult GetPage(int? page)
        {
            int pageSize = VariableUtils.pageSearchMovie;

            int pageNumber = (page ?? 1);

            var listTrailer = _trailerService.GetAll();
            var listModel = new List<TrailerMovieViewModel>();
            var listTrailerViewModel = AutoMapper.Mapper.Map<ICollection<TrailerViewModel>>(listTrailer);

            foreach (var item in listTrailerViewModel)
            {
                var model = new TrailerMovieViewModel()
                {
                    TrailerViewModel = item
                };

                if (item.MovieId != null)
                {
                    var movie = _moviesService.Find(item.MovieId);
                    var movieViewModel = AutoMapper.Mapper.Map<MoviesViewModel>(movie);
                    model.MoviesViewModel = movieViewModel;
                }

                listModel.Add(model);
            }

            return PartialView("_PartialViewTrailer",
                listModel.ToPagedList(pageNumber, pageSize));
        }
    }
}
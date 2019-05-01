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
    public class SeriesTVController : Controller
    {
        private readonly IMoviesService _moviesService;
        public SeriesTVController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPage(int? page)
        {
            int pageSize = VariableUtils.pageSearchMovie;

            int pageNumber = (page ?? 1);

            var listMovie = _moviesService.GetAllSeriesTV();
            var listMovieViewModel = AutoMapper.Mapper.Map<ICollection<MoviesViewModel>>(listMovie);

            return PartialView("_PartialViewMovie",
                listMovieViewModel.ToPagedList(pageNumber, pageSize));
        }
    }
}
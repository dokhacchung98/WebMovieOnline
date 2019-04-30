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
    public class SearchMovieController : Controller
    {
        private readonly IMoviesService _moviesService;

        public SearchMovieController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        public ActionResult Index(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return RedirectToAction("Index", "Home");
            }
            Session["PageList"] = keyword;
            return View("Search");
        }

        public ActionResult GetPageSearch(int? page)
        {
            int pageSize = VariableUtils.pageSearch;

            int pageNumber = (page ?? 1);

            var keyword = Session["PageList"].ToString();

            if (string.IsNullOrEmpty(keyword))
            {
                return RedirectToAction("Index", "Home");
            }
            var listMovieSearch = _moviesService.SearchMoviesByKeyWord(keyword);
            var listMovieViewModel = AutoMapper.Mapper.Map<ICollection<MoviesViewModel>>(listMovieSearch);

            return PartialView("_PartialViewSearch",
                listMovieViewModel.ToPagedList(pageNumber, pageSize));
        }
    }
}
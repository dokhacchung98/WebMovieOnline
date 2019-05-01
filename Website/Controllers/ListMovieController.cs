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
    public class ListMovieController : Controller
    {
        private readonly ICategorysService _categorysService;
        private readonly IMoviesService _moviesService;
        public ListMovieController(ICategorysService categorysService, IMoviesService moviesService)
        {
            _categorysService = categorysService;
            _moviesService = moviesService;
        }

        public ActionResult Index(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var category = _categorysService.Find(id.Value);

            if (category == null)
            {
                return HttpNotFound();
            }

            var categoryViewModel = AutoMapper.Mapper.Map<CategorysViewModel>(category);

            ViewBag.IdCategory = id.Value;

            return View(categoryViewModel);
        }

        public ActionResult GetPage(int? page, Guid id)
        {
            int pageSize = VariableUtils.pageSearchMovie;

            int pageNumber = (page ?? 1);

            var listMovie = _moviesService.GetMoviesByCategoryId(id);
            var listMovieViewModel = AutoMapper.Mapper.Map<ICollection<MoviesViewModel>>(listMovie);

            ViewBag.IdCategory = id;

            return PartialView("_PartialViewMovie",
                listMovieViewModel.ToPagedList(pageNumber, pageSize));
        }
    }
}
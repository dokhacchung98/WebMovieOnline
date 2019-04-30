using ApplicationCore.Services;
using AutoMapper;
using Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.ViewModel;

namespace Website.Controllers
{
    public class BaseController : Controller
    {
        private readonly INewsService _newsService;
        private readonly IMoviesService _moviesService;
        private readonly ICategorysService _categorysService;


        private readonly IApplicationUserService _userService;

        public BaseController(INewsService newsService,
                                IApplicationUserService userService,
                                IMoviesService moviesService,
                                ICategorysService categorysService)
        {
            _newsService = newsService;
            _userService = userService;
            _moviesService = moviesService;
            _categorysService = categorysService;
        }

        public ActionResult SlideBarTopView()
        {
            var items = _newsService.GetNumberOfListNews(7);
            return View(items);
        }

        public ActionResult ViewProfile(string userName)
        {
            var user = _userService.GetUserFromUserName(userName);
            var userProfile = Mapper.Map<ProfileUserViewModel>(user);

            return PartialView(userProfile);
        }

        public ActionResult ViewSlideMovieHot()
        {
            var listMovieHot = _moviesService.GetCountMovieHot(10);
            var listMovieHotViewModel = Mapper.Map<IEnumerable<MoviesViewModel>>(listMovieHot);
            return PartialView("_PartialSlideMovieHot", listMovieHotViewModel);
        }

        public ActionResult ViewNews()
        {
            var listNews = _newsService.GetCountNews(VariableUtils.countNews);
            var listNewsViewModel = Mapper.Map<ICollection<NewsViewModel>>(listNews);

            return PartialView("_PartialNews", listNewsViewModel);
        }

        public ActionResult ViewMenu()
        {
            var listCategory = _categorysService.GetAll();
            var listCategoryViewModel = Mapper.Map<ICollection<CategorysViewModel>>(listCategory);
            return PartialView("_PartialMenu", listCategoryViewModel);
        }
    }
}
using ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.ViewModel;

namespace Website.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        private readonly IMoviesService _moviesService;

        public NewsController(INewsService newsService, IMoviesService moviesService)
        {
            _newsService = newsService;
            _moviesService = moviesService;
        }

        public ActionResult Index()
        {
            var listNews = _newsService.GetAll();
            var listNewsViewModel = AutoMapper.Mapper.Map<ICollection<NewsViewModel>>(listNews);
            var listModel = new List<NewsMovieViewModel>();
            foreach (var item in listNewsViewModel)
            {
                var movie = _moviesService.Find(item.MovieId);
                var movieViewModel = AutoMapper.Mapper.Map<MoviesViewModel>(movie);
                listModel.Add(new NewsMovieViewModel()
                {
                    MoviesViewModel = movieViewModel,
                    NewsViewModel = item
                });
            }
            return View(listModel);
        }

        public ActionResult Detail(Guid? idMovie)
        {
            if (idMovie == null)
            {
                return RedirectToAction("Index");
            }
            var news = _newsService.Find(idMovie.Value);
            if (news == null)
            {
                return HttpNotFound();
            }
            var newsViewModel = AutoMapper.Mapper.Map<NewsViewModel>(news);

            return View(newsViewModel);
        }
    }
}
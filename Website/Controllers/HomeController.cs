using ApplicationCore.Services;
using Infrastructure.Entities;
using Infrastructure.Identity;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Mvc;
using Website.ViewModel;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMoviesService _moviesService;

        private readonly IFavoriteMovieService _favoriteMovieService;

        public HomeController(IMoviesService moviesService, IFavoriteMovieService favoriteMovieService)
        {
            _moviesService = moviesService;
            _favoriteMovieService = favoriteMovieService;
        }

        public ActionResult Index()
        {
            var listFeatureFilm = _moviesService.GetCountFeatureFilm(12);
            var listSeriesMovie = _moviesService.GetCountSeriesMovies(12);

            var listFeatureFilmViewModel = AutoMapper.Mapper.Map<IEnumerable<MoviesViewModel>>(listFeatureFilm);
            var listSeriesMovieViewModel = AutoMapper.Mapper.Map<IEnumerable<MoviesViewModel>>(listSeriesMovie);

            ViewBag.ListFeatureFilm = listFeatureFilmViewModel;
            ViewBag.ListSeriesMovie = listSeriesMovieViewModel;
            // lấy ra phim vừa xem
            ViewBag.MoviesSeen = (ICollection<MoviesViewModel>)Session["MoviesSeen"];

            // lấy ra phim đã thích
            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();

            ICollection<FavoriteMovie> favoriteMovies = _favoriteMovieService.GetFavoriteMoviesByUserId(userId);

            ICollection<Movie> movies = new List<Movie>();

            foreach (var favoriteMovie in favoriteMovies)
            {
                var movie = _moviesService.Find(favoriteMovie.MovieId);
                movies.Add(movie);
            }

            var favoriteMovieViewModels = AutoMapper.Mapper.Map<IEnumerable<MoviesViewModel>>(movies);

            ViewBag.FavoriteMovies = favoriteMovieViewModels;

            return View();
        }
    }
}
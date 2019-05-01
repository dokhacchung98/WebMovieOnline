using PagedList;
using ApplicationCore.Services;
using AutoMapper;
using Common.Utils;
using Infrastructure.DataContext;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Website.ViewModel;
using Infrastructure.Identity;

namespace Website.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesService;

        private readonly IActorMovieService _actorMovieService;

        private readonly IActorsService _actorsService;

        private readonly IDirectorService _directorService;

        private readonly IDirectorMovieService _directorMovieService;

        private readonly IFilmService _filmService;

        private readonly IRatingService _ratingService;

        private readonly IFavoriteMovieService _favoriteMovieService;

        private readonly IApplicationUserService _applicationUserService;

        public MoviesController(IMoviesService moviesService,
                                IActorMovieService actorMovieService,
                                IActorsService actorsService,
                                IDirectorService directorService,
                                IDirectorMovieService directorMovieService,
                                IFilmService filmService,
                                IRatingService ratingService,
                                IApplicationUserService applicationUserService,
                                IFavoriteMovieService favoriteMovieService)
        {
            _moviesService = moviesService;
            _actorMovieService = actorMovieService;
            _actorsService = actorsService;
            _directorService = directorService;
            _directorMovieService = directorMovieService;
            _filmService = filmService;
            _ratingService = ratingService;
            _applicationUserService = applicationUserService;
            _favoriteMovieService = favoriteMovieService;
        }

        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _moviesService.Find(id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            // Tăng lượt view lên +1
            movie.CountView += 1;
            // Lưu vào db
            _moviesService.Update(movie, id);

            MoviesViewModel movieViewModel = AutoMapper.Mapper.Map<MoviesViewModel>(movie);

            // lấy ra danh sách phim vừa xem
            ICollection<MoviesViewModel> list = (ICollection<MoviesViewModel>)Session["MoviesSeen"]
                                                ?? new List<MoviesViewModel>();

            bool existItem = list.Any(item => item.Id == movieViewModel.Id);
            if (existItem == false)
            {
                list.Add(movieViewModel);
            }

            Session["MoviesSeen"] = list;

            // lấy ra số tập phim
            var episodes = _filmService.GetFilmsByMovieId(id);
            var episodeViewModels = Mapper.Map<IEnumerable<FilmViewModel>>(episodes);
            ViewBag.Episodes = episodeViewModels;

            // lấy ra tập đang xem
            string currentLink = (string)Session["CurrentEpisode"];
            bool existCurrentEpisode = episodes.Any(episode => episode.Link.Equals(currentLink));
            if (existCurrentEpisode == true)
            {
                ViewBag.CurrentEpisode = currentLink;
            }
            else
            {
                if (episodes.Count() > 0)
                {
                    ViewBag.CurrentEpisode = episodes.First().Link;
                }
                else
                {
                    ViewBag.CurrentEpisode = null;
                }
            }

            if (User.Identity.IsAuthenticated)
            {
                var use = _applicationUserService.GetUserFromUserName(User.Identity.Name);
                var currentRating = _ratingService.Find(id, use.Id);
                var currenRatingViewModel = Mapper.Map<RatingViewModel>(currentRating);
                ViewBag.CurrentRating = currenRatingViewModel;
            }

            return View(movieViewModel);
        }

        public ActionResult GetNewestMovies()
        {
            var newestMovies = _moviesService.GetNewestMovies(5);
            var newestMovieViewModels = AutoMapper.Mapper.Map<IEnumerable<MoviesViewModel>>(newestMovies);
            return PartialView("_NewestMovies", newestMovieViewModels);
        }

        public ActionResult GetActorsOfMovie(Guid id)
        {
            var listActorIds = _actorMovieService.GetIdActorByMovieId(id);
            ICollection<Actor> actors = new List<Actor>();
            foreach (var actorId in listActorIds)
            {
                Actor actor = _actorsService.Find(actorId);
                if (actor != null)
                {
                    actors.Add(actor);
                }
            }

            var actorViewModels = AutoMapper.Mapper.Map<IEnumerable<ActorViewModel>>(actors);
            return PartialView("_ActorsOfMovie", actorViewModels);
        }

        public ActionResult GetDirectorsOfMovie(Guid id)
        {
            var listDirectorIds = _directorMovieService.GetIdDirectorByMovieId(id);
            ICollection<Director> directors = new List<Director>();
            foreach (var directorId in listDirectorIds)
            {
                Director director = _directorService.Find(directorId);
                if (director != null)
                {
                    directors.Add(director);
                }
            }

            var directorViewModels = AutoMapper.Mapper.Map<IEnumerable<DirectorViewModel>>(directors);
            return PartialView("_DirectorsOfMovie", directorViewModels);
        }

        [HttpPost]
        public void CurrentEpisode(string link)
        {
            Session["CurrentEpisode"] = link;
        }

        [HttpPost]
        public ActionResult Rating(string idMovie, string feedback, double starRate)
        {
            var use = _applicationUserService.GetUserFromUserName(User.Identity.Name);
            var ratingViewModel = new RatingViewModel()
            {
                UserId = use.Id,
                MovieId = Guid.Parse(idMovie),
                Feedback = feedback,
                StarRating = starRate
            };

            var result = "success";
            var oldRating = _ratingService.Find(ratingViewModel.MovieId, ratingViewModel.UserId);
            if (oldRating != null)
            {
                result = "faild";
            }
            else
            {
                var rating = Mapper.Map<Rating>(ratingViewModel);
                var listRating = _ratingService.GetAllRatingByIdMovie(ratingViewModel.MovieId);
                double value = 0;
                if (listRating != null)
                {
                    foreach (var item in listRating)
                    {
                        value += item.StarRating;
                    }
                }
                float star = (float)((value + rating.StarRating) / (listRating.Count + 1));

                var movie = _moviesService.Find(ratingViewModel.MovieId);
                movie.Rating = star;

                _moviesService.Update(movie, movie.Id);
                _ratingService.Create(rating);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPadingRating(Guid idMovie, int? page)
        {
            int pageSize = VariableUtils.pageSize;

            int pageNumber = (page ?? 1);

            if (idMovie != null)
            {
                var listRating = _ratingService.GetAllRatingByIdMovie(idMovie);
                var listUseRatingViewModel = new List<UseRatingViewModel>();
                foreach (var item in listRating)
                {
                    var use = _applicationUserService.Find(item.UserId);
                    var ratingViewModel = Mapper.Map<RatingViewModel>(item);
                    listUseRatingViewModel.Add(new UseRatingViewModel()
                    {
                        RatingViewModel = ratingViewModel,
                        UseViewModel = use
                    });
                }
                ViewBag.IdMovie = idMovie;
                return PartialView("_PartialViewRating",
                listUseRatingViewModel.ToPagedList(pageNumber, pageSize));
            }

            return PartialView("_PartialViewRating");
        }

        public JsonResult AddFavoriteMovie(string idMovie, string userName)
        {
            ApplicationUser currentUser = _applicationUserService.GetUserFromUserName(userName);
            bool exist = _favoriteMovieService.ExistObject(new Guid(idMovie), currentUser.Id);

            if (exist == false)
            {
                FavoriteMovie favoriteMovie = new FavoriteMovie
                {
                    MovieId = new Guid(idMovie),
                    UserId = currentUser.Id,
                    User = currentUser
                };

                _favoriteMovieService.Create(favoriteMovie);

                return Json(new
                {
                    status = 200,
                    message = "Success"
                });
            }
            else
            {
                return Json(new
                {
                    status = 500,
                    message = "Fail"
                });
            }
        }
    }
}
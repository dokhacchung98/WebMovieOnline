using ApplicationCore.Services;
using AutoMapper;
using Infrastructure.DataContext;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Website.ViewModel;

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


        public MoviesController(IMoviesService moviesService, 
                                IActorMovieService actorMovieService,
                                IActorsService actorsService,
                                IDirectorService directorService,
                                IDirectorMovieService directorMovieService,
                                IFilmService filmService)
        {
            _moviesService = moviesService;
            _actorMovieService = actorMovieService;
            _actorsService = actorsService;
            _directorService = directorService;
            _directorMovieService = directorMovieService;
            _filmService = filmService;
        }

        // GET: Movie/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _moviesService.Find(id);

            // Tăng lượt view lên +1
            movie.CountView += 1;
            // Lưu vào db
            _moviesService.Update(movie, id);

            MoviesViewModel movieViewModel = AutoMapper.Mapper.Map<MoviesViewModel>(movie);
            
            // lấy ra danh sách phim vừa xem
            ICollection<MoviesViewModel> list = (ICollection<MoviesViewModel>) Session["MoviesSeen"] 
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
            string currentLink = (string) Session["CurrentEpisode"];
            bool existCurrentEpisode = episodes.Any(episode => episode.Link.Equals(currentLink));
            if (existCurrentEpisode == true)
            {
                ViewBag.CurrentEpisode = currentLink;
            } else
            {
                if (episodes.Count() > 0)
                {
                    ViewBag.CurrentEpisode = episodes.First().Link;
                } else
                {
                    ViewBag.CurrentEpisode = null;
                }
            }
            
            

            if (movie == null)
            {
                return HttpNotFound();
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
            foreach(var actorId in listActorIds)
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
            foreach(var directorId in listDirectorIds)
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

    }
}
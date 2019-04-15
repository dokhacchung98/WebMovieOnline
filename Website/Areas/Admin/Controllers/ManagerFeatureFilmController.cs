using ApplicationCore.Services;
using Common.Utils;
using Extension.Extensions;
using Infrastructure.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.ViewModel;

namespace Website.Areas.Admin.Controllers
{
    public class ManagerFeatureFilmController : Controller
    {
        private readonly IMoviesService _movieService;
        private readonly IFilmService _filmService;
        private readonly IProducerService _producerService;
        private readonly IActorsService _actorService;
        private readonly ICategorysService _categorysService;
        private readonly IDirectorService _directorService;
        private readonly ITagService _tagService;
        private readonly IResolutionService _resolutionService;

        private readonly IActorMovieService _actorMovieService;
        private readonly IDirectorMovieService _directorMovieService;
        private readonly ICategoryMovieService _categoryMovieService;
        private readonly IProducerMovieService _producerMovieService;
        private readonly IResolutionMovieService _resolutionMovieService;
        private readonly ITagMovieService _tagMovieService;

        private IList<FeatureFilmViewModel> _listFeatureFilmViewModels = new List<FeatureFilmViewModel>();

        public ManagerFeatureFilmController(IMoviesService movieService, IFilmService filmService, IProducerService producerService,
                                            IActorsService actorService, ICategorysService categorysService,
                                            IDirectorService directorService, ITagService tagService,
                                            IResolutionService resolutionService,
                                            IActorMovieService actorMovieService,
                                            IDirectorMovieService directorMovieService,
                                            ICategoryMovieService categoryMovieService,
                                            IProducerMovieService producerMovieService,
                                            IResolutionMovieService resolutionMovieService,
                                            ITagMovieService tagMovieService)
        {
            _movieService = movieService;
            _filmService = filmService;
            _producerService = producerService;
            _actorService = actorService;
            _categorysService = categorysService;
            _directorService = directorService;
            _tagService = tagService;
            _resolutionService = resolutionService;
            _actorMovieService = actorMovieService;
            _directorMovieService = directorMovieService;
            _categoryMovieService = categoryMovieService;
            _producerMovieService = producerMovieService;
            _resolutionMovieService = resolutionMovieService;
            _tagMovieService = tagMovieService;

            var listMovies = _movieService.GetAllFeatureMovie();
            var listFilm = _filmService.GetAll();

            if (!_listFeatureFilmViewModels.Any())
                foreach (var item in listMovies)
                {
                    var movieViewModel = AutoMapper.Mapper.Map<MoviesViewModel>(item);
                    var film = _filmService.GetFilmByIdMovie(item.Id);
                    var filmViewModel = AutoMapper.Mapper.Map<FilmViewModel>(film);
                    var model = new FeatureFilmViewModel()
                    {
                        MoviesViewModel = movieViewModel,
                        FilmViewModel = filmViewModel
                    };
                    _listFeatureFilmViewModels.Add(model);
                }
        }

        public ActionResult Index(string name)
        {
            if (name == null)
            {
                Session["KeyWordSearch"] = null;
            }
            else
            {
                Session["KeyWordSearch"] = name;
            }
            if (_listFeatureFilmViewModels == null)
            {
                return View();
            }
            return View(_listFeatureFilmViewModels);
        }

        public ActionResult Create(Guid? id)
        {
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(FeatureFilmViewModel viewModel, HttpPostedFileBase image,
                                    IEnumerable<string> actor, IEnumerable<string> director,
                                    IEnumerable<string> category, IEnumerable<string> producer,
                                    IEnumerable<string> resolution, IEnumerable<string> tag)
        {
            var filmViewModel = viewModel.FilmViewModel;
            var movieViewModel = viewModel.MoviesViewModel;

            var film = AutoMapper.Mapper.Map<Film>(filmViewModel);
            var movie = AutoMapper.Mapper.Map<Movie>(movieViewModel);
            movie.IsSeriesMovie = false;
            film.MovieId = movie.Id;

            if (image != null &&
                image.FileName != null &&
                CheckImageUploadExtension.CheckImagePath(image.FileName) == true)
            {
                var path = Path.Combine(Server.MapPath("~/Images/Upload"), image.FileName);
                image.SaveAs(path);
                movie.Thumbnail = VariableUtils.UrlUpLoadImage + image.FileName;
            }

            _movieService.Create(movie);
            _filmService.Create(film);

            if (actor != null)
                foreach (var item in actor)
                {
                    _actorMovieService.Create(new ActorMovie()
                    {
                        ActorId = Guid.Parse(item),
                        MovieId = movie.Id
                    });
                }
            if (director != null)
                foreach (var item in director)
                {
                    _directorMovieService.Create(new DirectorMovie()
                    {
                        DirectorId = Guid.Parse(item),
                        MovieId = movie.Id
                    });
                }
            if (category != null)
                foreach (var item in category)
                {
                    _categoryMovieService.Create(new CategoryMovie()
                    {
                        CategoryId = Guid.Parse(item),
                        MovieId = movie.Id
                    });
                }
            if (producer != null)
                foreach (var item in producer)
                {
                    _producerMovieService.Create(new ProducerMovie()
                    {
                        ProducerId = Guid.Parse(item),
                        MovieId = movie.Id
                    });
                }
            if (resolution != null)
                foreach (var item in resolution)
                {
                    _resolutionMovieService.Create(new MovieResolution()
                    {
                        ResolutionId = Guid.Parse(item),
                        MovieId = movie.Id
                    });
                }
            if (tag != null)
                foreach (var item in tag)
                {
                    _tagMovieService.Create(new TagMovie()
                    {
                        TagId = Guid.Parse(item),
                        MovieId = movie.Id
                    });
                }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var film = _filmService.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            var movie = _movieService.Find(film.MovieId);

            var movieViewModel = AutoMapper.Mapper.Map<MoviesViewModel>(movie);
            var filmViewModel = AutoMapper.Mapper.Map<FilmViewModel>(film);

            var model = new FeatureFilmViewModel()
            {
                MoviesViewModel = movieViewModel,
                FilmViewModel = filmViewModel
            };

            return View("_Edit", model);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var film = _filmService.Find(id.Value);
            if (film == null)
            {
                return HttpNotFound();
            }
            var movie = _movieService.Find(film.MovieId);
            var movieViewModel = AutoMapper.Mapper.Map<MoviesViewModel>(movie);

            return PartialView("_Delete", movieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var film = _filmService.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            var movie = _movieService.Find(film.MovieId);

            _movieService.Delete(movie);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(FeatureFilmViewModel viewModel, HttpPostedFileBase image)
        {
            Movie oldMovie = _movieService.Find(viewModel.MoviesViewModel.Id);

            var movie = AutoMapper.Mapper.Map<Movie>(viewModel.MoviesViewModel);
            var film = AutoMapper.Mapper.Map<Film>(viewModel.FilmViewModel);
            if (image != null &&
                image.FileName != null &&
            CheckImageUploadExtension.CheckImagePath(image.FileName) == true)
            {
                var path = Path.Combine(Server.MapPath("~/Images/Upload"), image.FileName);
                image.SaveAs(path);
                movie.Thumbnail = VariableUtils.UrlUpLoadImage + image.FileName;
            }
            else
            {
                if (oldMovie.Thumbnail != null)
                {
                    movie.Thumbnail = oldMovie.Thumbnail;
                }
            }
            film.MovieId = movie.Id;
            _movieService.Update(movie, movie.Id);
            _filmService.Update(film, film.Id);

            return RedirectToAction("Index");
        }

        public JsonResult GetProducerList(string searchTerm)
        {
            var list = _producerService.GetAll();
            if (searchTerm != null)
            {
                list = _producerService.SearchProducerByName(searchTerm);
            }
            var modifiedData = list.Select(t => new
            {
                id = t.Id,
                text = t.NameProducer
            });
            return Json(modifiedData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetActorList(string searchTerm)
        {
            var list = _actorService.GetAll();
            if (searchTerm != null)
            {
                list = _actorService.SearchActorByName(searchTerm);
            }
            var modifiedData = list.Select(t => new
            {
                id = t.Id,
                text = t.NameActor
            });
            return Json(modifiedData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDirectorList(string searchTerm)
        {
            var list = _directorService.GetAll();
            if (searchTerm != null)
            {
                list = _directorService.Search(searchTerm);
            }
            var modifiedData = list.Select(t => new
            {
                id = t.Id,
                text = t.NameDirector
            });
            return Json(modifiedData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCategoryList(string searchTerm)
        {
            var list = _categorysService.GetAll();
            if (searchTerm != null)
            {
                list = _categorysService.SearchCategoryByName(searchTerm);
            }
            var modifiedData = list.Select(t => new
            {
                id = t.Id,
                text = t.NameCategory
            });
            return Json(modifiedData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetResolutionList(string searchTerm)
        {
            var list = _resolutionService.GetAll();
            if (searchTerm != null)
            {
                list = _resolutionService.SearchByName(searchTerm);
            }
            var modifiedData = list.Select(t => new
            {
                id = t.Id,
                text = t.NameResolution
            });
            return Json(modifiedData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTagList(string searchTerm)
        {
            var list = _tagService.GetAll();
            if (searchTerm != null)
            {
                list = _tagService.SearchTagByName(searchTerm);
            }
            var modifiedData = list.Select(t => new
            {
                id = t.Id,
                text = t.NameTag
            });
            return Json(modifiedData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPageSearch(int? page)
        {
            int pageSize = VariableUtils.pageSize;

            int pageNumber = (page ?? 1);

            if (Session["KeyWordSearch"] != null)
            {
                var name = Session["KeyWordSearch"].ToString();
                var listMovieSearch = _movieService.SearchFeatureMovieByName(name);

                var listMoviesViewModel = AutoMapper.Mapper.Map<IEnumerable<MoviesViewModel>>(listMovieSearch);

                var listFeatureFilmViewModel = new List<FeatureFilmViewModel>();

                foreach (var item in listMoviesViewModel)
                {
                    var film = _filmService.GetFilmByIdMovie(item.Id);
                    var filmViewModel = AutoMapper.Mapper.Map<FilmViewModel>(film);

                    listFeatureFilmViewModel.Add(new FeatureFilmViewModel()
                    {
                        FilmViewModel = filmViewModel,
                        MoviesViewModel = item
                    });
                }


                return PartialView("_PartialViewFeatureFilm", listFeatureFilmViewModel.ToPagedList(pageNumber, pageSize));
            }

            return PartialView("_PartialViewFeatureFilm",
                _listFeatureFilmViewModels.ToPagedList(pageNumber, pageSize));
        }
    }
}
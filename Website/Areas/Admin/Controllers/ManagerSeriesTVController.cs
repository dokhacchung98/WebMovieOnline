using ApplicationCore.Services;
using Common.Utils;
using Extension.Extensions;
using Infrastructure.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website.ViewModel;

namespace Website.Areas.Admin.Controllers
{
    public class ManagerSeriesTVController : Controller
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

        private IList<SeriesTVViewModel> _listSeriesTV = new List<SeriesTVViewModel>();

        public ManagerSeriesTVController(IMoviesService movieService, IFilmService filmService, IProducerService producerService,
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


            var listMovies = _movieService.GetAllSeriesTV();

            if (!_listSeriesTV.Any())
                foreach (var item in listMovies)
                {
                    var movieViewModel = AutoMapper.Mapper.Map<MoviesViewModel>(item);
                    var listFilm = _filmService.GetAllFilmInSeriesTV(item.Id);
                    var filmViewModel = AutoMapper.Mapper.Map<IList<FilmViewModel>>(listFilm);

                    var model = new SeriesTVViewModel()
                    {
                        MoviesViewModel = movieViewModel,
                        FilmViewModels = filmViewModel
                    };
                    _listSeriesTV.Add(model);
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
            if (_listSeriesTV == null)
            {
                return View();
            }
            return View(_listSeriesTV);
        }


        public ActionResult Create(Guid? id)
        {
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(SeriesTVViewModel viewModel, HttpPostedFileBase image,
                                    IEnumerable<string> actor, IEnumerable<string> director,
                                    IEnumerable<string> category, IEnumerable<string> producer,
                                    IEnumerable<string> resolution, IEnumerable<string> tag)
        {
            var movieViewModel = viewModel.MoviesViewModel;

            var movie = AutoMapper.Mapper.Map<Movie>(movieViewModel);
            movie.IsSeriesMovie = true;

            if (image != null &&
                image.FileName != null &&
                CheckImageUploadExtension.CheckImagePath(image.FileName) == true)
            {
                var path = Path.Combine(Server.MapPath("~/Images/Upload"), image.FileName);
                image.SaveAs(path);
                movie.Thumbnail = VariableUtils.UrlUpLoadImage + image.FileName;
            }

            _movieService.Create(movie);

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

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var movie = _movieService.Find(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }

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
            var movie = _movieService.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            _movieService.Delete(movie);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var movie = _movieService.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var movieViewModel = AutoMapper.Mapper.Map<MoviesViewModel>(movie);

            //Director Start
            var listDirectorMovie = _directorMovieService.GetIdDirectorByMovieId(movie.Id);
            var listDirector = _directorService.GetAll();
            var listDirectorSelect = new List<SelectListItem>();
            foreach (var item in listDirector)
            {
                if (listDirectorMovie.Contains(item.Id))
                {
                    listDirectorSelect.Add(new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = item.NameDirector,
                        Selected = true
                    });
                }
                else
                {
                    listDirectorSelect.Add(new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = item.NameDirector,
                        Selected = false
                    });
                }
            }
            //Director End

            //Actor Start
            var listActorMovie = _actorMovieService.GetIdActorByMovieId(movie.Id);
            var listActor = _actorService.GetAll();
            var listActorSelect = new List<SelectListItem>();
            foreach (var item in listActor)
            {
                if (listActorMovie.Contains(item.Id))
                {
                    listActorSelect.Add(new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = item.NameActor,
                        Selected = true
                    });
                }
                else
                {
                    listActorSelect.Add(new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = item.NameActor,
                        Selected = false
                    });
                }
            }
            //Actor End

            //Producer Start
            var listProducerMovie = _producerMovieService.GetIdProducerByMovieId(movie.Id);
            var listProducer = _producerService.GetAll();
            var listProducerSelect = new List<SelectListItem>();
            foreach (var item in listProducer)
            {
                if (listProducerMovie.Contains(item.Id))
                {
                    listProducerSelect.Add(new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = item.NameProducer,
                        Selected = true
                    });
                }
                else
                {
                    listProducerSelect.Add(new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = item.NameProducer,
                        Selected = false
                    });
                }
            }
            //Producer End

            //Category Start
            var listCategoryMovie = _categoryMovieService.GetIdCategoryByMovieId(movie.Id);
            var listCategory = _categorysService.GetAll();
            var listCategorySelect = new List<SelectListItem>();
            foreach (var item in listCategory)
            {
                if (listCategoryMovie.Contains(item.Id))
                {
                    listCategorySelect.Add(new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = item.NameCategory,
                        Selected = true
                    });
                }
                else
                {
                    listCategorySelect.Add(new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = item.NameCategory,
                        Selected = false
                    });
                }
            }
            //Category End

            //Resolution Start
            var listResolutionMovie = _resolutionMovieService.GetIdResolutionByMovieId(movie.Id);
            var listResolution = _resolutionService.GetAll();
            var listResolutionSelect = new List<SelectListItem>();
            foreach (var item in listResolution)
            {
                if (listResolutionMovie.Contains(item.Id))
                {
                    listResolutionSelect.Add(new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = item.NameResolution,
                        Selected = true
                    });
                }
                else
                {
                    listResolutionSelect.Add(new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = item.NameResolution,
                        Selected = false
                    });
                }
            }
            //Resolution End

            //Tag Start
            var listTagMovie = _tagMovieService.GetIdTagByMovieId(movie.Id);
            var listTag = _tagService.GetAll();
            var listTagSelect = new List<SelectListItem>();
            foreach (var item in listTag)
            {
                if (listResolutionMovie.Contains(item.Id))
                {
                    listTagSelect.Add(new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = item.NameTag,
                        Selected = true
                    });
                }
                else
                {
                    listTagSelect.Add(new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = item.NameTag,
                        Selected = false
                    });
                }
            }
            //Tag End


            ViewBag.ListDirector = listDirectorSelect;
            ViewBag.ListActor = listActorSelect;
            ViewBag.ListProducer = listProducerSelect;
            ViewBag.ListCategory = listCategorySelect;
            ViewBag.ListResolution = listResolutionSelect;
            ViewBag.ListTag = listTagSelect;


            var model = new SeriesTVViewModel()
            {
                MoviesViewModel = movieViewModel
            };

            return View("_Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(SeriesTVViewModel viewModel, HttpPostedFileBase image,
                                IList<string> actor, IList<string> director,
                                IList<string> category, IList<string> producer,
                                IList<string> resolution, IList<string> tag)
        {
            Movie oldMovie = _movieService.Find(viewModel.MoviesViewModel.Id);

            var movie = AutoMapper.Mapper.Map<Movie>(viewModel.MoviesViewModel);
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
            movie.IsSeriesMovie = true;
            _movieService.Update(movie, movie.Id);

            IList<string> _actor = new List<string>();
            if (actor != null)
                foreach (var item in actor)
                {
                    _actor.Add(item);
                }
            var listActorMovie = _actorMovieService.GetIdActorByMovieId(movie.Id);
            foreach (var item in listActorMovie)
            {
                if (!_actor.Contains(item.ToString()))
                {
                    var model = _actorMovieService.FindBy2Id(movie.Id, item);
                    if (model != null)
                    {
                        _actorMovieService.Delete(model);
                    }
                }
                else
                {
                    _actor.Remove(item.ToString());
                }
            }

            IList<string> _director = new List<string>();
            if (director != null)
                foreach (var item in director)
                {
                    _director.Add(item);
                }
            var listDirectorMovie = _directorMovieService.GetIdDirectorByMovieId(movie.Id);
            foreach (var item in listDirectorMovie)
            {
                if (!_director.Contains(item.ToString()))
                {
                    var model = _directorMovieService.FindBy2Id(movie.Id, item);
                    if (model != null)
                    {
                        _directorMovieService.Delete(model);
                    }
                }
                else
                {
                    _director.Remove(item.ToString());
                }
            }

            IList<string> _category = new List<string>();
            if (category != null)
                foreach (var item in category)
                {
                    _category.Add(item);
                }
            var listCategoryMovie = _categoryMovieService.GetIdCategoryByMovieId(movie.Id);
            foreach (var item in listCategoryMovie)
            {
                if (!_category.Contains(item.ToString()))
                {
                    var model = _categoryMovieService.FindBy2Id(movie.Id, item);
                    if (model != null)
                    {
                        _categoryMovieService.Delete(model);
                    }
                }
                else
                {
                    _category.Remove(item.ToString());
                }
            }

            IList<string> _producer = new List<string>();
            if (producer != null)
                foreach (var item in producer)
                {
                    _producer.Add(item);
                }
            var listProducerMovie = _producerMovieService.GetIdProducerByMovieId(movie.Id);
            foreach (var item in listProducerMovie)
            {
                if (!_producer.Contains(item.ToString()))
                {
                    var model = _producerMovieService.FindBy2Id(movie.Id, item);
                    if (model != null)
                    {
                        _producerMovieService.Delete(model);
                    }
                }
                else
                {
                    _producer.Remove(item.ToString());
                }
            }

            IList<string> _resolution = new List<string>();
            if (resolution != null)
                foreach (var item in resolution)
                {
                    _resolution.Add(item);
                }
            var listResolutionMovie = _resolutionMovieService.GetIdResolutionByMovieId(movie.Id);
            foreach (var item in listResolutionMovie)
            {
                if (!_resolution.Contains(item.ToString()))
                {
                    var model = _resolutionMovieService.FindBy2Id(movie.Id, item);
                    if (model != null)
                    {
                        _resolutionMovieService.Delete(model);
                    }
                }
                else
                {
                    _resolution.Remove(item.ToString());
                }
            }

            IList<string> _tag = new List<string>();
            if (tag != null)
                foreach (var item in tag)
                {
                    _tag.Add(item);
                }
            var listTagMovie = _tagMovieService.GetIdTagByMovieId(movie.Id);
            foreach (var item in listTagMovie)
            {
                if (!_tag.Contains(item.ToString()))
                {
                    var model = _tagMovieService.FindBy2Id(movie.Id, item);
                    if (model != null)
                    {
                        _tagMovieService.Delete(model);
                    }
                }
                else
                {
                    _tag.Remove(item.ToString());
                }
            }


            if (_actor != null)
                foreach (var item in _actor)
                {
                    _actorMovieService.Create(new ActorMovie()
                    {
                        ActorId = Guid.Parse(item),
                        MovieId = movie.Id
                    });
                }
            if (_director != null)
                foreach (var item in _director)
                {
                    _directorMovieService.Create(new DirectorMovie()
                    {
                        DirectorId = Guid.Parse(item),
                        MovieId = movie.Id
                    });
                }
            if (_category != null)
                foreach (var item in _category)
                {
                    _categoryMovieService.Create(new CategoryMovie()
                    {
                        CategoryId = Guid.Parse(item),
                        MovieId = movie.Id
                    });
                }
            if (_producer != null)
                foreach (var item in _producer)
                {
                    _producerMovieService.Create(new ProducerMovie()
                    {
                        ProducerId = Guid.Parse(item),
                        MovieId = movie.Id
                    });
                }
            if (_resolution != null)
                foreach (var item in _resolution)
                {
                    _resolutionMovieService.Create(new MovieResolution()
                    {
                        ResolutionId = Guid.Parse(item),
                        MovieId = movie.Id
                    });
                }
            if (_tag != null)
                foreach (var item in _tag)
                {
                    _tagMovieService.Create(new TagMovie()
                    {
                        TagId = Guid.Parse(item),
                        MovieId = movie.Id
                    });
                }
            return RedirectToAction("Index");
        }

        public ActionResult ListFilm(string name, Guid idMovie)
        {
            if (idMovie == null)
            {
                return HttpNotFound();
            }
            var movie = _movieService.Find(idMovie);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var listFilm = _filmService.GetAllFilmInSeriesTV(idMovie);
            var listFilmViewModel = AutoMapper.Mapper.Map<IList<FilmViewModel>>(listFilm);
            var movieViewModel = AutoMapper.Mapper.Map<MoviesViewModel>(movie);
            var viewModel = new SeriesTVViewModel()
            {
                MoviesViewModel = movieViewModel,
                FilmViewModels = listFilmViewModel
            };
            ViewBag.IdMovie = idMovie;
            if (name == null)
            {
                Session["KeyWordSearch"] = null;
            }
            else
            {
                Session["KeyWordSearch"] = name;
            }
            if (viewModel == null)
            {
                return View("_ListFilm");
            }
            return View("_ListFilm", viewModel);
        }


        public ActionResult CreateFilm(Guid idMovie)
        {
            ViewBag.IdMovie = idMovie;
            var listString = new List<string>();
            var listFilms = _filmService.GetAllFilmInSeriesTV(idMovie);
            foreach (var item in listFilms)
            {
                listString.Add(item.Episodes.ToString());
            }
            ViewBag.IdFilms = listString;
            return PartialView("_CreateFilm");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CreateFilm(FilmViewModel viewModel, Guid idMovie)
        {
            if (idMovie == null)
            {
                return HttpNotFound();
            }
            var film = AutoMapper.Mapper.Map<Film>(viewModel);
            film.MovieId = idMovie;
            _filmService.Create(film);

            return RedirectToAction("ListFilm", new { idMovie = idMovie });
        }


        public ActionResult DeleteFilm(Guid? idFilm, Guid idMovie)
        {
            if (idFilm == null)
            {
                return RedirectToAction("Index");
            }
            var film = _filmService.Find(idFilm.Value);
            if (film == null)
            {
                return HttpNotFound();
            }

            ViewBag.IdMovie = idMovie;
            var filmViewModel = AutoMapper.Mapper.Map<FilmViewModel>(film);

            return PartialView("_DeleteFilm", filmViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFilm(Guid idFilm, Guid idMovie)
        {
            if (idFilm == null)
            {
                return RedirectToAction("Index");
            }
            var film = _filmService.Find(idFilm);
            if (film == null)
            {
                return HttpNotFound();
            }

            _filmService.Delete(film);

            return RedirectToAction("ListFilm", new { idMovie = idMovie });
        }


        public ActionResult EditFilm(Guid idFilm, Guid idMovie)
        {
            if (idFilm == null)
            {
                return RedirectToAction("Index");
            }
            var film = _filmService.Find(idFilm);
            if (film == null)
            {
                return HttpNotFound();
            }

            ViewBag.IdMovie = idMovie;

            var filmViewModel = AutoMapper.Mapper.Map<FilmViewModel>(film);

            return PartialView("_EditFilm", filmViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditFilm(FilmViewModel viewModel, Guid idMovie)
        {
            var film = AutoMapper.Mapper.Map<Film>(viewModel);
            film.MovieId = idMovie;

            _filmService.Update(film, film.Id);
            return RedirectToAction("ListFilm", new { idMovie = idMovie });
        }

        public JsonResult CheckEpisodes(string idMovie, string currentId, string value)
        {
            var check = true;
            if (string.IsNullOrEmpty(value))
            {
                check = false;
                return Json(check, JsonRequestBehavior.AllowGet);
            }
            var listFilm = _filmService.GetAllFilmInSeriesTV(Guid.Parse(idMovie));
            if (!string.IsNullOrEmpty(currentId))
            {
                listFilm.Remove(_filmService.Find(Guid.Parse(currentId)));
            }


            foreach (var item in listFilm)
            {
                if (item.Episodes.ToString() == value)
                {
                    check = false;
                    break;
                }
            }

            var movie = _movieService.Find(Guid.Parse(idMovie));
            if (int.Parse(value) > movie.Episodes || int.Parse(value) < 1)
            {
                check = false;
            }
            return Json(check, JsonRequestBehavior.AllowGet);
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

                var listSeriesTViewModel = new List<SeriesTVViewModel>();

                foreach (var item in listMoviesViewModel)
                {
                    var listFilm = _filmService.GetAllFilmInSeriesTV(item.Id);
                    var filmViewModel = AutoMapper.Mapper.Map<IList<FilmViewModel>>(listFilm);

                    listSeriesTViewModel.Add(new SeriesTVViewModel()
                    {
                        FilmViewModels = filmViewModel,
                        MoviesViewModel = item
                    });
                }


                return PartialView("_PartialViewSeriesTV", listSeriesTViewModel.ToPagedList(pageNumber, pageSize));
            }

            return PartialView("_PartialViewSeriesTV",
                _listSeriesTV.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult GetPageSearchFilm(int? page, Guid idMovie)
        {
            int pageSize = VariableUtils.pageSize;

            int pageNumber = (page ?? 1);

            if (idMovie == null)
            {
                return HttpNotFound();
            }
            var movie = _movieService.Find(idMovie);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var listFilm = _filmService.GetAllFilmInSeriesTV(idMovie);
            var listMovieSearch = new List<FilmViewModel>();

            if (Session["KeyWordSearch"] != null)
            {
                var name = Session["KeyWordSearch"].ToString();

                foreach (var item in listFilm)
                {
                    if (item.MovieId == idMovie)
                    {
                        var filmViewModel = AutoMapper.Mapper.Map<FilmViewModel>(item);
                        listMovieSearch.Add(filmViewModel);
                    }
                }
            }
            else
            {
                foreach (var item in listFilm)
                {
                    var filmViewModel = AutoMapper.Mapper.Map<FilmViewModel>(item);
                    listMovieSearch.Add(filmViewModel);
                }
            }
            ViewBag.IdMovie = idMovie;

            return PartialView("_PartialViewFilm",
                listMovieSearch.ToPagedList(pageNumber, pageSize));
        }
    }
}
using ApplicationCore.Services;
using AutoMapper;
using Common.Utils;
using Extension.Extensions;
using Infrastructure.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Website.Configuaration;
using Website.ViewModel;

namespace Website.Areas.Admin.Controllers
{
    [CustomRoleAuthorize(Roles = "Admin")]
    public class ManagerNewsController : Controller
    {
        private readonly INewsService _newsService;
        private readonly IMoviesService _moviesService;

        private IList<NewsViewModel> _listNewsViewModel;

        public ManagerNewsController(INewsService newsService, IMoviesService moviesService)
        {
            _newsService = newsService;
            _moviesService = moviesService;

            var listNews = _newsService.GetAll();
            if (listNews != null)
            {
                _listNewsViewModel = Mapper.Map<IEnumerable<NewsViewModel>>(listNews).ToList();
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
            if (_listNewsViewModel == null)
            {
                return View();
            }
            return View(_listNewsViewModel);
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var news = _newsService.Find(id.Value);

            if (news == null)
            {
                return HttpNotFound();
            }

            var newsViewModel = Mapper.Map<NewsViewModel>(news);
            return View(newsViewModel);
        }

        public ActionResult Create()
        {
            var listMovie = _moviesService.GetAll();
            var listSelect = new List<SelectListItem>();
            if (listMovie != null)
                foreach (var item in listMovie)
                {
                    listSelect.Add(new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = item.Name,
                        Selected = false
                    });
                }

            ViewBag.ListMovie = listSelect;
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(NewsViewModel newsViewModel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                newsViewModel.Id = Guid.NewGuid();

                var news = Mapper.Map<News>(newsViewModel);
                if (image != null)
                {
                    if (CheckImageUploadExtension.CheckImagePath(image.FileName) == true)
                    {
                        var path = Path.Combine(Server.MapPath("~/Images/Upload"), image.FileName);
                        image.SaveAs(path);
                        news.Thumbnail = VariableUtils.UrlUpLoadImage + image.FileName;
                    }
                }
                _newsService.Create(news);

                return RedirectToAction("Index");
            }
            var listMovie = _moviesService.GetAll();
            var listSelect = new List<SelectListItem>();
            if (listMovie != null)
                foreach (var item in listMovie)
                {
                    listSelect.Add(new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = item.Name
                    });
                }

            ViewBag.ListMovie = listSelect;
            return PartialView("_Create", newsViewModel);
        }

        public ActionResult Edit(Guid id)
        {
            var news = _newsService.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }

            var listMovie = _moviesService.GetAll();
            var listSelect = new List<SelectListItem>();
            if (listMovie != null)
                foreach (var item in listMovie)
                {
                    if (item.Id == news.MovieId)
                    {
                        listSelect.Add(new SelectListItem()
                        {
                            Value = item.Id.ToString(),
                            Text = item.Name,
                            Selected = true
                        });
                    }
                    else
                    {
                        listSelect.Add(new SelectListItem()
                        {
                            Value = item.Id.ToString(),
                            Text = item.Name,
                            Selected = false
                        });
                    }
                }

            ViewBag.ListMovie = listSelect;
            var NewsViewModel = Mapper.Map<NewsViewModel>(news);

            return View(NewsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(NewsViewModel newsViewModel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                var oldNews = _newsService.Find(newsViewModel.Id);
                var news = Mapper.Map<News>(newsViewModel);
                if (image != null &&
                    image.FileName != null &&
                    CheckImageUploadExtension.CheckImagePath(image.FileName) == true)
                {
                    var path = Path.Combine(Server.MapPath("~/Images/Upload"), image.FileName);
                    image.SaveAs(path);
                    news.Thumbnail = VariableUtils.UrlUpLoadImage + image.FileName;
                }
                else if (image == null && oldNews.Thumbnail != null)
                {
                    news.Thumbnail = oldNews.Thumbnail;
                }
                _newsService.Update(news, news.Id);
                return RedirectToAction("Index");
            }
            var listMovie = _moviesService.GetAll();
            var listSelect = new List<SelectListItem>();
            if (listMovie != null)
                foreach (var item in listMovie)
                {
                    if (item.Id == newsViewModel.MovieId)
                    {
                        listSelect.Add(new SelectListItem()
                        {
                            Value = item.Id.ToString(),
                            Text = item.Name,
                            Selected = true
                        });
                    }
                    else
                    {
                        listSelect.Add(new SelectListItem()
                        {
                            Value = item.Id.ToString(),
                            Text = item.Name,
                            Selected = false
                        });
                    }
                }

            ViewBag.ListMovie = listSelect;

            return View(newsViewModel);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var news = _newsService.Find(id);

            var newsViewModel = Mapper.Map<NewsViewModel>(news);
            return PartialView("_Delete", newsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            var news = _newsService.Find(id);

            if (news == null)
            {
                return HttpNotFound();
            }

            _newsService.Delete(news);

            return RedirectToAction("Index");
        }

        public ActionResult GetPageSearch(int? page)
        {
            int pageSize = VariableUtils.pageSize;

            int pageNumber = (page ?? 1);

            if (Session["KeyWordSearch"] != null)
            {
                var name = Session["KeyWordSearch"].ToString();
                var listSearch = _newsService.SearchNewsByTitle(name);
                var listSearchModel = Mapper.Map<IEnumerable<NewsViewModel>>(listSearch);
                return PartialView("_PartialViewNews", listSearchModel.ToPagedList(pageNumber, pageSize));
            }

            return PartialView("_PartialViewNews",
                _listNewsViewModel.ToPagedList(pageNumber, pageSize));
        }

    }
}
using ApplicationCore.Services;
using AutoMapper;
using Common.Utils;
using Extension.Extensions;
using Infrastructure.Entities;
using Infrastructure.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using Website.ViewModel;

namespace Website.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ApplicationSignInManager _signInManager;

        private ApplicationUserManager _userManager;

        private readonly IApplicationUserService _userService;

        private readonly IFavoriteMovieService _favoriteMovieService;

        private readonly IMoviesService _moviesService;

        public ManageController()
        {
            
        }

        public ManageController(
            IApplicationUserService userService, 
            IFavoriteMovieService favoriteMovieService,
            IMoviesService moviesService)
        {
            _userService = userService;
            _favoriteMovieService = favoriteMovieService;
            _moviesService = moviesService;
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Manage/Index
        public ActionResult Index(string id)
        {
            var currentUser = _userService.Find(id);

            var currentUserView = Mapper.Map<UpdateUserViewModel>(currentUser);

            return View(currentUserView);
        }

        public ActionResult Edit(UpdateUserViewModel viewUser)
        {
            var user = Mapper.Map<ApplicationUser>(viewUser);
            _userService.UpdateUser(user, user.Id);
            return RedirectToAction("Index", new { user.Id });
        }
        
        public ActionResult ChangePassword(string id)
        {
            var currentUser = _userService.Find(id);
            var changePasswordModel = new ChangePasswordViewModel
            {
                Id = currentUser.Id
            };
            return PartialView("_ChangePassword", changePasswordModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { user.Id });
            }
            AddErrors(result);
            return RedirectToAction("Index", new { model.Id });
        }
        
        public ActionResult SetPassword()
        {
            return View();
        }

        public ActionResult InformationUser(string id)
        {
            var currentUser = _userService.Find(id);

            var currentUserView = Mapper.Map<UpdateUserViewModel>(currentUser);

            return PartialView("_InformationUserPage", currentUserView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeAvatar(UpdateUserViewModel model, HttpPostedFileBase image)
        {
            ApplicationUser currentUser = _userService.Find(model.Id);
            if (currentUser != null &&image != null)
            {
                if (CheckImageUploadExtension.CheckImagePath(image.FileName) == true)
                {
                    var path = Path.Combine(Server.MapPath("~/Images/Upload"), image.FileName);
                    image.SaveAs(path);
                    currentUser.Avatar = VariableUtils.UrlUpLoadImage + image.FileName;
                }
                _userService.Update(currentUser, model.Id);
            }

            return RedirectToAction("Index", new { @id = model.Id});
            
        }

        public ActionResult FavoriteMovie(string id)
        {
            var favoriteMovies = _favoriteMovieService.GetFavoriteMoviesByUserId(id);

            ICollection<Movie> movies = new List<Movie>();

            foreach (var favoriteMovie in favoriteMovies)
            {
                var movie = _moviesService.Find(favoriteMovie.MovieId);
                movies.Add(movie);
            }

            var favoriteMovieViewModels = AutoMapper.Mapper.Map<IEnumerable<MoviesViewModel>>(movies);
            return PartialView("_FavoriteMoviePage", favoriteMovieViewModels);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

        #region Helpers

        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        #endregion Helpers
    }
}
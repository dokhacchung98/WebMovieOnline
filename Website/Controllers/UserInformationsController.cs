using ApplicationCore.Services;
using Infrastructure.Entities;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class UserInformationsController : Controller
    {
        private readonly IUserInformationService _service;

        public UserInformationsController
        (
           IUserInformationService userInformationService
        )
        {
            _service = userInformationService;
        }

        // GET: UserInformations
        public ActionResult Index()
        {
            var users = _service.GetAll();
            return View(users);
        }

        public ActionResult Create(UserInformation userInformation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.Create(userInformation);
                }
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }
    }
}
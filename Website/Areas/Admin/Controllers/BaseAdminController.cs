using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Areas.Admin.Controllers
{
    public class BaseAdminController : Controller
    {
        // GET: Admin/BaseAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadImage(HttpPostedFileBase image)
        {
            var path = "";
            if (image!=null && image.ContentLength>0)
            {
                if (Path.GetExtension(image.FileName).ToLower()==".jpg"
                    || Path.GetExtension(image.FileName).ToLower() == ".png"
                    || Path.GetExtension(image.FileName).ToLower() == ".gif"
                    || Path.GetExtension(image.FileName).ToLower() == ".jpeg")
                {
                    path = Path.Combine(Server.MapPath("~/Images/Upload"),image.FileName);
                    image.SaveAs(path);
                    ViewBag.UploadSuccess = true;
                }
            }
            return View();
        }
    }
}
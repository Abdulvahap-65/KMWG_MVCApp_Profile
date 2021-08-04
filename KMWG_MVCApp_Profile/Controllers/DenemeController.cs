using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KMWG_MVCApp_Profile.Controllers
{
    public class DenemeController : Controller
    {
        // GET: Deneme
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                if (file.ContentLength > 0)
                {
                    //var fileName = Path.GetFileName(file.FileName);vardı yorum satırı yaptım
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), file.FileName);
                    file.SaveAs(path);
                    TempData["result"] = "Güncelleme Başarılı.";/*Burda yoktu ekledim*/
                }

            }

            return RedirectToAction("Index");
        }
    }
}
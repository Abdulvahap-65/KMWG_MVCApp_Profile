using KMWG_MVCApp_Profile.DB_1;
using KMWG_MVCApp_Profile.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace KMWG_MVCApp_Profile.Controllers
{

    public class HomeController : Controller
    {
        MvgMvcDBEntities db;
        public HomeController()
        {
            db = new MvgMvcDBEntities();
        }
        // GET: Home
        //http://localhost:52552/Home/Index?adi=Vahap
        [HttpGet]
        public ActionResult Index()
        {
            HomeModel m = new HomeModel();
            m.Title = "Hello MVC";
            m.Date = DateTime.Today;
            m.Items = new List<string>();
            m.Items.Add("Bu bir anasayfadır");
            m.Items.Add("Home Controlller içerisindeki Index Action'dur.");
            m.Items.Add("Bu sayfa bir model ile dolmaktadır.");
            List<User> lastUsers = db.User.OrderByDescending(x => x.Id).Take(4).ToList();
            ViewBag.LastUsers = lastUsers;
            return View(m);
        }
        [HttpPost]
        public ActionResult Index(DB_1.User user)
        {
            if (db.User.Any(x => x.UserName == user.UserName && x.Password == user.Password))
            {
                var sessionUser = db.User.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
                Session["LogonUser"] = sessionUser;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Profile(int id = 10)
        {
            if (Session["LogonUser"] == null)
            {
                return RedirectToAction("Index");
            }
            var currentUser = (DB_1.User)Session["LogonUser"];
            DB_1.User user = db.User.FirstOrDefault(x => x.Id == currentUser.Id);
            List<SelectListItem> list = db.UserGroup.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            //ViewData["KullaniciGruplari"] = list;
            ViewBag.KullaniciGruplari = list;

            ViewBag.LastUsers = db.User.OrderByDescending(x => x.Id).Take(4).ToList();
            return View(user);
        }
        [HttpPost]
        public ActionResult Profile(/*DB_1.User user*/IEnumerable<HttpPostedFileBase> files)
        {
            //db.Entry<DB_1.User>(user).State=System.Data.Entity.EntityState.Modified;
            //var uFile = Request.Files.Get("uploadPhoto");
            //if (uFile !=null && uFile.ContentLength>0)
            //{
            //    using (MemoryStream ms=new MemoryStream())
            //    {
            //        uFile.InputStream.CopyTo(ms);
            //        user.Photo = ms.ToArray();
            //    }
            //}
            //else
            //{
            //    db.Entry<DB_1.User>(user).Property(x => x.Photo).IsModified = false;
            //}
            //db.SaveChanges();
            //return RedirectToAction("Profile");

            //string text2 = "files";
            //string text2_clear = SeoFriendlyLink.FriendlyURLTitle(text2) + ".jpeg";
            foreach (var file in files)
            {

             
                if (file != null && file.ContentLength > 0)
                {
                    string tmp_filename = Path.GetFileNameWithoutExtension(file.FileName);
                    string tmp_extension = Path.GetExtension(file.FileName);
                 
                    string pathToCheck = Path.Combine(Server.MapPath("~/App_Data/uploads"), SeoFriendlyLink.FriendlyURLTitle(tmp_filename) + tmp_extension);
                    string tempfileName = "";
                    string filename = Path.GetFileName(file.FileName);

                    if (System.IO.File.Exists(pathToCheck)==true)
                    {
                        int counter = 2;
                        pathToCheck = Path.Combine(Server.MapPath("~/App_Data/uploads"), SeoFriendlyLink.FriendlyURLTitle(tmp_filename) + "_" + counter + tmp_extension);

                        while (System.IO.File.Exists(pathToCheck)==true)
                        {
                            counter++;
                            pathToCheck = Path.Combine(Server.MapPath("~/App_Data/uploads"), SeoFriendlyLink.FriendlyURLTitle(tmp_filename) + "_" + counter + tmp_extension);
                            
                        }

                      
                    }
                    else
                    {
              
                        TempData["result"] = "Your file was uploaded successfully.";
                        file.SaveAs(pathToCheck);

                    }
                    file.SaveAs(pathToCheck);

                }

            }

            return RedirectToAction("Index");


        }
        public ActionResult Logout()
        {
            Session["LogonUser"] = null;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Index1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index1(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/UploadFiles"), file.FileName);
                file.SaveAs(path);
                TempData["result"] = "Güncelleme Başarılı.";
            }

            return View();

        }

    }

}

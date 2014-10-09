using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicListApp.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login()
        {
            Session.Clear();
            //Session["LogedUserID"] = "";
            //Session["LogedUserFullname"] = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(TBL_LOGIN u)
        {
            // this action is for handle post (login)
            if (ModelState.IsValid) // this is check validity
            {
                using (AlbumDBEntities dc = new AlbumDBEntities())
                {
                    //var l = dc.TBL_LOGIN.Where(a => a.UserName.Equals()
                    var v = dc.TBL_LOGIN.Where(a => a.UserName.Equals(u.UserName) && a.Password.Equals(u.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.UserID.ToString();
                        Session["LogedUserFullname"] = v.FullName.ToString();
                        Session["HakAkses"] = v.HakAkses.ToString();
                        //return RedirectToAction("AfterLogin");
                        return RedirectToAction("Index", "Album");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The email or password you entered is incorrect.");
                        return View(u);
                    }
                }
            }
            return View(u);

        }

        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}

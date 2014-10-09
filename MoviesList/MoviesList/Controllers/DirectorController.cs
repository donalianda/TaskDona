using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesList.Controllers
{
    public class DirectorController : Controller
    {
        private MoviesDbEntities db = new MoviesDbEntities();

        //
        // GET: /Director/

        public ActionResult Index()
        {
            return View(db.MST_DIRECTOR.ToList());
        }

        //
        // GET: /Director/Details/5

        public ActionResult Details(int id = 0)
        {
            MST_DIRECTOR mst_director = db.MST_DIRECTOR.Find(id);
            if (mst_director == null)
            {
                return HttpNotFound();
            }
            return View(mst_director);
        }

        //
        // GET: /Director/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Director/Create

        [HttpPost]
        public ActionResult Create(MST_DIRECTOR mst_director)
        {
            if (ModelState.IsValid)
            {
                db.MST_DIRECTOR.Add(mst_director);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mst_director);
        }

        //
        // GET: /Director/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MST_DIRECTOR mst_director = db.MST_DIRECTOR.Find(id);
            if (mst_director == null)
            {
                return HttpNotFound();
            }
            return View(mst_director);
        }

        //
        // POST: /Director/Edit/5

        [HttpPost]
        public ActionResult Edit(MST_DIRECTOR mst_director)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mst_director).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mst_director);
        }

        //
        // GET: /Director/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MST_DIRECTOR mst_director = db.MST_DIRECTOR.Find(id);
            if (mst_director == null)
            {
                return HttpNotFound();
            }
            return View(mst_director);
        }

        //
        // POST: /Director/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MST_DIRECTOR mst_director = db.MST_DIRECTOR.Find(id);
            db.MST_DIRECTOR.Remove(mst_director);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
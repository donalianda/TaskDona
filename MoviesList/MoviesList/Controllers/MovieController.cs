using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MoviesList.Models;

namespace MoviesList.Controllers
{
    public class MovieController : Controller
    {
        private MoviesDbEntities db = new MoviesDbEntities();

        //
        // GET: /Movie/

        public ActionResult Index()
        {
            ViewBag.CallJoin = db.SP_JOIN_MOVIE();
            return View();
           //return View(db.MST_MOVIE.ToList());

            //MST_MOVIE movie = new MST_MOVIE();
            //movie.mst_movie = (from p in db.MST_MOVIE select p).ToList();
            //movie.mst_director = (from q in db.MST_DIRECTOR select q).ToList();

            //return View(movie);

            //var listMovie = this.db.MST_MOVIE.Include(x => x.ID_Director);
            //return this.View(listMovie.ToList());
        }

        public ActionResult sp_join()
        {
            ViewBag.CallJoin = db.SP_JOIN_MOVIE();
            return View();
        }

        public ActionResult sp_join2()
        {
            ViewBag.SP_JOIN_MOVIE = db.SP_JOIN_MOVIE();
            return View();
        }
        //
        // GET: /Movie/Details/5

        public ActionResult Details(int id = 0)
        {
            MST_MOVIE mst_movie = db.MST_MOVIE.Find(id);
            if (mst_movie == null)
            {
                return HttpNotFound();
            }
            return View(mst_movie);
        }

        //
        // GET: /Movie/Create

        public ActionResult Create()
        {
            ViewBag.ID_Director = new SelectList(db.MST_DIRECTOR, "ID_Director", "Director");
            return View();
        }

        //
        // POST: /Movie/Create

        [HttpPost]
        public ActionResult Create(MST_MOVIE mst_movie)
        {
            if (ModelState.IsValid)
            {
                db.MST_MOVIE.Add(mst_movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mst_movie);
        }

        //
        // GET: /Movie/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MST_MOVIE mst_movie = db.MST_MOVIE.Find(id);
            if (mst_movie == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ID_Director = new SelectList(db.MST_DIRECTOR, "ID_Director", "Director");
            this.ViewBag.ID_Director = new SelectList(this.db.MST_DIRECTOR, "ID_Director", "Director", mst_movie.ID_Director);
            return View(mst_movie);
            
        }

        //
        // POST: /Movie/Edit/5

        [HttpPost]
        public ActionResult Edit(MST_MOVIE mst_movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mst_movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ID_Director = new SelectList(db.MST_DIRECTOR, "ID_Director", "Director");
            this.ViewBag.ID_Director = new SelectList(this.db.MST_DIRECTOR, "ID_Director", "Director", mst_movie.ID_Director);
            return View(mst_movie);
        }

        //
        // GET: /Movie/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MST_MOVIE mst_movie = db.MST_MOVIE.Find(id);
            if (mst_movie == null)
            {
                return HttpNotFound();
            }
            return View(mst_movie);
        }

        //
        // POST: /Movie/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MST_MOVIE mst_movie = db.MST_MOVIE.Find(id);
            db.MST_MOVIE.Remove(mst_movie);
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
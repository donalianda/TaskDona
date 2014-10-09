using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicListApp.Controllers
{
    public class ArtistController : Controller
    {
        private AlbumDBEntities db = new AlbumDBEntities();

        //
        // GET: /Artist/

        public ActionResult Index()
        {
            return View(db.MST_ARTIST.ToList());
        }

        //
        // GET: /Artist/Details/5

        public ActionResult Details(int id = 0)
        {
            MST_ARTIST mst_artist = db.MST_ARTIST.Find(id);
            if (mst_artist == null)
            {
                return HttpNotFound();
            }
            return View(mst_artist);
        }

        //
        // GET: /Artist/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Artist/Create

        [HttpPost]
        public ActionResult Create(MST_ARTIST mst_artist)
        {
            if (ModelState.IsValid)
            {
                db.MST_ARTIST.Add(mst_artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mst_artist);
        }

        //
        // GET: /Artist/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MST_ARTIST mst_artist = db.MST_ARTIST.Find(id);
            if (mst_artist == null)
            {
                return HttpNotFound();
            }
            return View(mst_artist);
        }

        //
        // POST: /Artist/Edit/5

        [HttpPost]
        public ActionResult Edit(MST_ARTIST mst_artist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mst_artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mst_artist);
        }

        //
        // GET: /Artist/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MST_ARTIST mst_artist = db.MST_ARTIST.Find(id);
            if (mst_artist == null)
            {
                return HttpNotFound();
            }
            return View(mst_artist);
        }

        //
        // POST: /Artist/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MST_ARTIST mst_artist = db.MST_ARTIST.Find(id);
            db.MST_ARTIST.Remove(mst_artist);
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
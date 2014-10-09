using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicListApp.Controllers
{
    public class AlbumController : Controller
    {
        private AlbumDBEntities db = new AlbumDBEntities();

        //
        // GET: /Album/

        public ActionResult Index()
        {
            ViewBag.MusicJoin = db.SP_ALBUM();
            return View();
            //return View(db.TRANSACT_ALBUM.ToList());
        }

        public ActionResult SearchIndex(string searchString)
        {
            var album = from alb in db.TRANSACT_ALBUM
                        select alb;
            if(!string.IsNullOrEmpty(searchString))
            {
                album = album.Where(s => s.Title.Contains(searchString));
            }

            return View(album);
        }

        public ActionResult SearchAlbumByTitle(string searchStringTitle)
        {
            ViewBag.AlbumByTitle = db.SP_ALBUM_BY_TITLE(searchStringTitle);
            return View();
            //var test = db.Database.SqlQuery<AlbumDBEntities>("exec SP_ALBUM_BY_TITLE N'" + searchStringTitle + "'");
            //ViewBag.AlbumByTitle = test;
            //return View();
        }

        //
        // GET: /Album/Details/5

        public ActionResult Details(int id = 0)
        {
            TRANSACT_ALBUM transact_album = db.TRANSACT_ALBUM.Find(id);
            if (transact_album == null)
            {
                return HttpNotFound();
            }
            return View(transact_album);
        }

        //
        // GET: /Album/Create

        public ActionResult Create()
        {
            this.ViewBag.GenreID = new SelectList(this.db.MST_GENRE, "GenreID", "Genre");
            this.ViewBag.ArtistID = new SelectList(this.db.MST_ARTIST, "ArtistID", "ArtistName");

            return View();
        }

        //
        // POST: /Album/Create

        [HttpPost]
        public ActionResult Create(TRANSACT_ALBUM transact_album)
        {
            if (ModelState.IsValid)
            {
                db.TRANSACT_ALBUM.Add(transact_album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transact_album);
        }

        //
        // GET: /Album/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TRANSACT_ALBUM transact_album = db.TRANSACT_ALBUM.Find(id);
            if (transact_album == null)
            {
                return HttpNotFound();
            }

            
            this.ViewBag.GenreID = new SelectList(this.db.MST_GENRE, "GenreID", "Genre", transact_album.GenreID);
            this.ViewBag.ArtistID = new SelectList(this.db.MST_ARTIST, "ArtistID", "ArtistName", transact_album.ArtistID);
            return View(transact_album);
        }

        //
        // POST: /Album/Edit/5

        [HttpPost]
        public ActionResult Edit(TRANSACT_ALBUM transact_album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transact_album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transact_album);
            
        }

        //
        // GET: /Album/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TRANSACT_ALBUM transact_album = db.TRANSACT_ALBUM.Find(id);
            if (transact_album == null)
            {
                return HttpNotFound();
            }
            return View(transact_album);
        }

        //
        // POST: /Album/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TRANSACT_ALBUM transact_album = db.TRANSACT_ALBUM.Find(id);
            db.TRANSACT_ALBUM.Remove(transact_album);
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
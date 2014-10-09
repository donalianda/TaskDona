﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicListApp.Controllers
{
    public class GenreController : Controller
    {
        private AlbumDBEntities db = new AlbumDBEntities();

        //
        // GET: /Genre/

        public ActionResult Index()
        {
            return View(db.MST_GENRE.ToList());
        }

        //
        // GET: /Genre/Details/5

        public ActionResult Details(int id = 0)
        {
            MST_GENRE mst_genre = db.MST_GENRE.Find(id);
            if (mst_genre == null)
            {
                return HttpNotFound();
            }
            return View(mst_genre);
        }

        //
        // GET: /Genre/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Genre/Create

        [HttpPost]
        public ActionResult Create(MST_GENRE mst_genre)
        {
            if (ModelState.IsValid)
            {
                db.MST_GENRE.Add(mst_genre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mst_genre);
        }

        //
        // GET: /Genre/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MST_GENRE mst_genre = db.MST_GENRE.Find(id);
            if (mst_genre == null)
            {
                return HttpNotFound();
            }
            return View(mst_genre);
        }

        //
        // POST: /Genre/Edit/5

        [HttpPost]
        public ActionResult Edit(MST_GENRE mst_genre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mst_genre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mst_genre);
        }

        //
        // GET: /Genre/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MST_GENRE mst_genre = db.MST_GENRE.Find(id);
            if (mst_genre == null)
            {
                return HttpNotFound();
            }
            return View(mst_genre);
        }

        //
        // POST: /Genre/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MST_GENRE mst_genre = db.MST_GENRE.Find(id);
            db.MST_GENRE.Remove(mst_genre);
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
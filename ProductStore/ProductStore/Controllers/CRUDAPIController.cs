using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ProductStore.Controllers
{
    public class CRUDAPIController : ApiController
    {
        private AlbumDBEntities db = new AlbumDBEntities();

        // GET api/CRUDAPI
        public IEnumerable<TRANSACT_ALBUM> GetTRANSACT_ALBUM()
        {
            return db.TRANSACT_ALBUM.AsEnumerable();
        }

        public IEnumerable<TRANSACT_ALBUM> GETBySearchCriteria(int searchString)
        {
            //var searchQuery = from alb in db.TRANSACT_ALBUM
            //                  select alb;
            //searchQuery = searchQuery.Where(s => s.AlbumID.
            return db.TRANSACT_ALBUM.Where(s => s.AlbumID == searchString).AsEnumerable();
        }

        // GET api/CRUDAPI/5
        public TRANSACT_ALBUM GetTRANSACT_ALBUM(int id)
        {
            TRANSACT_ALBUM transact_album = db.TRANSACT_ALBUM.Find(id);
            if (transact_album == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return transact_album;
        }

        // PUT api/CRUDAPI/5
        public HttpResponseMessage PutTRANSACT_ALBUM(int id, TRANSACT_ALBUM transact_album)
        {
            if (ModelState.IsValid && id == transact_album.AlbumID)
            {
                db.Entry(transact_album).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/CRUDAPI
        public HttpResponseMessage PostTRANSACT_ALBUM(TRANSACT_ALBUM transact_album)
        {
            if (ModelState.IsValid)
            {
                db.TRANSACT_ALBUM.Add(transact_album);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, transact_album);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = transact_album.AlbumID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/CRUDAPI/5
        public HttpResponseMessage DeleteTRANSACT_ALBUM(int id)
        {
            TRANSACT_ALBUM transact_album = db.TRANSACT_ALBUM.Find(id);
            if (transact_album == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.TRANSACT_ALBUM.Remove(transact_album);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, transact_album);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
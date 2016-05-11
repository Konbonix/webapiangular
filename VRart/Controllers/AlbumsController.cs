using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using VRart.Models;
using VRart.Dal;

namespace VRart.Controllers
{
    public class AlbumsController : ApiController
    {

        private IArtRepository _repo;

        public AlbumsController(IArtRepository repo)
        {
            _repo = repo;
        }

        // api/albums
        public IEnumerable<Album> Get()
        {
            return _repo.GetAlbums();
        }

        //api/albums/id
        public HttpResponseMessage Get(int id)
        {
            //TODO: bool include uploads and different method
            var album = _repo.GetAlbums(id);
            if (album != null) return Request.CreateResponse(HttpStatusCode.OK, album);

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage Post([FromBody]Album newAlbum)
        {
            if (newAlbum.Created == default(DateTime))
            {
                newAlbum.Created = DateTime.UtcNow;
            } 
            if (_repo.AddAlbum(newAlbum) && _repo.Save())
            {
                //return 200 
                return Request.CreateResponse(HttpStatusCode.Created, newAlbum);
            }

            //return 500 failure
            return Request.CreateResponse(HttpStatusCode.BadRequest);

        }

        /* Web API default EF 
         
        private ArtContext db = new ArtContext();

        // GET: api/Albums
        public IQueryable<Album> GetAlbums()
        {
            return db.Albums;
        }

        // GET: api/Albums/5
        [ResponseType(typeof(Album))]
        public async Task<IHttpActionResult> GetAlbum(int id)
        {
            Album album = await db.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        // PUT: api/Albums/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAlbum(int id, Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != album.Id)
            {
                return BadRequest();
            }

            db.Entry(album).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Albums
        [ResponseType(typeof(Album))]
        public async Task<IHttpActionResult> PostAlbum(Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Albums.Add(album);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = album.Id }, album);
        }

        // DELETE: api/Albums/5
        [ResponseType(typeof(Album))]
        public async Task<IHttpActionResult> DeleteAlbum(int id)
        {
            Album album = await db.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            db.Albums.Remove(album);
            await db.SaveChangesAsync();

            return Ok(album);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlbumExists(int id)
        {
            return db.Albums.Count(e => e.Id == id) > 0;
        }

    */
    }
}
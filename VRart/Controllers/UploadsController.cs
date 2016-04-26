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
using VRart.Dal;
using VRart.Models;

namespace VRart.Controllers
{
    public class UploadsController : ApiController
    {
        private IArtRepository _repo;

        public UploadsController(IArtRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Upload> Get(int albumid)
        {
            return _repo.GetUploadsByAlbumId(albumid);
        }


        // POST: api/Uploads
        public HttpResponseMessage Post(int albumId, [FromBody]Upload newUpload)
        {
            if (newUpload.Created == default(DateTime))
            {
                newUpload.Created = DateTime.UtcNow;
            }
            newUpload.AlbumId = albumId;

            if (_repo.AddUpload(newUpload) && _repo.Save())
            {
                //return 200 
                return Request.CreateResponse(HttpStatusCode.Created, newUpload);
            }

            //return 500 failure
            return Request.CreateResponse(HttpStatusCode.BadRequest);

        }
    }
}
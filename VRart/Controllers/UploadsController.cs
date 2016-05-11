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
using VRart.Extensions;

namespace VRart.Controllers
{
    public class UploadsController : ApiController
    {
        private IArtRepository _repo;

        public UploadsController(IArtRepository repo)
        {
            _repo = repo;
        }

        public HttpResponseMessage Get()
        {
            var uploads = _repo.GetUploads();
            if (uploads != null) return Request.CreateResponse(HttpStatusCode.OK, uploads);

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage Get(int id)
        {
            var uploads = _repo.GetUploads();
            if (uploads != null) return Request.CreateResponse(HttpStatusCode.OK, uploads);

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // POST: api/Uploads
        //public HttpResponseMessage Post(int albumId, [FromBody]Upload newUpload)
        //{
        //    if (newUpload.Created == default(DateTime))
        //    {
        //        newUpload.Created = DateTime.UtcNow;
        //    }
        //    newUpload.AlbumId = albumId;

        //    if (_repo.AddUpload(newUpload) && _repo.Save())
        //    {
        //        //return 200 
        //        return Request.CreateResponse(HttpStatusCode.Created, newUpload);
        //    }

        //    //return 500 failure
        //    return Request.CreateResponse(HttpStatusCode.BadRequest);

        //}
        //TODO - Change angular package to ng-file-upload https://github.com/danialfarid/ng-file-upload, Validation, Save&Bind, 
        [HttpPost]
        [Route("uploads")]
        public async Task<HttpResponseMessage> UploadFile(HttpRequestMessage request)
        {
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var data = await Request.Content.ParseMultipartAsync();

            if (data.Files.ContainsKey("file"))
            {
                var file = data.Files["file"].File;
                var fileName = data.Files["file"].Filename;
            }

            if (data.Fields.ContainsKey("description"))
            {
                var description = data.Fields["description"].Value;
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("Thank you for uploading the file...")
            };
        }


    }
}
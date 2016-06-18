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
using VRart.Services;
using System.Web.Http.Cors;

namespace VRart.Controllers
{

    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
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

        // /api/uploads/
        [HttpPost]
        //[Route("api/uploads")] 
        public async Task<HttpResponseMessage> UploadFile(HttpRequestMessage request)
        {
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var data = await Request.Content.ParseMultipartAsync();

            string responseAlbumUrl = "not created";
            //#TODO - Validate extention is .tilt server side
            if (data.Files.ContainsKey("file"))
            {
                byte[] tiltUpload = data.Files["file"].File;
                //Create new upload
                responseAlbumUrl = _repo.AddTiltUploadAndAlbum(tiltUpload); 
            }

            //if (data.Fields.ContainsKey("description"))
            //{
            //    var description = data.Fields["description"].Value;
            //}


            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(responseAlbumUrl)//new StringContent("Thank you for uploading the file...")
            };
        }


    }
}
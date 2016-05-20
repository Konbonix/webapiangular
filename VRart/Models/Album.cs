using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VRart.Services;

namespace VRart.Models
{
    public class Album
    {
        public Album()
        {
            AlbumUrl = UploadServices.GetRandomAlbumUrl();
            //Uploads = new List<Upload>();
            Created = DateTime.UtcNow;
        }
        public int AlbumId { get; set; }
        public string AlbumUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

        public ICollection<Upload> Uploads { get; set; }
    }
}
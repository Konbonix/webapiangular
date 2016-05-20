using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VRart.Services;

namespace VRart.Models
{
    public class Upload
    {

        public Upload()
        {
            Created = DateTime.UtcNow;
            FileName = UploadServices.GetRandomFileName();
        }

        public int UploadId { get; set; }

        [Required]
        public string Title { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set;  }

        public DateTime Created { get; set; }

        //FK to Album
        public int AlbumId { get; set; }
    }
}
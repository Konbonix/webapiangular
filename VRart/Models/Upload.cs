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
        }

        public int UploadId { get; set; }

        [Required]
        public string FileName { get; set; }
        //File path should be dropped? Enviornment dependency
        [Required]
        public string FilePath { get; set;  }
        public string ThumbNail { get; set; }
        public DateTime Created { get; set; }

        //FK to Album
        public int AlbumId { get; set; }
    }
}
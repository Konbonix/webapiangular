using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VRart.Models
{
    public class Upload
    {

        public Upload()
        {
            Created = DateTime.UtcNow;
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set;  }

        public DateTime Created { get; set; }

        public int AlbumId { get; set; }
    }
}
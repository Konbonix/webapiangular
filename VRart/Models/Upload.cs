using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VRart.Models
{
    public class Upload
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }

        public int AlbumId { get; set; }
    }
}
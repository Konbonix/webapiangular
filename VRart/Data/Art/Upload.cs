using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VRart.Data.Art
{
    public class Upload
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }

        public int AlbumID { get; set; }
    }
}
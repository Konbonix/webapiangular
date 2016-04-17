using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VRart.Data.Art
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

        public ICollection<Upload> Uploads { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VRart.Models
{
    public class Album
    {
        public Album()
        {
            Uploads = new List<Upload>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

        public ICollection<Upload> Uploads { get; set; }
    }
}
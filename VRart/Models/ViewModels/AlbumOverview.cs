using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VRart.Models
{
    public class AlbumOverview
    {
        public string AlbumUrl { get; set; }
        public string ThumbnailPath { get; set; }
        public string DownloadPath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
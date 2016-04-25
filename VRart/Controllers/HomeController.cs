using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VRart.Dal;

namespace VRart.Controllers
{
    public class HomeController : Controller
    {
        private IArtRepository _repo;

        public HomeController(IArtRepository repo)
        {
            _repo = repo;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var albums = _repo.GetAlbums().OrderByDescending(a => a.Created).Take(25).ToList();
            return View(albums);  
        }
    }
}

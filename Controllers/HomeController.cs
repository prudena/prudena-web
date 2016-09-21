using Microsoft.AspNetCore.Mvc;
using Prudena.Web.Models;
using System.Linq;
using System.Collections.Generic;

namespace Prudena.Web.Controllers
{
    public class HomeController : Controller
    {
        private BurnuliDBContext _db;
        public HomeController(BurnuliDBContext db)
            : base()
        { 
            _db = db;            
        }
        
        public IActionResult Index()
        {
            @ViewData["SiteName"] = "Prudena";
            //List<SystemUser> t = _db.SystemUsers.Take(10).ToList();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

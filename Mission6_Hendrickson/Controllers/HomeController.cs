using Microsoft.AspNetCore.Mvc;
using Mission6_Hendrickson.Models;
using SQLitePCL;
using System.Diagnostics;

namespace Mission6_Hendrickson.Controllers
{

    public class HomeController : Controller
    {
        private MovieContext _context;

        public HomeController(MovieContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Information()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Movie(MovieModel response)
        {
            _context.Movies.Add(response); // add record to the database
            _context.SaveChanges();

            ModelState.Clear(); //clear the fields in the form before rending the view again 

            return View();
        }
    }
}

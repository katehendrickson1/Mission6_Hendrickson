using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_Hendrickson.Models;
using SQLitePCL;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

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
            ViewBag.Categories = _context.Categories.
            OrderBy(x => x.CategoryName)
            .ToList();

            return View("Movie", new MovieModel()); // add "new MovieModel() to create an instance of the movie each time a film is entered. This will make it so the movieId field is not null and auto scales
        }

        [HttpPost]
        public IActionResult Movie(MovieModel response)
        {
            ViewBag.Categories = _context.Categories.
            OrderBy(x => x.CategoryName)
            .ToList();

            // add data validation feature modelstateisvalid

            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // add record to the database
                _context.SaveChanges();

                ModelState.Clear(); //clear the fields in the form before rending the view again 

                return View();
            }
            else
            {
                return View(response);
            }
        }

        public IActionResult MovieList()
        {
            var movies = _context.Movies.Include(m => m.Category)
                .OrderBy(x=> x.Year) .ToList();

            return View(movies);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories. // load up category infor here too 
            OrderBy(x => x.CategoryName)
            .ToList();

            return View("Movie", recordToEdit); // returns user to movie form cshtml after clicking edit

        }
        [HttpPost]
        public IActionResult Edit(MovieModel updatedInfo)
        {

            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieList");


        }

        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                            .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories. // load up category infor here too 
            OrderBy(x => x.CategoryName)
            .ToList();

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(MovieModel movie)
        {

            _context.Movies.Remove(movie); //set up the action without making it permanent
            _context.SaveChanges(); // make the change permanent in the database

            return RedirectToAction("MovieList");


        }
    }
}

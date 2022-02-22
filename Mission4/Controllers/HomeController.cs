using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private MovieInfoContext miContext { get; set; }

        //Constructor
        public HomeController(MovieInfoContext someName)
        {
            miContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm ()
        {
            ViewBag.Categories = miContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult MovieForm (MovieResponse mr)
        {
            if (ModelState.IsValid)
            {
                miContext.Add(mr);
                miContext.SaveChanges();

                return View("Confirmation", mr);
            }
            else //If Invalid
            {
                ViewBag.Categories = miContext.Categories.ToList();

                return View();
            }

        }

        [HttpGet]
        public IActionResult Collection()
        {
            var applications = miContext.Responses
                .Include(x => x.Category)
                .ToList();
            
            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit (int movieid)
        {
            ViewBag.Categories = miContext.Categories.ToList();

            var application = miContext.Responses.Single(x => x.MovieId == movieid);

            return View("MovieForm", application);
        }

        [HttpPost]
        public IActionResult Edit (MovieResponse blah)
        {
            miContext.Update(blah);
            miContext.SaveChanges();

            return RedirectToAction("Collection");
        }

        [HttpGet]
        public IActionResult Delete (int movieid)
        {
            var application = miContext.Responses.Single(x => x.MovieId == movieid);
            
            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(MovieResponse mr)
        {
            miContext.Responses.Remove(mr);
            miContext.SaveChanges();

            return RedirectToAction("Collection");
        }
    }
}

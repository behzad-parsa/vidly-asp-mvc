using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies / Random
        public ActionResult Random()
        {

            var movie = new Movie() { Name = "Avengers" };
            List<Customer> customerList = new List<Customer>
            {
                new Customer() { Name = "Behzad Parsa" },
                new Customer() { Name = "Tom Hanks" },
                new Customer() { Name = "Tom Cruise" },
                new Customer() { Name = "Emilia Clark" },
                new Customer() { Name = "Daniel Day Lweis" },
                new Customer() { Name = "Michelle Mongahana" }

            };



            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customerList
            };






            //return View(movie);
            return View(viewModel);
        }




        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();


            return View(movies);
        }

        //private IEnumerable<Movie> GetMovies()
        //{

        //    return new List<Movie>()
        //    {
        //        new Movie(){Id=1 , Name="Mission Impossible"},
        //        new Movie(){Id=2 , Name="Dune"},
        //        new Movie(){Id=3 , Name="Batman"}
        //    };
        //}

    }
}
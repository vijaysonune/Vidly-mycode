using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.DAL;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {

        private VidlyDb _Context;

        public MovieController()
        {
            _Context = new VidlyDb();
        }

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }

        // GET: Movie
        public ActionResult Index()
        {
            var models = _Context.Movies.ToList();

                   

            return View(models);
        }

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Life Of PI" };
            var customers = new List<Customer>
            { new Customer{Name="Customer 1"},
              new Customer{Name="Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }


        [Route("/movies/ReleaseByDate/{year}/{month}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year +"/"+ month);
        }

        public ActionResult ListCustomer()
        {
            var customers = new List<Customer>
            { new Customer{Name="Vijay",Id=1},
              new Customer{Name="Abhi",Id=2},
              new Customer{Name="Sonu",Id=3}
            };
            var viewModel = new RandomMovieViewModel
            {
                Customers = customers
            };
            return View(viewModel);
        }

        public ActionResult ListMovie()
        {
            var movie = new Movie() { Name = "Life Of PI", Id=1 };

            return View(movie);
        }

        public ActionResult DisplayCustomer(int id)
        {
            //var cutomer = from cust in RandomMovieViewModel where cust.Cutomer.Id = id select cust;

            return View();
        }
    }
}
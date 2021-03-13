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



        [HttpGet]
        public ActionResult NewMovie()
        {


            var genretypes = _Context.GenreTypes.ToList();
            AddMovieViewModel viewModel = new AddMovieViewModel
            {
                GenreTypes = genretypes
            };


            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveMovie(AddMovieViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var model = new AddMovieViewModel
                {
                    Movie = viewModel.Movie,
                    GenreTypes = _Context.GenreTypes.ToList()
                };
                return View("NewMovie", model);
            }
            if (viewModel.Movie.Id == 0)
            {
                _Context.Movies.Add(viewModel.Movie);

            }
            else
            {
                var movieInDb = _Context.Movies.Where(x => x.Id == viewModel.Movie.Id).SingleOrDefault();
                movieInDb.Name = viewModel.Movie.Name;
                movieInDb.ReleaseDate = viewModel.Movie.ReleaseDate;
                movieInDb.GenreType_Id = viewModel.Movie.GenreType_Id;
                movieInDb.InStock = viewModel.Movie.InStock;
            }
            _Context.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }
    }
}
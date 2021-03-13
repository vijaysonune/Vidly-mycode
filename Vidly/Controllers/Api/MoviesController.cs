using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.DAL;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private VidlyDb _context;
        public MoviesController()
        {
            _context = new VidlyDb();
        }

        // Get api/Movies
        public IEnumerable<Movie> Get()
        {
            return _context.Movies.ToList();
        }

        // Get api/Customers/1
        public Movie Get(int id)
        {
            var movie = _context.Movies.Where(x => x.Id == id).SingleOrDefault();
            //if (movie == null)
            //    return HttpStatusCode.NotFound();
            return movie;
        }

        // Post api/Movies
        [HttpPost]
        public IHttpActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDB = _context.Movies.Where(x => x.Id == movie.Id).SingleOrDefault();
                movieInDB.Name = movie.Name;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.InStock = movie.InStock;
                movieInDB.GenreType_Id = movie.GenreType_Id;

            }
            _context.SaveChanges();
            return Ok();
        }

        // Put api/Movies
        [HttpPut]
        public IHttpActionResult UpdateCustomer(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (movie.Id == 0)
            {
                return NotFound();
            }
            else
            {
                var movieInDB = _context.Movies.Where(x => x.Id == movie.Id).SingleOrDefault();
                movieInDB.Name = movie.Name;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.InStock = movie.InStock;
                movieInDB.GenreType_Id = movie.GenreType_Id;

            }
            _context.SaveChanges();
            return Ok();
        }

        // Delete api/Movies/1
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var customer = _context.Movies.Where(x => x.Id == id).SingleOrDefault();
            if (customer.Id == 0)
            {
                return NotFound();
            }
            else
            {
                _context.Movies.Remove(customer);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}

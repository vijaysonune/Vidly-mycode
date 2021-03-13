using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class AddMovieViewModel
    {
        public Movie Movie { get; set; }

        public IEnumerable<GenreType> GenreTypes { get; set; }
    }
}
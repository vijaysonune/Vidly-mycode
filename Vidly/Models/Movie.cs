using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Range (1,20)]
        public int InStock { get; set; }

    //   public GenreType GenreType { get; set; }
        
        public int GenreType_Id { get; set; }
    }
}
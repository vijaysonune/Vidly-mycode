﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int InStock { get; set; }

    //   public GenreType GenreType { get; set; }
        
        public int GenreType_Id { get; set; }
    }
}
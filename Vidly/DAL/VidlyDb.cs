using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly.DAL
{
    public class VidlyDb : DbContext
    {
        public VidlyDb() : base("VidlyDb")
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }

        public DbSet<GenreType> GenreTypes { get; set; }
    }
}
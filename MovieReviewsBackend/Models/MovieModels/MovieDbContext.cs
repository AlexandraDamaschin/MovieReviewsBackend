using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace MovieReviewsBackend.Models.MovieModels
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext() : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        
        public DbSet<Review> Reviews { get; set; }

    }
}
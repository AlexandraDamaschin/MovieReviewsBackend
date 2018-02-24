using System.Data.Entity;

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
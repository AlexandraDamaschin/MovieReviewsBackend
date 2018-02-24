using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace MovieReviewsBackend.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }
    
        public DbSet Reviewer { get; set; }
    }
}
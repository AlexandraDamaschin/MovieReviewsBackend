using MovieReviewsBackend.Models.MovieModels;
using System.Collections.Generic;
using System.Linq;

namespace MovieReviewsBackend.DAL
{
    public class ReviewRepository : IReviewRepository
    {
        private MovieDbContext context;

        public ReviewRepository(MovieDbContext context)
        {
            this.context = context;
        }

        //get all reviews
        public List<Review> GetReviews()
        {
            return context.Reviews.ToList();
        }

        //get reviews by id 
        public Review GetReviewById(int id)
        {
            return context.Reviews.Find(id);
        }

    }
}
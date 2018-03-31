using MovieReviewsBackend.Models.MovieModels;
using System.Collections.Generic;
using System.Linq;

namespace MovieReviewsBackend.DAL
{
    public class ReviewRepository : IReviewRepository
    {
        //movie context
        private MovieDbContext context;

        //app context
        //private ApplicationDbContext app_context;

        public ReviewRepository(MovieDbContext context) //, ApplicationDbContext app_context)
        {
            this.context = context;
            //this.app_context = app_context;
        }

        //get all reviews
        public List<Review> GetReviews()
        {
            return context.Reviews.ToList();
        }

        //get reviews by id 
        public Review GetReviewById(int reviewId)
        {
            return context.Reviews.Find(reviewId);
        }

        //get reviews by movid id
        public Review GetReviewMovieById(string imdbId)
        {
            
            Review review = context.Reviews.ToList().Find(r => r.ImdbId == imdbId);

            if(review ==null)
            {
                return null;
            }
            return review;
        }

        //insert a new review
        public Review CreateReview(Review review)
        {
            //conect users from application db context to movie context
            //var query = (from a in app_context.Users
            //             join c in context.Reviews
            //             on a.Id equals c.UserId
            //             select new { a, c }).ToList();
            context.Reviews.Add(review);
            return context.Reviews.Add(review);
        }

        //update review
        public Review UpdateReview(int reviewId, Review review)
        {
            var reviewInDb = context.Reviews.Find(reviewId);
            context.Reviews.Add(review);
            return context.Reviews.Add(review);
        }


        //delete a review
        public Review DeleteReview(int reviewId)
        {
            var review = context.Reviews.SingleOrDefault(r => r.ReviewId == reviewId);
            context.Reviews.Remove(review);
            return context.Reviews.Remove(review);
        }

        //Save should call context.SaveChanges
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
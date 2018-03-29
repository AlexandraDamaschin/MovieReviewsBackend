using MovieReviewsBackend.Models;
using MovieReviewsBackend.Models.MovieModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

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
            return context.Reviews.Find(imdbId);
        }

        //insert a new review
        public void CreateReview(Review review)
        {
            //conect users from application db context to movie context
            //var query = (from a in app_context.Users
            //             join c in context.Reviews
            //             on a.Id equals c.UserId
            //             select new { a, c }).ToList();
            context.Reviews.Add(review);
            context.SaveChanges();
        }

        //update review
        public void UpdateReview(int reviewId)
        {
            Review review = context.Reviews.Find(reviewId);
            context.Reviews.Add(review);
            context.SaveChanges();
        }

        //delete a review
        public void DeleteReview(int reviewId)
        {
            Review review = context.Reviews.Find(reviewId);
            context.Reviews.Remove(review);
            context.SaveChanges();
        }

        //Save should call context.SaveChanges
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
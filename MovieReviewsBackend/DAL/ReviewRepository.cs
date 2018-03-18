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
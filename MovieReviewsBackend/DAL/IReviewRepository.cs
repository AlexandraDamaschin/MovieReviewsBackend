using MovieReviewsBackend.Models.MovieModels;
using System;
using System.Collections.Generic;

namespace MovieReviewsBackend.DAL
{
    interface IReviewRepository
    {
        List<Review> GetReviews();
        Review GetReviewById(int reviewId);
        Review GetReviewMovieById(string imdbId);

        void CreateReview(Review review);
        void UpdateReview(int reviewId);
        void DeleteReview(int reviewId);

        void Save();
    }
}

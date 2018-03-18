using MovieReviewsBackend.Models.MovieModels;
using System;
using System.Collections.Generic;

namespace MovieReviewsBackend.DAL
{
    interface IReviewRepository
    {
        List<Review> GetReviews();
        Review GetReviewById(int id);
        Review GetReviewMovieById(string imdbId);

        void CreateReview(Review review);
        void UpdateReview(Review review);
        void DeleteReview(int revireId);

        void Save();
    }
}

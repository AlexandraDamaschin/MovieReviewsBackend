using MovieReviewsBackend.DTOs;
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

        Review CreateReview(Review review);
        Review UpdateReview(int reviewId, Review review);
        Review DeleteReview(int reviewId);

        void Save();
    }
}

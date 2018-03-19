using MovieReviewsBackend.DAL;
using MovieReviewsBackend.Models.MovieModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace MovieReviewsBackend.Controllers.Api
{
    public class ReviewRepoController : ApiController
    {
        //set context to repo
        private ReviewRepository reviewRepo;

        private MovieDbContext _movie;

        //constructor 
        public ReviewRepoController()
        {
            reviewRepo = new DAL.ReviewRepository(new MovieDbContext());
        }

        //GET /api/ReviewRepo
        //get all reviews
        public List<Review> GetReviews()
        {
            return reviewRepo.GetReviews();
        }

        //GET /api/ReviewRepo/1
        public Review GetReviewById(int reviewId)
        {
            var review = _movie.Reviews.SingleOrDefault(r => r.ReviewId == reviewId);
            return reviewRepo.GetReviewById(reviewId);
        }

        //GET /api/ReviewRepo/imdbid
        public Review GetReviewMovieById(string imdbId)
        {
            var review = _movie.Reviews.ToList().Where(r => r.ImdbId == imdbId);
            return reviewRepo.GetReviewMovieById(imdbId);
        }

        //POST /api/ReviewRepo
        public void CreateReview(Review review)
        {
            _movie.Reviews.Add(review);
            reviewRepo.CreateReview(review);
        }

        //PUT /api/ReviewRepo/1
        public void UpdateReview(int reviewId)
        {
            var reviewInDb = _movie.Reviews.SingleOrDefault(r => r.ReviewId == reviewId);
            reviewRepo.UpdateReview(reviewId);
        }

        //DELETE /api/ReviewRepo/1

        public void DeleteReview(int reviewId)
        {
            var reviewInDb = _movie.Reviews.SingleOrDefault(r => r.ReviewId == reviewId);
            reviewRepo.DeleteReview(reviewId);
        }

        //save changes
        public void Save()
        {
            reviewRepo.Save();
        }
    }
}
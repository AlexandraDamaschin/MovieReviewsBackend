using MovieReviewsBackend.DAL;
using MovieReviewsBackend.Models.MovieModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MovieReviewsBackend.Controllers.Api
{
    [Authorize(Roles = "User")]
    //set prefix of the route
    [RoutePrefix("api/ReviewRepo")]

    public class ReviewRepoController : ApiController
    {
        //set context to repo
        private ReviewRepository reviewRepo;

        //constructor 
        public ReviewRepoController()
        {
            reviewRepo = new DAL.ReviewRepository(new MovieDbContext());
        }

        //GET /api/ReviewRepo
        //get all reviews
        [Route("GetReviewsRepo")]
        public List<Review> GetReviews()
        {
            return reviewRepo.GetReviews();
        }

        //GET /api/ReviewRepo/1
        [Route("GetReviewRepoById/{reviewId}")]
        public Review GetReviewById(int reviewId)
        {
            return reviewRepo.GetReviewById(reviewId);
        }

        //GET /api/ReviewRepo/imdbid
        [Route("GetReviewRepoMovieById/{imdbId}")]
        public Review GetReviewMovieById(string imdbId)
        {
            return reviewRepo.GetReviewMovieById(imdbId);
        }

        //POST /api/ReviewRepo
        [Route("CreateReviewRepo")]
        [HttpPost]
        public void CreateReview(Review review)
        {
            //_movie.Reviews.Add(review);
            reviewRepo.CreateReview(review);
        }

        //PUT /api/ReviewRepo/1
        [Route("UpdateReviewRepo/{reviewId}")]
        [HttpPut]
        public void UpdateReview(int reviewId)
        {
            //var reviewInDb = _movie.Reviews.SingleOrDefault(r => r.ReviewId == reviewId);
            reviewRepo.UpdateReview(reviewId);
        }

        //DELETE /api/ReviewRepo/1
        [Route("DeleteReviewRepo/{reviewId}")]
        [HttpDelete]
        public void DeleteReview(int reviewId)
        {
            //var reviewInDb = _movie.Reviews.SingleOrDefault(r => r.ReviewId == reviewId);
            reviewRepo.DeleteReview(reviewId);
        }

        //save changes
        public void Save()
        {
            reviewRepo.Save();
        }
    }
}
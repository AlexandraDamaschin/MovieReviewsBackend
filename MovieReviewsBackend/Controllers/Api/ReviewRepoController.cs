using MovieReviewsBackend.DAL;
using MovieReviewsBackend.DTOs;
using MovieReviewsBackend.Models.MovieModels;
using System.Collections.Generic;
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
        [HttpGet]
        public IHttpActionResult GetReviews()
        {
            var review = reviewRepo.GetReviews();
            var result = AutoMapper.Mapper.Map<List<ReviewDto>>(review);
            return Ok(result);
        }

        //GET /api/ReviewRepo/1
        [Route("GetReviewRepoById/{reviewId}")]
        [HttpGet]
        public Review GetReviewById(int reviewId)
        {
            var review = reviewRepo.GetReviewById(reviewId);
            var result = AutoMapper.Mapper.Map<Review,ReviewDto>(review);
            return reviewRepo.GetReviewById(reviewId);
        }

        //this ones break

        //GET /api/ReviewRepo/GetReviewRepoMovieById/imdbid
        [Route("GetReviewRepoMovieById/{imdbId}")]
        [HttpGet]
        public Review GetReviewMovieById(string imdbId)
        {
            var reviewMovie = reviewRepo.GetReviewMovieById(imdbId);
            var result = AutoMapper.Mapper.Map<Review, ReviewDto>(reviewMovie);
            return reviewRepo.GetReviewMovieById(imdbId);
        }
        
        //POST /api/ReviewRepo/CreateReviewRepo
        [Route("CreateReviewRepo")]
        [HttpPost]
        public Review CreateReview(Review review)
        {
            var reviewMovie = reviewRepo.CreateReview(review);
            var result = AutoMapper.Mapper.Map<Review, ReviewDto>(reviewMovie);
            return reviewRepo.CreateReview(review);

            //reviewRepo.CreateReview(review);
        }

        //break
        //PUT /api/ReviewRepo/UpdateReviewRepo/1
        [Route("UpdateReviewRepo/{reviewId}")]
        [HttpPut]
        public Review UpdateReview(int reviewId)
        {
            var reviewMovie = reviewRepo.UpdateReview(reviewId);
            var result = AutoMapper.Mapper.Map<Review, ReviewDto>(reviewMovie);
            return reviewRepo.UpdateReview(reviewId);


            //var reviewInDb = _movie.Reviews.SingleOrDefault(r => r.ReviewId == reviewId);
            //reviewRepo.UpdateReview(reviewId);
        }


        //this one breaks
        //DELETE /api/ReviewRepo/DeleteReviewRepo/1
        [Route("DeleteReviewRepo/{reviewId}")]
        [HttpDelete]
        public Review DeleteReview(int reviewId)
        {

            var reviewMovie = reviewRepo.DeleteReview(reviewId);
            var result = AutoMapper.Mapper.Map<Review, ReviewDto>(reviewMovie);
            return reviewRepo.DeleteReview(reviewId);

            //var reviewInDb = _movie.Reviews.SingleOrDefault(r => r.ReviewId == reviewId);
            //reviewRepo.DeleteReview(reviewId);
        }

        //save changes
        public void Save()
        {
            reviewRepo.Save();
        }
    }
}
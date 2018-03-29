using MovieReviewsBackend.DAL;
using MovieReviewsBackend.DTOs;
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

        //GET /api/ReviewRepo/imdbid
        [Route("GetReviewRepoMovieById/{imdbId}")]
        [HttpGet]
        public Review GetReviewMovieById(string imdbId)
        {
            var reviewMovie = reviewRepo.GetReviewMovieById(imdbId);
            var result = AutoMapper.Mapper.Map<Review, ReviewDto>(reviewMovie);
            return reviewRepo.GetReviewMovieById(imdbId);
        }

        //break
        //POST /api/ReviewRepo
        [Route("CreateReviewRepo")]
        [HttpPost]
        public void CreateReview(Review review)
        {
            //_movie.Reviews.Add(review);
            reviewRepo.CreateReview(review);
        }

        //break
        //PUT /api/ReviewRepo/1
        [Route("UpdateReviewRepo/{reviewId}")]
        [HttpPut]
        public void UpdateReview(int reviewId)
        {
            //var reviewInDb = _movie.Reviews.SingleOrDefault(r => r.ReviewId == reviewId);
            reviewRepo.UpdateReview(reviewId);
        }

        //break
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
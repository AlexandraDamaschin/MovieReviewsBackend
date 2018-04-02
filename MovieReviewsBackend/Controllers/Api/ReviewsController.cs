using AutoMapper;
using MovieReviewsBackend.DTOs;
using MovieReviewsBackend.Models.MovieModels;
using System;
using System.Linq;
using System.Web.Http;

namespace MovieReviewsBackend.Controllers.Api
{
    //[Authorize(Roles = "User")] - Commented out because Login/Registration not 100% functional.
    [RoutePrefix("api/Reviews")]
    public class ReviewsController : ApiController
    {
        private MovieDbContext _movie;

        //constructor 
        public ReviewsController()
        {
            _movie = new MovieDbContext();
        }


        //GET /api/Reviews/GetReviews
        [Route("GetReviews")]
        public IHttpActionResult GetReviews()
        {
            var reviewQuery = _movie.Reviews;

            var reviewDtos = reviewQuery
                .ToList()
                .Select(Mapper.Map<Review, ReviewDto>);

            return Ok(reviewDtos);
            //return Ok(_movie.Reviews.ToList().Select(Mapper.Map<Review, ReviewDto>));

        }

        //GET /api/Reviews/GetReviews/1
        [Route("GetReviews/{id}")]
        public IHttpActionResult GetReview(int id)
        {
            var review = _movie.Reviews.SingleOrDefault(r => r.ReviewId == id);

            if (review == null)
                return NotFound();

            return Ok(Mapper.Map<Review, ReviewDto>(review));
        }

        //GET /api/Reviews/GetReviewMovie/tt45717
        [Route("GetReviewMovie/{imdbId}")]
        public IHttpActionResult GetReviewMovie(string imdbId)
        {
            var reviewQuery = _movie.Reviews;

            var reviewDtos = reviewQuery
                .ToList()
                .Where(r => r.ImdbId == imdbId)
                .Select(Mapper.Map<Review, ReviewDto>);

            return Ok(reviewDtos);
        }

        //POST /api/Reviews/CreateReview
        [Route("CreateReview")]
        [HttpPost]
        public IHttpActionResult CreateReview(ReviewDto reviewDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var review = Mapper.Map<ReviewDto, Review>(reviewDto);
            _movie.Reviews.Add(review);
            _movie.SaveChanges();

            reviewDto.ReviewId = review.ReviewId;

            return Created(new Uri(Request.RequestUri + "/" + review.ReviewId), reviewDto);

        }

        //PUT /api/Reviews/UpdateReview/1
        [Route("UpdateReview/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateReview(int id, ReviewDto reviewDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var reviewInDb = _movie.Reviews.SingleOrDefault(r => r.ReviewId == id);

            if (reviewInDb == null)
                return NotFound();

            Mapper.Map(reviewDto, reviewInDb);

            _movie.SaveChanges();

            return Ok();
        }


        //DELETE /api/Reviews/DeleteReview/1
        [Route("DeleteReview/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteReview(int id)
        {
            var reviewInDb = _movie.Reviews.SingleOrDefault(r => r.ReviewId == id);

            if (reviewInDb == null)
                return NotFound();

            _movie.Reviews.Remove(reviewInDb);
            _movie.SaveChanges();

            return Ok();
        }
    }
}

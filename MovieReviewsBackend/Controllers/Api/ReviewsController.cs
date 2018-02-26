﻿using AutoMapper;
using MovieReviewsBackend.DTOs;
using MovieReviewsBackend.Models.MovieModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieReviewsBackend.Controllers.Api
{
    public class ReviewsController : ApiController
    {
        private MovieDbContext _movie;

        public ReviewsController()
        {
            _movie = new MovieDbContext();
        }


        //GET /api/Reviews
        public IHttpActionResult GetReviews()
        {
            var reviewQuery = _movie.Reviews;

            var reviewDtos = reviewQuery
                .ToList()
                .Select(Mapper.Map<Review, ReviewDto>);

            return Ok(reviewDtos);
            //return Ok(_movie.Reviews.ToList().Select(Mapper.Map<Review, ReviewDto>));

        }

        //GET /api/Reviews/1
        public IHttpActionResult GetReview(int id)
        {
            var review = _movie.Reviews.SingleOrDefault(r => r.ReviewId == id);

            if (review == null)
                return NotFound();

            return Ok(Mapper.Map<Review, ReviewDto>(review));
        }

        //GET /api/Reviews/imdbid
        [Route("api/Reviews/{imdbId}")]
        public IHttpActionResult GetReviewMovie(string imdbId)
        {
            var reviewQuery = _movie.Reviews;

            var reviewDtos = reviewQuery
                .ToList()
                .Where(r => r.ImdbId == imdbId)
                .Select(Mapper.Map<Review, ReviewDto>);

            return Ok(reviewDtos);
        }

        //POST /api/Reviews
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

        //PUT /api/Reviews/1
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
        //Put to update database??

        //DELETE /api/Reviews/1
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

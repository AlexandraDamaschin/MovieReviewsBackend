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
            return reviewRepo.GetReviewById(reviewId);
        }

        //GET /api/ReviewRepo/imdbid
        public Review GetReviewMovieById(string imdbId)
        {
            return reviewRepo.GetReviewMovieById(imdbId);
        }

        //POST /api/ReviewRepo
        public void CreateReview(Review review)
        {
            reviewRepo.CreateReview(review);

        }

        //PUT /api/ReviewRepo/1
        public void UpdateReview(int reviewId)
        {
            reviewRepo.UpdateReview(reviewId);
        }

        //DELETE /api/ReviewRepo/1

        public void DeleteReview(int reviewId)
        {
            reviewRepo.DeleteReview(reviewId);
        }

        //save changes
        public void Save()
        {
            reviewRepo.Save();
        }
    }
}
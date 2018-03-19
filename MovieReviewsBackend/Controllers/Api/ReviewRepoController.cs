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

        //GET /api/Reviews
        //get all reviews
        public List<Review> GetReviews()
        {
            return reviewRepo.GetReviews();
        }


    }
}
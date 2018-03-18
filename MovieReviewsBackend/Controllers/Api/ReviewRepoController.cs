using MovieReviewsBackend.DAL;
using MovieReviewsBackend.Models.MovieModels;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace MovieReviewsBackend.Controllers.Api
{
    public class ReviewRepoController : ApiController
    {
        private MovieDbContext db = new MovieDbContext();

        private IReviewRepository reviewRepo;

        public ReviewRepoController()
        {
            reviewRepo = new DAL.ReviewRepository(new MovieDbContext());
        }
        //GET /api/Reviews
        public IQueryable<Review> GetReviews()
        {
            return db.Reviews;
        }

        // GET: api/Reviews/1
        [ResponseType(typeof(Review))]
        public async Task<IHttpActionResult> GetReviewById(int id)
        {
            Review review = await db.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }
    }
}
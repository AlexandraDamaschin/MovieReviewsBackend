using System;

namespace MovieReviewsBackend.DTOs
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public string ImdbId { get; set; }
        public string ReviewComment { get; set; }
        public DateTime? DateCreated { get; set; }
        public int StarRating { get; set; }
        public string ImageUrl { get; set; }
    }
}
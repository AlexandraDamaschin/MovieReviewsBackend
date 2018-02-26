namespace MovieReviewsBackend.Migrations
{
    using MovieReviewsBackend.Models;
    using MovieReviewsBackend.Models.MovieModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieReviewsBackend.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieReviewsBackend.Models.ApplicationDbContext context)
        {
        }
        //seedReviews
        private void SeedUser(ApplicationDbContext context)
        {
            context.AspNetUsers.AddOrUpdate(u => u.Id, new Review
            {
                UserId = 6,
                ImdbId = "tt0099785",
                ReviewComment = "uuu",
                DateCreated = DateTime.Now,
                StarRating = 5
            });

        }
    }

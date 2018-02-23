namespace MovieReviewsBackend.Migrations.MovieMigrations
{
    using MovieReviewsBackend.Models.MovieModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieReviewsBackend.Models.MovieModels.MovieDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\MovieMigrations";
        }

        protected override void Seed(MovieReviewsBackend.Models.MovieModels.MovieDbContext context)
        {
            //seding methods
            // SeedReviews(context);
        }

        //seedReviews
        private void SeedReviews(MovieDbContext context)
        {
            context.Reviews.AddOrUpdate(u => u.ReviewId, new Review
            {
                UserId = 6,
                ImdbId = "tt0099785",
                ReviewComment = "uuu",
                DateCreated = DateTime.Now,
                StarRating = 5
            });

            context.Reviews.AddOrUpdate(u => u.ReviewId, new Review
            {
                UserId = 6,
                ImdbId = "tt0099785",
                ReviewComment = "uuu nice",
                DateCreated = DateTime.Now,
                StarRating = 5
            });
            context.Reviews.AddOrUpdate(u => u.ReviewId, new Review
            {
                UserId = 7,
                ImdbId = "tt0099799",
                ReviewComment = "noooo",
                DateCreated = DateTime.Now,
                StarRating = 1
            });
            context.Reviews.AddOrUpdate(u => u.ReviewId, new Review
            {
                UserId = 7,
                ImdbId = "tt0099799",
                ReviewComment = "noo ugly",
                DateCreated = DateTime.Now,
                StarRating = 1
            });
        }
    }
}

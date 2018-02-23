namespace MovieReviewsBackend.Migrations.MovieMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ImdbId = c.String(),
                        ReviewComment = c.String(),
                        DateCreated = c.DateTime(storeType: "date"),
                        StarRating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Review");
        }
    }
}

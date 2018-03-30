namespace MovieReviewsBackend.Migrations.MovieMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteImageField : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Review", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Review", "ImageUrl", c => c.String());
        }
    }
}

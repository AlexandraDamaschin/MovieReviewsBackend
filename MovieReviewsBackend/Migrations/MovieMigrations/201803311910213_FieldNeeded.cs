namespace MovieReviewsBackend.Migrations.MovieMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FieldNeeded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Review", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Review", "ImageUrl");
        }
    }
}

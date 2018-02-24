namespace MovieReviewsBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewerTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviewers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentityId = c.String(maxLength: 128),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.IdentityId)
                .Index(t => t.IdentityId);
            
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUserRoles", "AppUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserClaims", "AppUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "AppUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUserClaims", "AppUser_Id");
            CreateIndex("dbo.AspNetUserLogins", "AppUser_Id");
            CreateIndex("dbo.AspNetUserRoles", "AppUser_Id");
            AddForeignKey("dbo.AspNetUserClaims", "AppUser_Id", "dbo.AppUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "AppUser_Id", "dbo.AppUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "AppUser_Id", "dbo.AppUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviewers", "IdentityId", "dbo.AppUsers");
            DropForeignKey("dbo.AspNetUserRoles", "AppUser_Id", "dbo.AppUsers");
            DropForeignKey("dbo.AspNetUserLogins", "AppUser_Id", "dbo.AppUsers");
            DropForeignKey("dbo.AspNetUserClaims", "AppUser_Id", "dbo.AppUsers");
            DropIndex("dbo.AspNetUserRoles", new[] { "AppUser_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "AppUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "AppUser_Id" });
            DropIndex("dbo.Reviewers", new[] { "IdentityId" });
            DropColumn("dbo.AspNetUserLogins", "AppUser_Id");
            DropColumn("dbo.AspNetUserClaims", "AppUser_Id");
            DropColumn("dbo.AspNetUserRoles", "AppUser_Id");
            DropTable("dbo.AppUsers");
            DropTable("dbo.Reviewers");
        }
    }
}

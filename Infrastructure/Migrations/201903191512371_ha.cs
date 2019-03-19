namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ha : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActorMovies",
                c => new
                    {
                        ActorId = c.Guid(nullable: false),
                        MovieId = c.Guid(nullable: false),
                        Role = c.String(),
                    })
                .PrimaryKey(t => new { t.ActorId, t.MovieId })
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.ActorId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NameActor = c.String(),
                        Description = c.String(),
                        Thumbnail = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        DatePublish = c.DateTime(nullable: false),
                        LengthTime = c.DateTime(nullable: false),
                        Language = c.String(),
                        Country = c.String(),
                        CountView = c.Int(nullable: false),
                        IsHot = c.Int(nullable: false),
                        NameEn = c.String(),
                        EnableAge = c.Int(nullable: false),
                        TagId = c.Guid(nullable: false),
                        Description = c.String(),
                        Thumbnail = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.CategoryMovies",
                c => new
                    {
                        CategoryId = c.Guid(nullable: false),
                        MovieId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryId, t.MovieId })
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NameCategory = c.String(),
                        Description = c.String(),
                        Thumbnail = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NameDirector = c.String(),
                        Description = c.String(),
                        Thumbnail = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        ShortDescription = c.String(),
                        MovieId = c.Guid(nullable: false),
                        Description = c.String(),
                        Thumbnail = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.ProducerMovies",
                c => new
                    {
                        ProducerId = c.Guid(nullable: false),
                        MovieId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProducerId, t.MovieId })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Producers", t => t.ProducerId, cascadeDelete: true)
                .Index(t => t.ProducerId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NameProducer = c.String(),
                        Description = c.String(),
                        Thumbnail = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        MovieId = c.Guid(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Feedback = c.String(),
                        StarRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.UserId })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Avatar = c.String(maxLength: 255),
                        Wallpaper = c.String(maxLength: 255),
                        Address = c.String(maxLength: 100),
                        Gender = c.Int(nullable: false),
                        FullName = c.String(maxLength: 100),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.FavoriteMovies",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        MovieId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.MovieId })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Resolutions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NameResolution = c.String(),
                        Description = c.String(),
                        Thumbnail = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Movie_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Movie_Id);
            
            CreateTable(
                "dbo.MovieResolutions",
                c => new
                    {
                        ProducerId = c.Guid(nullable: false),
                        MovieId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProducerId, t.MovieId })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Resolutions", t => t.ProducerId, cascadeDelete: true)
                .Index(t => t.ProducerId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NameTag = c.String(),
                        Description = c.String(),
                        Thumbnail = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trailers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Link = c.String(),
                        MovieID = c.Guid(nullable: false),
                        Description = c.String(),
                        Thumbnail = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieID, cascadeDelete: true)
                .Index(t => t.MovieID);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NameFilm = c.String(),
                        Link = c.String(),
                        MovieId = c.Guid(nullable: false),
                        Description = c.String(),
                        Thumbnail = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.DirectorMovies",
                c => new
                    {
                        Director_Id = c.Guid(nullable: false),
                        Movie_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Director_Id, t.Movie_Id })
                .ForeignKey("dbo.Directors", t => t.Director_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Director_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Films", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.ActorMovies", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Trailers", "MovieID", "dbo.Movies");
            DropForeignKey("dbo.Movies", "TagId", "dbo.Tags");
            DropForeignKey("dbo.Resolutions", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.MovieResolutions", "ProducerId", "dbo.Resolutions");
            DropForeignKey("dbo.MovieResolutions", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Ratings", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FavoriteMovies", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FavoriteMovies", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ratings", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.ProducerMovies", "ProducerId", "dbo.Producers");
            DropForeignKey("dbo.ProducerMovies", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.News", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.DirectorMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.DirectorMovies", "Director_Id", "dbo.Directors");
            DropForeignKey("dbo.CategoryMovies", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.CategoryMovies", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ActorMovies", "ActorId", "dbo.Actors");
            DropIndex("dbo.DirectorMovies", new[] { "Movie_Id" });
            DropIndex("dbo.DirectorMovies", new[] { "Director_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Films", new[] { "MovieId" });
            DropIndex("dbo.Trailers", new[] { "MovieID" });
            DropIndex("dbo.MovieResolutions", new[] { "MovieId" });
            DropIndex("dbo.MovieResolutions", new[] { "ProducerId" });
            DropIndex("dbo.Resolutions", new[] { "Movie_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.FavoriteMovies", new[] { "MovieId" });
            DropIndex("dbo.FavoriteMovies", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Ratings", new[] { "UserId" });
            DropIndex("dbo.Ratings", new[] { "MovieId" });
            DropIndex("dbo.ProducerMovies", new[] { "MovieId" });
            DropIndex("dbo.ProducerMovies", new[] { "ProducerId" });
            DropIndex("dbo.News", new[] { "MovieId" });
            DropIndex("dbo.CategoryMovies", new[] { "MovieId" });
            DropIndex("dbo.CategoryMovies", new[] { "CategoryId" });
            DropIndex("dbo.Movies", new[] { "TagId" });
            DropIndex("dbo.ActorMovies", new[] { "MovieId" });
            DropIndex("dbo.ActorMovies", new[] { "ActorId" });
            DropTable("dbo.DirectorMovies");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Films");
            DropTable("dbo.Trailers");
            DropTable("dbo.Tags");
            DropTable("dbo.MovieResolutions");
            DropTable("dbo.Resolutions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.FavoriteMovies");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Ratings");
            DropTable("dbo.Producers");
            DropTable("dbo.ProducerMovies");
            DropTable("dbo.News");
            DropTable("dbo.Directors");
            DropTable("dbo.Categories");
            DropTable("dbo.CategoryMovies");
            DropTable("dbo.Movies");
            DropTable("dbo.Actors");
            DropTable("dbo.ActorMovies");
        }
    }
}

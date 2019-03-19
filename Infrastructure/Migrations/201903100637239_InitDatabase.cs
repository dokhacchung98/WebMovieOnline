namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Movies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        DatePublish = c.DateTime(nullable: false),
                        IdCountry = c.Int(nullable: false),
                        Description = c.String(),
                        LengthTime = c.DateTime(nullable: false),
                        Language = c.String(),
                        Country = c.String(),
                        CountView = c.Int(nullable: false),
                        IsHot = c.Int(nullable: false),
                        NameEn = c.String(),
                        EnableAge = c.Int(nullable: false),
                        TagId = c.Guid(nullable: false),
                        ResolutionId = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resolutions", t => t.ResolutionId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.ResolutionId);
            
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
                        Dob = c.DateTime(nullable: false),
                        IdCountry = c.Int(nullable: false),
                        Sex = c.Int(nullable: false),
                        Tus = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Value = c.String(),
                        DatePublish = c.DateTime(nullable: false),
                        DicrectorId = c.Guid(nullable: false),
                        MovieId = c.Guid(nullable: false),
                        ActorId = c.Guid(nullable: false),
                        NewsId = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.Directors", t => t.DicrectorId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.News", t => t.NewsId, cascadeDelete: true)
                .Index(t => t.DicrectorId)
                .Index(t => t.MovieId)
                .Index(t => t.ActorId)
                .Index(t => t.NewsId);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NameDirector = c.String(),
                        Dob = c.DateTime(nullable: false),
                        Sex = c.Int(nullable: false),
                        Description = c.String(),
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
                        Description = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NameFilm = c.String(),
                        Link = c.String(),
                        MovieId = c.Guid(nullable: false),
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
                        Email = c.String(),
                        Phone = c.String(),
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
                        Id = c.Guid(nullable: false),
                        Feedback = c.String(),
                        StarRating = c.Double(nullable: false),
                        MovieId = c.Guid(nullable: false),
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
                "dbo.Resolutions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NameResolution = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NameTag = c.String(),
                        CountTag = c.Int(nullable: false),
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
                        Description = c.String(),
                        MovieID = c.Guid(nullable: false),
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
            DropForeignKey("dbo.FavoriteMovies", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FavoriteMovies", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Trailers", "MovieID", "dbo.Movies");
            DropForeignKey("dbo.Movies", "TagId", "dbo.Tags");
            DropForeignKey("dbo.Movies", "ResolutionId", "dbo.Resolutions");
            DropForeignKey("dbo.Ratings", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.ProducerMovies", "ProducerId", "dbo.Producers");
            DropForeignKey("dbo.ProducerMovies", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Films", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.CategoryMovies", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.CategoryMovies", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ActorMovies", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.ActorMovies", "ActorId", "dbo.Actors");
            DropForeignKey("dbo.Images", "NewsId", "dbo.News");
            DropForeignKey("dbo.Images", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Images", "DicrectorId", "dbo.Directors");
            DropForeignKey("dbo.DirectorMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.DirectorMovies", "Director_Id", "dbo.Directors");
            DropForeignKey("dbo.Images", "ActorId", "dbo.Actors");
            DropIndex("dbo.DirectorMovies", new[] { "Movie_Id" });
            DropIndex("dbo.DirectorMovies", new[] { "Director_Id" });
            DropIndex("dbo.Trailers", new[] { "MovieID" });
            DropIndex("dbo.Ratings", new[] { "MovieId" });
            DropIndex("dbo.ProducerMovies", new[] { "MovieId" });
            DropIndex("dbo.ProducerMovies", new[] { "ProducerId" });
            DropIndex("dbo.Films", new[] { "MovieId" });
            DropIndex("dbo.CategoryMovies", new[] { "MovieId" });
            DropIndex("dbo.CategoryMovies", new[] { "CategoryId" });
            DropIndex("dbo.Images", new[] { "NewsId" });
            DropIndex("dbo.Images", new[] { "ActorId" });
            DropIndex("dbo.Images", new[] { "MovieId" });
            DropIndex("dbo.Images", new[] { "DicrectorId" });
            DropIndex("dbo.ActorMovies", new[] { "MovieId" });
            DropIndex("dbo.ActorMovies", new[] { "ActorId" });
            DropIndex("dbo.Movies", new[] { "ResolutionId" });
            DropIndex("dbo.Movies", new[] { "TagId" });
            DropIndex("dbo.FavoriteMovies", new[] { "MovieId" });
            DropIndex("dbo.FavoriteMovies", new[] { "UserId" });
            DropTable("dbo.DirectorMovies");
            DropTable("dbo.Trailers");
            DropTable("dbo.Tags");
            DropTable("dbo.Resolutions");
            DropTable("dbo.Ratings");
            DropTable("dbo.Producers");
            DropTable("dbo.ProducerMovies");
            DropTable("dbo.Films");
            DropTable("dbo.Categories");
            DropTable("dbo.CategoryMovies");
            DropTable("dbo.News");
            DropTable("dbo.Directors");
            DropTable("dbo.Images");
            DropTable("dbo.Actors");
            DropTable("dbo.ActorMovies");
            DropTable("dbo.Movies");
            DropTable("dbo.FavoriteMovies");
        }
    }
}

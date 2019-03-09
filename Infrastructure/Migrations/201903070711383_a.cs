namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                        Id = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 128),
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
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
                        nameEn = c.String(),
                        enableAge = c.Int(nullable: false),
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
                        Id = c.Guid(nullable: false),
                        Role = c.String(),
                        ActorId = c.Guid(nullable: false),
                        MovieId = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
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
                        Id = c.Guid(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        MovieId = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
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
                        Id = c.Guid(nullable: false),
                        ProducerId = c.Guid(nullable: false),
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
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FavoriteMovies", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FavoriteMovies", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Trailers", "MovieId", "dbo.Movies");
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
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.DirectorMovies", new[] { "Movie_Id" });
            DropIndex("dbo.DirectorMovies", new[] { "Director_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Trailers", new[] { "MovieId" });
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
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.DirectorMovies");
            DropTable("dbo.AspNetUserLogins");
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
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}

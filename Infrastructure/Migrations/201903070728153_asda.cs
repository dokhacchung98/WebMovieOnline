namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asda : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FavoriteMovies", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.FavoriteMovies", new[] { "UserId" });
            DropIndex("dbo.Trailers", new[] { "MovieId" });
            DropPrimaryKey("dbo.FavoriteMovies");
            DropPrimaryKey("dbo.ActorMovies");
            DropPrimaryKey("dbo.CategoryMovies");
            DropPrimaryKey("dbo.ProducerMovies");
            AlterColumn("dbo.FavoriteMovies", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.FavoriteMovies", new[] { "UserId", "MovieId" });
            AddPrimaryKey("dbo.ActorMovies", new[] { "ActorId", "MovieId" });
            AddPrimaryKey("dbo.CategoryMovies", new[] { "CategoryId", "MovieId" });
            AddPrimaryKey("dbo.ProducerMovies", new[] { "ProducerId", "MovieId" });
            CreateIndex("dbo.FavoriteMovies", "UserId");
            CreateIndex("dbo.Trailers", "MovieID");
            AddForeignKey("dbo.FavoriteMovies", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.FavoriteMovies", "Id");
            DropColumn("dbo.FavoriteMovies", "CreatedDate");
            DropColumn("dbo.FavoriteMovies", "CreatedBy");
            DropColumn("dbo.FavoriteMovies", "UpdatedDate");
            DropColumn("dbo.FavoriteMovies", "UpdatedBy");
            DropColumn("dbo.FavoriteMovies", "Status");
            DropColumn("dbo.FavoriteMovies", "IsDeleted");
            DropColumn("dbo.ActorMovies", "Id");
            DropColumn("dbo.ActorMovies", "CreatedDate");
            DropColumn("dbo.ActorMovies", "CreatedBy");
            DropColumn("dbo.ActorMovies", "UpdatedDate");
            DropColumn("dbo.ActorMovies", "UpdatedBy");
            DropColumn("dbo.ActorMovies", "Status");
            DropColumn("dbo.ActorMovies", "IsDeleted");
            DropColumn("dbo.CategoryMovies", "Id");
            DropColumn("dbo.CategoryMovies", "CreatedDate");
            DropColumn("dbo.CategoryMovies", "CreatedBy");
            DropColumn("dbo.CategoryMovies", "UpdatedDate");
            DropColumn("dbo.CategoryMovies", "UpdatedBy");
            DropColumn("dbo.CategoryMovies", "Status");
            DropColumn("dbo.CategoryMovies", "IsDeleted");
            DropColumn("dbo.ProducerMovies", "Id");
            DropColumn("dbo.ProducerMovies", "CreatedDate");
            DropColumn("dbo.ProducerMovies", "CreatedBy");
            DropColumn("dbo.ProducerMovies", "UpdatedDate");
            DropColumn("dbo.ProducerMovies", "UpdatedBy");
            DropColumn("dbo.ProducerMovies", "Status");
            DropColumn("dbo.ProducerMovies", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProducerMovies", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProducerMovies", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.ProducerMovies", "UpdatedBy", c => c.Guid());
            AddColumn("dbo.ProducerMovies", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.ProducerMovies", "CreatedBy", c => c.Guid());
            AddColumn("dbo.ProducerMovies", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.ProducerMovies", "Id", c => c.Guid(nullable: false));
            AddColumn("dbo.CategoryMovies", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.CategoryMovies", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.CategoryMovies", "UpdatedBy", c => c.Guid());
            AddColumn("dbo.CategoryMovies", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.CategoryMovies", "CreatedBy", c => c.Guid());
            AddColumn("dbo.CategoryMovies", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.CategoryMovies", "Id", c => c.Guid(nullable: false));
            AddColumn("dbo.ActorMovies", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.ActorMovies", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.ActorMovies", "UpdatedBy", c => c.Guid());
            AddColumn("dbo.ActorMovies", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.ActorMovies", "CreatedBy", c => c.Guid());
            AddColumn("dbo.ActorMovies", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.ActorMovies", "Id", c => c.Guid(nullable: false));
            AddColumn("dbo.FavoriteMovies", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.FavoriteMovies", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.FavoriteMovies", "UpdatedBy", c => c.Guid());
            AddColumn("dbo.FavoriteMovies", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.FavoriteMovies", "CreatedBy", c => c.Guid());
            AddColumn("dbo.FavoriteMovies", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.FavoriteMovies", "Id", c => c.Guid(nullable: false));
            DropForeignKey("dbo.FavoriteMovies", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Trailers", new[] { "MovieID" });
            DropIndex("dbo.FavoriteMovies", new[] { "UserId" });
            DropPrimaryKey("dbo.ProducerMovies");
            DropPrimaryKey("dbo.CategoryMovies");
            DropPrimaryKey("dbo.ActorMovies");
            DropPrimaryKey("dbo.FavoriteMovies");
            AlterColumn("dbo.FavoriteMovies", "UserId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.ProducerMovies", "Id");
            AddPrimaryKey("dbo.CategoryMovies", "Id");
            AddPrimaryKey("dbo.ActorMovies", "Id");
            AddPrimaryKey("dbo.FavoriteMovies", "Id");
            CreateIndex("dbo.Trailers", "MovieId");
            CreateIndex("dbo.FavoriteMovies", "UserId");
            AddForeignKey("dbo.FavoriteMovies", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}

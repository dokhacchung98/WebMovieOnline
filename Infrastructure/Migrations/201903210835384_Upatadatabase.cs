namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upatadatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.News", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Movies", "TagId", "dbo.Tags");
            DropForeignKey("dbo.Trailers", "MovieID", "dbo.Movies");
            DropIndex("dbo.Movies", new[] { "TagId" });
            DropIndex("dbo.News", new[] { "MovieId" });
            DropIndex("dbo.Trailers", new[] { "MovieID" });
            AlterColumn("dbo.Movies", "TagId", c => c.Guid());
            AlterColumn("dbo.News", "MovieId", c => c.Guid());
            AlterColumn("dbo.Trailers", "MovieID", c => c.Guid());
            CreateIndex("dbo.Movies", "TagId");
            CreateIndex("dbo.News", "MovieId");
            CreateIndex("dbo.Trailers", "MovieID");
            AddForeignKey("dbo.News", "MovieId", "dbo.Movies", "Id");
            AddForeignKey("dbo.Movies", "TagId", "dbo.Tags", "Id");
            AddForeignKey("dbo.Trailers", "MovieID", "dbo.Movies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trailers", "MovieID", "dbo.Movies");
            DropForeignKey("dbo.Movies", "TagId", "dbo.Tags");
            DropForeignKey("dbo.News", "MovieId", "dbo.Movies");
            DropIndex("dbo.Trailers", new[] { "MovieID" });
            DropIndex("dbo.News", new[] { "MovieId" });
            DropIndex("dbo.Movies", new[] { "TagId" });
            AlterColumn("dbo.Trailers", "MovieID", c => c.Guid(nullable: false));
            AlterColumn("dbo.News", "MovieId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Movies", "TagId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Trailers", "MovieID");
            CreateIndex("dbo.News", "MovieId");
            CreateIndex("dbo.Movies", "TagId");
            AddForeignKey("dbo.Trailers", "MovieID", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Movies", "TagId", "dbo.Tags", "Id", cascadeDelete: true);
            AddForeignKey("dbo.News", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
        }
    }
}

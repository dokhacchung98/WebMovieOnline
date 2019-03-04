namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Delete_User_Information_Entity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "UserInformation_Id", "dbo.UserInformations");
            DropIndex("dbo.AspNetUsers", new[] { "UserInformation_Id" });
            AddColumn("dbo.AspNetUsers", "Avatar", c => c.String(maxLength: 255));
            AddColumn("dbo.AspNetUsers", "Wallpaper", c => c.String(maxLength: 255));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(maxLength: 100));
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String(maxLength: 100));
            AddColumn("dbo.AspNetUsers", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "UserInformation_Id");
            DropTable("dbo.UserInformations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserInformations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Avatar = c.String(maxLength: 255),
                        Address = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 12),
                        Gender = c.Int(nullable: false),
                        Name = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "UserInformation_Id", c => c.Guid());
            DropColumn("dbo.AspNetUsers", "Status");
            DropColumn("dbo.AspNetUsers", "FullName");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "Wallpaper");
            DropColumn("dbo.AspNetUsers", "Avatar");
            CreateIndex("dbo.AspNetUsers", "UserInformation_Id");
            AddForeignKey("dbo.AspNetUsers", "UserInformation_Id", "dbo.UserInformations", "Id");
        }
    }
}

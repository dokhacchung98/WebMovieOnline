namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInFoUserEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInformations", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.UserInformations", "CreatedBy", c => c.Guid());
            AddColumn("dbo.UserInformations", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.UserInformations", "UpdatedBy", c => c.Guid());
            AddColumn("dbo.UserInformations", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInformations", "Status");
            DropColumn("dbo.UserInformations", "UpdatedBy");
            DropColumn("dbo.UserInformations", "UpdatedDate");
            DropColumn("dbo.UserInformations", "CreatedBy");
            DropColumn("dbo.UserInformations", "CreatedDate");
        }
    }
}

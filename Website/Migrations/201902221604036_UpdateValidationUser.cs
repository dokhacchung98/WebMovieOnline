namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateValidationUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInformations", "Avatar", c => c.String(maxLength: 255));
            AlterColumn("dbo.UserInformations", "Address", c => c.String(maxLength: 100));
            AlterColumn("dbo.UserInformations", "Phone", c => c.String(maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserInformations", "Phone", c => c.String());
            AlterColumn("dbo.UserInformations", "Address", c => c.String());
            AlterColumn("dbo.UserInformations", "Avatar", c => c.String());
        }
    }
}

namespace GrocerCheck.Migrations.GrocerCheckMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brand", "User_UserID", c => c.Int());
            AddColumn("dbo.Grocer", "User_UserID", c => c.Int());
            AddColumn("dbo.Size", "User_UserID", c => c.Int());
            CreateIndex("dbo.Brand", "User_UserID");
            CreateIndex("dbo.Grocer", "User_UserID");
            CreateIndex("dbo.Size", "User_UserID");
            AddForeignKey("dbo.Brand", "User_UserID", "dbo.User", "UserID");
            AddForeignKey("dbo.Grocer", "User_UserID", "dbo.User", "UserID");
            AddForeignKey("dbo.Size", "User_UserID", "dbo.User", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Size", "User_UserID", "dbo.User");
            DropForeignKey("dbo.Grocer", "User_UserID", "dbo.User");
            DropForeignKey("dbo.Brand", "User_UserID", "dbo.User");
            DropIndex("dbo.Size", new[] { "User_UserID" });
            DropIndex("dbo.Grocer", new[] { "User_UserID" });
            DropIndex("dbo.Brand", new[] { "User_UserID" });
            DropColumn("dbo.Size", "User_UserID");
            DropColumn("dbo.Grocer", "User_UserID");
            DropColumn("dbo.Brand", "User_UserID");
        }
    }
}

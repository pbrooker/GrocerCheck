namespace GrocerCheck.Migrations.GrocerCheckMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supportformenus : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Brand", "Brand_BrandID", "dbo.Brand");
            DropIndex("dbo.Brand", new[] { "Brand_BrandID" });
            DropColumn("dbo.Brand", "Brand_BrandID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Brand", "Brand_BrandID", c => c.Int());
            CreateIndex("dbo.Brand", "Brand_BrandID");
            AddForeignKey("dbo.Brand", "Brand_BrandID", "dbo.Brand", "BrandID");
        }
    }
}

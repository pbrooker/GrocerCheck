namespace GrocerCheck.Migrations.GrocerCheckMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedGrocers2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "Brand_BrandID", "dbo.Brand");
            DropIndex("dbo.Category", new[] { "Brand_BrandID" });
            CreateTable(
                "dbo.CategoryBrand",
                c => new
                    {
                        Category_CategoryID = c.Int(nullable: false),
                        Brand_BrandID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_CategoryID, t.Brand_BrandID })
                .ForeignKey("dbo.Category", t => t.Category_CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Brand", t => t.Brand_BrandID, cascadeDelete: true)
                .Index(t => t.Category_CategoryID)
                .Index(t => t.Brand_BrandID);
            
            AddColumn("dbo.Item", "item_ItemID", c => c.Int());
            CreateIndex("dbo.Item", "item_ItemID");
            AddForeignKey("dbo.Item", "item_ItemID", "dbo.Item", "ItemID");
            DropColumn("dbo.Category", "Brand_BrandID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "Brand_BrandID", c => c.Int());
            DropForeignKey("dbo.Item", "item_ItemID", "dbo.Item");
            DropForeignKey("dbo.CategoryBrand", "Brand_BrandID", "dbo.Brand");
            DropForeignKey("dbo.CategoryBrand", "Category_CategoryID", "dbo.Category");
            DropIndex("dbo.CategoryBrand", new[] { "Brand_BrandID" });
            DropIndex("dbo.CategoryBrand", new[] { "Category_CategoryID" });
            DropIndex("dbo.Item", new[] { "item_ItemID" });
            DropColumn("dbo.Item", "item_ItemID");
            DropTable("dbo.CategoryBrand");
            CreateIndex("dbo.Category", "Brand_BrandID");
            AddForeignKey("dbo.Category", "Brand_BrandID", "dbo.Brand", "BrandID");
        }
    }
}

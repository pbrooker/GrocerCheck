namespace GrocerCheck.Migrations.GrocerCheckMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedGrocers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Grocer", "Item_ItemID", "dbo.Item");
            DropIndex("dbo.Grocer", new[] { "Item_ItemID" });
            CreateTable(
                "dbo.GrocerItem",
                c => new
                    {
                        Grocer_GrocerID = c.Int(nullable: false),
                        Item_ItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Grocer_GrocerID, t.Item_ItemID })
                .ForeignKey("dbo.Grocer", t => t.Grocer_GrocerID, cascadeDelete: true)
                .ForeignKey("dbo.Item", t => t.Item_ItemID, cascadeDelete: true)
                .Index(t => t.Grocer_GrocerID)
                .Index(t => t.Item_ItemID);
            
            AddColumn("dbo.Item", "Category_CategoryID", c => c.Int());
            AddColumn("dbo.Item", "Category_CategoryID1", c => c.Int());
            CreateIndex("dbo.Item", "CategoryID");
            CreateIndex("dbo.Item", "Category_CategoryID");
            CreateIndex("dbo.Item", "Category_CategoryID1");
            AddForeignKey("dbo.Item", "CategoryID", "dbo.Category", "CategoryID", cascadeDelete: true);
            AddForeignKey("dbo.Item", "Category_CategoryID", "dbo.Category", "CategoryID");
            AddForeignKey("dbo.Item", "Category_CategoryID1", "dbo.Category", "CategoryID");
            DropColumn("dbo.Grocer", "Item_ItemID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Grocer", "Item_ItemID", c => c.Int());
            DropForeignKey("dbo.Item", "Category_CategoryID1", "dbo.Category");
            DropForeignKey("dbo.Item", "Category_CategoryID", "dbo.Category");
            DropForeignKey("dbo.Item", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.GrocerItem", "Item_ItemID", "dbo.Item");
            DropForeignKey("dbo.GrocerItem", "Grocer_GrocerID", "dbo.Grocer");
            DropIndex("dbo.GrocerItem", new[] { "Item_ItemID" });
            DropIndex("dbo.GrocerItem", new[] { "Grocer_GrocerID" });
            DropIndex("dbo.Item", new[] { "Category_CategoryID1" });
            DropIndex("dbo.Item", new[] { "Category_CategoryID" });
            DropIndex("dbo.Item", new[] { "CategoryID" });
            DropColumn("dbo.Item", "Category_CategoryID1");
            DropColumn("dbo.Item", "Category_CategoryID");
            DropTable("dbo.GrocerItem");
            CreateIndex("dbo.Grocer", "Item_ItemID");
            AddForeignKey("dbo.Grocer", "Item_ItemID", "dbo.Item", "ItemID");
        }
    }
}

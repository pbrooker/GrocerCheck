namespace GrocerCheck.Migrations.GrocerCheckMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedtypo : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Item", name: "item_ItemID", newName: "Items_ItemID");
            RenameIndex(table: "dbo.Item", name: "IX_item_ItemID", newName: "IX_Items_ItemID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Item", name: "IX_Items_ItemID", newName: "IX_item_ItemID");
            RenameColumn(table: "dbo.Item", name: "Items_ItemID", newName: "item_ItemID");
        }
    }
}

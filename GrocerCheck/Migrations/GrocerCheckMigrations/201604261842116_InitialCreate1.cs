namespace GrocerCheck.Migrations.GrocerCheckMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "Price", c => c.Decimal(nullable: false, storeType: "money"));
            DropColumn("dbo.Item", "BySizePrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "BySizePrice", c => c.Decimal(nullable: false, storeType: "money"));
            DropColumn("dbo.Item", "Price");
        }
    }
}

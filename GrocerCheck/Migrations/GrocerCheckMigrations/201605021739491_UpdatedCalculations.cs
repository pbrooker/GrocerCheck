namespace GrocerCheck.Migrations.GrocerCheckMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedCalculations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "CalculatedPrice", c => c.Decimal(storeType: "money"));
            AddColumn("dbo.Item", "CalculatedPrice1", c => c.Decimal(storeType: "money"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "CalculatedPrice1");
            DropColumn("dbo.Item", "CalculatedPrice");
        }
    }
}

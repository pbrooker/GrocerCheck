namespace GrocerCheck.Migrations.GrocerCheckMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adjustmentstomodels : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Brand", "Item");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Brand", "Item", c => c.Int(nullable: false));
        }
    }
}

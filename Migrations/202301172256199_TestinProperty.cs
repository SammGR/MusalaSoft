namespace Gateways.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestinProperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Devices", "Vendor", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Devices", "Vendor", c => c.String(nullable: false, maxLength: 300));
        }
    }
}

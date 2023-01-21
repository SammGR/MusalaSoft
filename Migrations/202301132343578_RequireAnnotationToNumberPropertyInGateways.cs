namespace Gateways.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequireAnnotationToNumberPropertyInGateways : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gateways", "serialNumber", c => c.String(nullable: false));
            DropColumn("dbo.Gateways", "number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gateways", "number", c => c.String());
            DropColumn("dbo.Gateways", "serialNumber");
        }
    }
}

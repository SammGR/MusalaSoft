namespace Gateways.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAnnotationToDGatewayTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Gateways", "Name", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Gateways", "Ipv4Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Gateways", "Ipv4Address", c => c.String());
            AlterColumn("dbo.Gateways", "Name", c => c.String());
        }
    }
}

namespace Gateways.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAnnotationToDeviceTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Devices", "Gateway_id", "dbo.Gateways");
            DropIndex("dbo.Devices", new[] { "Gateway_id" });
            RenameColumn(table: "dbo.Devices", name: "Gateway_id", newName: "GatewayId");
            AlterColumn("dbo.Devices", "Vendor", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Devices", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Devices", "GatewayId", c => c.Int(nullable: false));
            CreateIndex("dbo.Devices", "GatewayId");
            AddForeignKey("dbo.Devices", "GatewayId", "dbo.Gateways", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devices", "GatewayId", "dbo.Gateways");
            DropIndex("dbo.Devices", new[] { "GatewayId" });
            AlterColumn("dbo.Devices", "GatewayId", c => c.Int());
            AlterColumn("dbo.Devices", "DateCreated", c => c.String());
            AlterColumn("dbo.Devices", "Vendor", c => c.String());
            RenameColumn(table: "dbo.Devices", name: "GatewayId", newName: "Gateway_id");
            CreateIndex("dbo.Devices", "Gateway_id");
            AddForeignKey("dbo.Devices", "Gateway_id", "dbo.Gateways", "id");
        }
    }
}

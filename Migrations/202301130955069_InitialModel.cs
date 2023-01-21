namespace Gateways.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        uid = c.Int(nullable: false),
                        vendor = c.String(),
                        dateCreated = c.String(),
                        status = c.Int(nullable: false),
                        Gateway_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Gateways", t => t.Gateway_id)
                .Index(t => t.Gateway_id);
            
            CreateTable(
                "dbo.Gateways",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        number = c.String(),
                        name = c.String(),
                        ipv4Address = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devices", "Gateway_id", "dbo.Gateways");
            DropIndex("dbo.Devices", new[] { "Gateway_id" });
            DropTable("dbo.Gateways");
            DropTable("dbo.Devices");
        }
    }
}

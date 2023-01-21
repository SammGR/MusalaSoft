namespace Gateways.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isOnlinePropertyToDevice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "isOnline", c => c.Boolean(nullable: false));
            DropColumn("dbo.Devices", "status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Devices", "status", c => c.Int(nullable: false));
            DropColumn("dbo.Devices", "isOnline");
        }
    }
}

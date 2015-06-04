namespace WN_Reclaimation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SiteVisitReport", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.SiteVisitReport", "Longitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SiteVisitReport", "Longitude");
            DropColumn("dbo.SiteVisitReport", "Latitude");
        }
    }
}

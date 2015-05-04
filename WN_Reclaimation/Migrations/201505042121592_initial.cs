namespace WN_Reclaimation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        ClientName = c.String(),
                    })
                .PrimaryKey(t => t.ClientID);
            
            CreateTable(
                "dbo.DesktopReview",
                c => new
                    {
                        DesktopReviewID = c.Int(nullable: false, identity: true),
                        FacilityTypeID = c.Int(nullable: false),
                        Site = c.String(),
                        ClientID = c.Int(nullable: false),
                        ApprovalStatus = c.String(),
                    })
                .PrimaryKey(t => t.DesktopReviewID)
                .ForeignKey("dbo.Client", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.FacilityType", t => t.FacilityTypeID, cascadeDelete: true)
                .Index(t => t.FacilityTypeID)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.FacilityType",
                c => new
                    {
                        FacilityTypeID = c.Int(nullable: false, identity: true),
                        FacilityTypeName = c.String(),
                    })
                .PrimaryKey(t => t.FacilityTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DesktopReview", "FacilityTypeID", "dbo.FacilityType");
            DropForeignKey("dbo.DesktopReview", "ClientID", "dbo.Client");
            DropIndex("dbo.DesktopReview", new[] { "ClientID" });
            DropIndex("dbo.DesktopReview", new[] { "FacilityTypeID" });
            DropTable("dbo.FacilityType");
            DropTable("dbo.DesktopReview");
            DropTable("dbo.Client");
        }
    }
}

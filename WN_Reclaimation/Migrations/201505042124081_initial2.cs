namespace WN_Reclaimation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DesktopReview", "WorkPhase", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DesktopReview", "WorkPhase");
        }
    }
}

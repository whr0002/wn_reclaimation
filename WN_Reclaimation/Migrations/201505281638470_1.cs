namespace WN_Reclaimation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DesktopReview", "ClientID", "dbo.Client");
            DropForeignKey("dbo.DesktopReview", "FacilityTypeID", "dbo.FacilityType");
            DropForeignKey("dbo.DesktopReview", "FacilityTypeName", "dbo.FacilityType");
            DropForeignKey("dbo.SiteVisitReport", "FacilityTypeName", "dbo.FacilityType");
            DropIndex("dbo.DesktopReview", new[] { "FacilityTypeID" });
            DropIndex("dbo.DesktopReview", new[] { "ClientID" });
            RenameColumn(table: "dbo.DesktopReview", name: "FacilityTypeID", newName: "FacilityTypeName");
            DropPrimaryKey("dbo.FacilityType");
            CreateTable(
                "dbo.Aspect",
                c => new
                    {
                        AspectName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.AspectName);
            
            CreateTable(
                "dbo.County",
                c => new
                    {
                        CountyName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CountyName);
            
            CreateTable(
                "dbo.Landscape",
                c => new
                    {
                        LandscapeName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.LandscapeName);
            
            CreateTable(
                "dbo.RelevantCriteria",
                c => new
                    {
                        RelevantCriteriaName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.RelevantCriteriaName);
            
            CreateTable(
                "dbo.Soil",
                c => new
                    {
                        SoilName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.SoilName);
            
            CreateTable(
                "dbo.Vegetation",
                c => new
                    {
                        VegetationName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.VegetationName);
            
            CreateTable(
                "dbo.FieldData",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Group = c.String(nullable: false),
                        Client = c.String(),
                        INSP_DATE = c.DateTime(nullable: false),
                        TimeStamp = c.String(),
                        INSP_CREW = c.String(nullable: false),
                        ACCESS = c.String(),
                        CROSS_NM = c.String(),
                        CROSS_ID = c.String(),
                        LAT = c.Double(nullable: false),
                        LONG = c.Double(nullable: false),
                        STR_ID = c.String(),
                        STR_CLASS = c.String(),
                        STR_WIDTH = c.Double(),
                        STR_WIDTHM = c.String(),
                        CHANNEL_CREEK_DEPTH_LEFT = c.Double(),
                        CHANNEL_CREEK_DEPTH_RIGHT = c.Double(),
                        CHANNEL_CREEK_DEPTH_CENTER = c.Double(),
                        FIRST_RIFFLE_DISTANCE = c.Double(),
                        ROAD_FILL_ABOVE_CULVERT = c.Double(),
                        DISPOSITION_ID = c.String(),
                        CROSS_TYPE = c.String(nullable: false),
                        EROSION = c.String(),
                        EROSION_TY1 = c.String(),
                        EROSION_TY2 = c.String(),
                        EROSION_SO = c.String(),
                        EROSION_DE = c.String(),
                        EROSION_AR = c.Double(),
                        BLOCKAGE = c.String(),
                        BLOC_MATR = c.String(),
                        BLOC_CAUS = c.String(),
                        CULV_SUBS = c.String(),
                        CULV_SLOPE = c.String(),
                        SCOUR_POOL = c.String(),
                        DELINEATOR = c.String(),
                        FISH_SAMP = c.String(),
                        FISH_SM = c.String(),
                        FISH_SPP = c.String(),
                        FISH_PCONC = c.String(),
                        FISH_SPP2 = c.String(),
                        FISH_PCONCREASON = c.String(),
                        REMARKS = c.String(),
                        PHOTO_INUP = c.String(),
                        PHOTO_INDW = c.String(),
                        PHOTO_OTUP = c.String(),
                        PHOTO_OTDW = c.String(),
                        PHOTO_ROAD_LEFT = c.String(),
                        PHOTO_ROAD_RIGHT = c.String(),
                        PHOTO_1 = c.String(),
                        PHOTO_2 = c.String(),
                        CULV_LEN = c.Double(),
                        CULV_SUBSP = c.String(),
                        CULV_SUBSTYPE = c.String(),
                        CULV_SUBSPROPORTION = c.String(),
                        CULV_BACKWATERPROPORTION = c.String(),
                        CULV_OUTLETTYPE = c.String(),
                        CULV_DIA_1 = c.Double(),
                        CULV_DIA_2 = c.Double(),
                        CULV_DIA_3 = c.Double(),
                        BRDG_LEN = c.Double(),
                        EMG_REP_RE = c.String(),
                        STU_PROBS = c.String(),
                        SEDEMENTAT = c.String(),
                        CULV_OPOOD = c.Double(),
                        CULV_OPGAP = c.Double(),
                        HAZMARKR = c.String(),
                        APROCHSIGR = c.String(),
                        APROCHRAIL = c.String(),
                        RDSURFR = c.String(),
                        RDDRAINR = c.String(),
                        VISIBILITY = c.String(),
                        WEARSURF = c.String(),
                        RAILCURBR = c.String(),
                        GIRDEBRACR = c.String(),
                        CAPBEAMR = c.String(),
                        PILESR = c.String(),
                        ABUTWALR = c.String(),
                        WINGWALR = c.String(),
                        BANKSTABR = c.String(),
                        SLOPEPROTR = c.String(),
                        CHANNELOPEN = c.String(),
                        OBSTRUCTIO = c.String(),
                        ATTACHMENT = c.String(),
                        FUTURE2 = c.String(),
                        FUTURE3 = c.String(),
                        FUTURE4 = c.String(),
                        FUTURE5 = c.String(),
                        CULV_SUBSTYPE1 = c.String(),
                        CULV_SUBSTYPE2 = c.String(),
                        CULV_SUBSTYPE3 = c.String(),
                        CULV_SUBSPROPORTION1 = c.String(),
                        CULV_SUBSPROPORTION2 = c.String(),
                        CULV_SUBSPROPORTION3 = c.String(),
                        OUTLET_SCORE = c.String(),
                        RISKF = c.Double(),
                        RISK = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FMAHolder",
                c => new
                    {
                        FMAHolderName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.FMAHolderName);
            
            CreateTable(
                "dbo.FormType",
                c => new
                    {
                        FormTypeName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.FormTypeName);
            
            CreateTable(
                "dbo.Kml",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Client = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NaturalRegion",
                c => new
                    {
                        NaturalRegionName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.NaturalRegionName);
            
            CreateTable(
                "dbo.NaturalSubRegion",
                c => new
                    {
                        NaturalSubRegionName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.NaturalSubRegionName);
            
            CreateTable(
                "dbo.OperatingArea",
                c => new
                    {
                        OperatingAreaName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.OperatingAreaName);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        Path = c.String(nullable: false, maxLength: 128),
                        FormTypeName = c.String(maxLength: 128),
                        FormID = c.Int(nullable: false),
                        Description = c.String(),
                        Classification = c.String(),
                    })
                .PrimaryKey(t => t.Path)
                .ForeignKey("dbo.FormType", t => t.FormTypeName)
                .Index(t => t.FormTypeName);
            
            CreateTable(
                "dbo.ProvincialArea",
                c => new
                    {
                        ProvincialAreaName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ProvincialAreaName);
            
            CreateTable(
                "dbo.ProvincialAreaType",
                c => new
                    {
                        ProvincialAreaTypeName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ProvincialAreaTypeName);
            
            CreateTable(
                "dbo.ReviewSite",
                c => new
                    {
                        ReviewSiteID = c.String(nullable: false, maxLength: 128),
                        DataOwner = c.String(),
                        DispositionNumber = c.String(),
                        SWPNumber = c.String(),
                        AFE = c.String(),
                        ProvincialAreaName = c.String(maxLength: 128),
                        ProvincialAreaTypeName = c.String(maxLength: 128),
                        OperatingAreaName = c.String(maxLength: 128),
                        CountyName = c.String(maxLength: 128),
                        NaturalRegionName = c.String(maxLength: 128),
                        NaturalSubRegionName = c.String(maxLength: 128),
                        FMAHolderName = c.String(maxLength: 128),
                        SeedZone = c.String(),
                        WellboreID = c.String(),
                        UWI = c.String(),
                        WellsiteName = c.String(),
                        UTMZone = c.String(),
                    })
                .PrimaryKey(t => t.ReviewSiteID)
                .ForeignKey("dbo.County", t => t.CountyName)
                .ForeignKey("dbo.FMAHolder", t => t.FMAHolderName)
                .ForeignKey("dbo.NaturalRegion", t => t.NaturalRegionName)
                .ForeignKey("dbo.NaturalSubRegion", t => t.NaturalSubRegionName)
                .ForeignKey("dbo.OperatingArea", t => t.OperatingAreaName)
                .ForeignKey("dbo.ProvincialArea", t => t.ProvincialAreaName)
                .ForeignKey("dbo.ProvincialAreaType", t => t.ProvincialAreaTypeName)
                .Index(t => t.ProvincialAreaName)
                .Index(t => t.ProvincialAreaTypeName)
                .Index(t => t.OperatingAreaName)
                .Index(t => t.CountyName)
                .Index(t => t.NaturalRegionName)
                .Index(t => t.NaturalSubRegionName)
                .Index(t => t.FMAHolderName);
            
            CreateTable(
                "dbo.SearchType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SearchTypeName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SiteVisitReport",
                c => new
                    {
                        SiteVisitReportID = c.Int(nullable: false, identity: true),
                        ReviewSiteID = c.String(maxLength: 128),
                        FacilityTypeName = c.String(maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        Username = c.String(),
                        Group = c.String(),
                        Client = c.String(),
                        RefusePF = c.String(),
                        RefuseComment = c.String(),
                        DrainagePF = c.String(),
                        DrainageComment = c.String(),
                        RockGravelPF = c.String(),
                        RockGravelComment = c.String(),
                        BareGroundPF = c.String(),
                        BareGroundComment = c.String(),
                        SoilStabilityPF = c.String(),
                        SoilStabilityComment = c.String(),
                        ContoursPF = c.String(),
                        ContoursComment = c.String(),
                        CWDPF = c.String(),
                        CWDComment = c.String(),
                        ErosionPF = c.String(),
                        ErosionComment = c.String(),
                        SoilCharPF = c.String(),
                        SoilCharComment = c.String(),
                        TopsoilDepthPF = c.String(),
                        TopsoilDepthComment = c.String(),
                        RootingPF = c.String(),
                        RootingComment = c.String(),
                        WSDPF = c.String(),
                        WSDComment = c.String(),
                        TreeHealthPF = c.String(),
                        TreeHealthComment = c.String(),
                        WeedsInvasivesPF = c.String(),
                        WeedsInvasivesComment = c.String(),
                        NSCPF = c.String(),
                        NSCComment = c.String(),
                        LitterPF = c.String(),
                        LitterComment = c.String(),
                        Recommendation = c.String(),
                    })
                .PrimaryKey(t => t.SiteVisitReportID)
                .ForeignKey("dbo.FacilityType", t => t.FacilityTypeName)
                .ForeignKey("dbo.ReviewSite", t => t.ReviewSiteID)
                .Index(t => t.ReviewSiteID)
                .Index(t => t.FacilityTypeName);
            
            AddColumn("dbo.DesktopReview", "SiteID", c => c.String(nullable: false));
            AddColumn("dbo.DesktopReview", "Notes", c => c.String());
            AddColumn("dbo.DesktopReview", "Client", c => c.String());
            AddColumn("dbo.DesktopReview", "Occupant", c => c.String());
            AddColumn("dbo.DesktopReview", "OccupantInfo", c => c.String());
            AddColumn("dbo.DesktopReview", "SoilClass", c => c.String());
            AddColumn("dbo.DesktopReview", "SoilGroup", c => c.String());
            AddColumn("dbo.DesktopReview", "ERCBLic", c => c.String());
            AddColumn("dbo.DesktopReview", "Width", c => c.Double());
            AddColumn("dbo.DesktopReview", "Length", c => c.Double());
            AddColumn("dbo.DesktopReview", "AreaHA", c => c.Double());
            AddColumn("dbo.DesktopReview", "AreaAC", c => c.Double());
            AddColumn("dbo.DesktopReview", "Northing", c => c.Double());
            AddColumn("dbo.DesktopReview", "Easting", c => c.Double());
            AddColumn("dbo.DesktopReview", "Latitude", c => c.Double());
            AddColumn("dbo.DesktopReview", "Longitude", c => c.Double());
            AddColumn("dbo.DesktopReview", "Elevation", c => c.Double());
            AddColumn("dbo.DesktopReview", "AspectName", c => c.String(maxLength: 128));
            AddColumn("dbo.DesktopReview", "LSD", c => c.String());
            AddColumn("dbo.DesktopReview", "SurveyDate", c => c.DateTime());
            AddColumn("dbo.DesktopReview", "ConstructionDate", c => c.DateTime());
            AddColumn("dbo.DesktopReview", "SpudDate", c => c.DateTime());
            AddColumn("dbo.DesktopReview", "AbandonmentDate", c => c.DateTime());
            AddColumn("dbo.DesktopReview", "ReclamationDate", c => c.DateTime());
            AddColumn("dbo.DesktopReview", "RelevantCriteriaName", c => c.String(maxLength: 128));
            AddColumn("dbo.DesktopReview", "LandscapeName", c => c.String(maxLength: 128));
            AddColumn("dbo.DesktopReview", "SoilName", c => c.String(maxLength: 128));
            AddColumn("dbo.DesktopReview", "VegetationName", c => c.String(maxLength: 128));
            AddColumn("dbo.DesktopReview", "RCADate", c => c.DateTime());
            AddColumn("dbo.DesktopReview", "RCNumber", c => c.String());
            AddColumn("dbo.DesktopReview", "DSAComments", c => c.String());
            AddColumn("dbo.DesktopReview", "Exemptions", c => c.String());
            AddColumn("dbo.DesktopReview", "AmendDate", c => c.DateTime());
            AddColumn("dbo.DesktopReview", "AmendDetail", c => c.String());
            AddColumn("dbo.DesktopReview", "RevegDate", c => c.DateTime());
            AddColumn("dbo.DesktopReview", "RevegDetail", c => c.String());
            AlterColumn("dbo.DesktopReview", "FacilityTypeName", c => c.String(maxLength: 128));
            AlterColumn("dbo.FacilityType", "FacilityTypeName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.FacilityType", "FacilityTypeName");
            CreateIndex("dbo.DesktopReview", "FacilityTypeName");
            CreateIndex("dbo.DesktopReview", "AspectName");
            CreateIndex("dbo.DesktopReview", "RelevantCriteriaName");
            CreateIndex("dbo.DesktopReview", "LandscapeName");
            CreateIndex("dbo.DesktopReview", "SoilName");
            CreateIndex("dbo.DesktopReview", "VegetationName");
            AddForeignKey("dbo.DesktopReview", "LandscapeName", "dbo.Landscape", "LandscapeName");
            AddForeignKey("dbo.DesktopReview", "AspectName", "dbo.Aspect", "AspectName");
            AddForeignKey("dbo.DesktopReview", "RelevantCriteriaName", "dbo.RelevantCriteria", "RelevantCriteriaName");
            AddForeignKey("dbo.DesktopReview", "SoilName", "dbo.Soil", "SoilName");
            AddForeignKey("dbo.DesktopReview", "VegetationName", "dbo.Vegetation", "VegetationName");
            AddForeignKey("dbo.DesktopReview", "FacilityTypeName", "dbo.FacilityType", "FacilityTypeName");
            DropColumn("dbo.DesktopReview", "Site");
            DropColumn("dbo.DesktopReview", "ClientID");
            DropColumn("dbo.FacilityType", "FacilityTypeID");
            DropTable("dbo.Client");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        ClientName = c.String(),
                    })
                .PrimaryKey(t => t.ClientID);
            
            AddColumn("dbo.FacilityType", "FacilityTypeID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.DesktopReview", "ClientID", c => c.Int(nullable: false));
            AddColumn("dbo.DesktopReview", "Site", c => c.String());
            DropForeignKey("dbo.DesktopReview", "FacilityTypeName", "dbo.FacilityType");
            DropForeignKey("dbo.SiteVisitReport", "ReviewSiteID", "dbo.ReviewSite");
            DropForeignKey("dbo.SiteVisitReport", "FacilityTypeName", "dbo.FacilityType");
            DropForeignKey("dbo.ReviewSite", "ProvincialAreaTypeName", "dbo.ProvincialAreaType");
            DropForeignKey("dbo.ReviewSite", "ProvincialAreaName", "dbo.ProvincialArea");
            DropForeignKey("dbo.ReviewSite", "OperatingAreaName", "dbo.OperatingArea");
            DropForeignKey("dbo.ReviewSite", "NaturalSubRegionName", "dbo.NaturalSubRegion");
            DropForeignKey("dbo.ReviewSite", "NaturalRegionName", "dbo.NaturalRegion");
            DropForeignKey("dbo.ReviewSite", "FMAHolderName", "dbo.FMAHolder");
            DropForeignKey("dbo.ReviewSite", "CountyName", "dbo.County");
            DropForeignKey("dbo.Photo", "FormTypeName", "dbo.FormType");
            DropForeignKey("dbo.DesktopReview", "VegetationName", "dbo.Vegetation");
            DropForeignKey("dbo.DesktopReview", "SoilName", "dbo.Soil");
            DropForeignKey("dbo.DesktopReview", "RelevantCriteriaName", "dbo.RelevantCriteria");
            DropForeignKey("dbo.DesktopReview", "AspectName", "dbo.Aspect");
            DropForeignKey("dbo.DesktopReview", "LandscapeName", "dbo.Landscape");
            DropIndex("dbo.SiteVisitReport", new[] { "FacilityTypeName" });
            DropIndex("dbo.SiteVisitReport", new[] { "ReviewSiteID" });
            DropIndex("dbo.ReviewSite", new[] { "FMAHolderName" });
            DropIndex("dbo.ReviewSite", new[] { "NaturalSubRegionName" });
            DropIndex("dbo.ReviewSite", new[] { "NaturalRegionName" });
            DropIndex("dbo.ReviewSite", new[] { "CountyName" });
            DropIndex("dbo.ReviewSite", new[] { "OperatingAreaName" });
            DropIndex("dbo.ReviewSite", new[] { "ProvincialAreaTypeName" });
            DropIndex("dbo.ReviewSite", new[] { "ProvincialAreaName" });
            DropIndex("dbo.Photo", new[] { "FormTypeName" });
            DropIndex("dbo.DesktopReview", new[] { "VegetationName" });
            DropIndex("dbo.DesktopReview", new[] { "SoilName" });
            DropIndex("dbo.DesktopReview", new[] { "LandscapeName" });
            DropIndex("dbo.DesktopReview", new[] { "RelevantCriteriaName" });
            DropIndex("dbo.DesktopReview", new[] { "AspectName" });
            DropIndex("dbo.DesktopReview", new[] { "FacilityTypeName" });
            DropPrimaryKey("dbo.FacilityType");
            AlterColumn("dbo.FacilityType", "FacilityTypeName", c => c.String());
            AlterColumn("dbo.DesktopReview", "FacilityTypeName", c => c.Int(nullable: false));
            DropColumn("dbo.DesktopReview", "RevegDetail");
            DropColumn("dbo.DesktopReview", "RevegDate");
            DropColumn("dbo.DesktopReview", "AmendDetail");
            DropColumn("dbo.DesktopReview", "AmendDate");
            DropColumn("dbo.DesktopReview", "Exemptions");
            DropColumn("dbo.DesktopReview", "DSAComments");
            DropColumn("dbo.DesktopReview", "RCNumber");
            DropColumn("dbo.DesktopReview", "RCADate");
            DropColumn("dbo.DesktopReview", "VegetationName");
            DropColumn("dbo.DesktopReview", "SoilName");
            DropColumn("dbo.DesktopReview", "LandscapeName");
            DropColumn("dbo.DesktopReview", "RelevantCriteriaName");
            DropColumn("dbo.DesktopReview", "ReclamationDate");
            DropColumn("dbo.DesktopReview", "AbandonmentDate");
            DropColumn("dbo.DesktopReview", "SpudDate");
            DropColumn("dbo.DesktopReview", "ConstructionDate");
            DropColumn("dbo.DesktopReview", "SurveyDate");
            DropColumn("dbo.DesktopReview", "LSD");
            DropColumn("dbo.DesktopReview", "AspectName");
            DropColumn("dbo.DesktopReview", "Elevation");
            DropColumn("dbo.DesktopReview", "Longitude");
            DropColumn("dbo.DesktopReview", "Latitude");
            DropColumn("dbo.DesktopReview", "Easting");
            DropColumn("dbo.DesktopReview", "Northing");
            DropColumn("dbo.DesktopReview", "AreaAC");
            DropColumn("dbo.DesktopReview", "AreaHA");
            DropColumn("dbo.DesktopReview", "Length");
            DropColumn("dbo.DesktopReview", "Width");
            DropColumn("dbo.DesktopReview", "ERCBLic");
            DropColumn("dbo.DesktopReview", "SoilGroup");
            DropColumn("dbo.DesktopReview", "SoilClass");
            DropColumn("dbo.DesktopReview", "OccupantInfo");
            DropColumn("dbo.DesktopReview", "Occupant");
            DropColumn("dbo.DesktopReview", "Client");
            DropColumn("dbo.DesktopReview", "Notes");
            DropColumn("dbo.DesktopReview", "SiteID");
            DropTable("dbo.SiteVisitReport");
            DropTable("dbo.SearchType");
            DropTable("dbo.ReviewSite");
            DropTable("dbo.ProvincialAreaType");
            DropTable("dbo.ProvincialArea");
            DropTable("dbo.Photo");
            DropTable("dbo.OperatingArea");
            DropTable("dbo.NaturalSubRegion");
            DropTable("dbo.NaturalRegion");
            DropTable("dbo.Kml");
            DropTable("dbo.FormType");
            DropTable("dbo.FMAHolder");
            DropTable("dbo.FieldData");
            DropTable("dbo.Vegetation");
            DropTable("dbo.Soil");
            DropTable("dbo.RelevantCriteria");
            DropTable("dbo.Landscape");
            DropTable("dbo.County");
            DropTable("dbo.Aspect");
            AddPrimaryKey("dbo.FacilityType", "FacilityTypeID");
            RenameColumn(table: "dbo.DesktopReview", name: "FacilityTypeName", newName: "FacilityTypeID");
            CreateIndex("dbo.DesktopReview", "ClientID");
            CreateIndex("dbo.DesktopReview", "FacilityTypeID");
            AddForeignKey("dbo.SiteVisitReport", "FacilityTypeName", "dbo.FacilityType", "FacilityTypeName");
            AddForeignKey("dbo.DesktopReview", "FacilityTypeName", "dbo.FacilityType", "FacilityTypeName");
            AddForeignKey("dbo.DesktopReview", "FacilityTypeID", "dbo.FacilityType", "FacilityTypeID", cascadeDelete: true);
            AddForeignKey("dbo.DesktopReview", "ClientID", "dbo.Client", "ClientID", cascadeDelete: true);
        }
    }
}

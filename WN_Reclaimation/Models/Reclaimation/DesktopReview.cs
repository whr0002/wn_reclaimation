using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace wn_web.Models.Reclaimation
{
    public class DesktopReview
    {
        [DisplayName("Desktop Review ID")]
        [JsonProperty("Desktop Review ID")]
        public int DesktopReviewID { get; set; }

        [Required]
        [DisplayName("Site ID")]
        [JsonProperty("Site ID")]
        public string SiteID { get; set; }

        [DisplayName("Facility Type")]
        [JsonProperty("Facility Type")]
        public string FacilityTypeName { get; set; }

        public string Notes { get; set; }

        public string Client { get; set; }

        [DisplayName("Approval Status")]
        [JsonProperty("Approval Status")]
        public string ApprovalStatus { get; set; }

        [DisplayName("Work Phase")]
        [JsonProperty("Work Phase")]
        public string WorkPhase { get; set; }

        public string Occupant { get; set; }

        [DisplayName("Occupant Info")]
        [JsonProperty("Occupant Info")]
        public string OccupantInfo { get; set; }

        [DisplayName("Soil Classification")]
        [JsonProperty("Soil Classification")]
        public string SoilClass { get; set; }

        [DisplayName("Soil Group")]
        [JsonProperty("Soil Group")]
        public string SoilGroup { get; set; }

        [DisplayName("ERCB Licence")]
        [JsonProperty("ERCB Licence")]
        public string ERCBLic { get; set; }


        public double? Width { get; set; }

        public double? Length { get; set; }

        public double? AreaHA { get; set; }

        public double? AreaAC { get; set; }

        public double? Northing { get; set; }

        public double? Easting { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public double? Elevation { get; set; }

        [DisplayName("Aspect")]
        [JsonProperty("Aspect")]
        public string AspectName { get; set; }

        public string LSD { get; set; }

        [DisplayName("Survey Date")]
        [JsonProperty("Survey Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]  
        public DateTime? SurveyDate { get; set; }

        [DisplayName("Construction Date")]
        [JsonProperty("Construction Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]  
        public DateTime? ConstructionDate { get; set; }

        [DisplayName("Spud Date")]
        [JsonProperty("Spud Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]  
        public DateTime? SpudDate { get; set; }

        [DisplayName("Abandonment Date")]
        [JsonProperty("Abandonment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]  
        public DateTime? AbandonmentDate { get; set; }

        [DisplayName("Reclamation Date")]
        [JsonProperty("")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]  
        public DateTime? ReclamationDate { get; set; }

        [DisplayName("Relevant Criteria")]
        [JsonProperty("Relevant Criteria")]
        public string RelevantCriteriaName { get; set; }

        [DisplayName("Landscapes")]
        [JsonProperty("Landscapes")]
        public string LandscapeName { get; set; }

        [DisplayName("Soils")]
        [JsonProperty("Soils")]
        public string SoilName { get; set; }

        [DisplayName("Vegetations")]
        [JsonProperty("Vegetations")]
        public string VegetationName { get; set; }

        [DisplayName("RCA Date")]
        [JsonProperty("RCA Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]  
        public DateTime? RCADate { get; set; }

        [DisplayName("RC Number")]
        [JsonProperty("RC Number")]
        public string RCNumber { get; set; }

        [DisplayName("DSARC Comment")]
        [JsonProperty("DSARC Comment")]
        public string DSAComments { get; set; }
        public string Exemptions { get; set; }

        [DisplayName("Amend Date")]
        [JsonProperty("Amend Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]  
        public DateTime? AmendDate  { get; set; }

        [DisplayName("Amend Detail")]
        [JsonProperty("Amend Detail")]
        public string AmendDetail { get; set; }

        [DisplayName("Revegetation Date")]
        [JsonProperty("Revegetation Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]  
        public DateTime? RevegDate { get; set; }

        [DisplayName("Revegetation Details")]
        [JsonProperty("Revegetation Details")]
        public string RevegDetail { get; set; }



        [ForeignKey("SiteID")]
        public virtual ReviewSite Site { get; set; }
        public virtual FacilityType FacilityType { get; set; }
        public virtual Aspect LSDQuarter { get; set; }       
        public virtual RelevantCriteria RelevantCriteria { get; set; }
        public virtual Landscape Landscape { get; set; }
        public virtual Soil Soil { get; set; }
        public virtual Vegetation Vegetation { get; set; }



    }
}
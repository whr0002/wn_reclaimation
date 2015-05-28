using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wn_web.Models;

namespace WN_Reclaimation.Models
{
    public class DesktopReview
    {
        public int DesktopReviewID { get; set; }
        public string Site { get; set; }
        public int FacilityTypeID { get; set; }      
        public int ClientID { get; set; }
        public string ApprovalStatus { get; set; }
        public string WorkPhase { get; set; }
        public string AFE { get; set; }
        public string Occupant { get; set; }
        public string OccupantInfo { get; set; }
        public string FMAholder { get; set; }
        public string Location { get; set; }
        public string Disposition { get; set; }
        public string ProvArea { get; set; }
        public string ProvAreaType { get; set; }
        public string County { get; set; }
        public string NatRegion { get; set; }
        public string NatSubRegion { get; set; }
        public string SeedZone { get; set; }
        public string SoilClass { get; set; }
        public string SoilGroup { get; set; }
        public string ERCBLic { get; set; }
        public int? WellboreID { get; set; }
        public string UWI { get; set; }
        public string WellsiteName { get; set; }
        public double? Width { get; set; }
        public double? Length { get; set; }
        public int MyProperty { get; set; }








        public virtual FacilityType FacilityType { get; set; }
        public virtual Client Client { get; set; }
    }
}
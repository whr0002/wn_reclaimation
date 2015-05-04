using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WN_Reclaimation.Models
{
    public class DesktopReview
    {
        public int DesktopReviewID { get; set; }
        public int FacilityTypeID { get; set; }
        public string Site { get; set; }
        public int ClientID { get; set; }
        public string ApprovalStatus { get; set; }
        public string WorkPhase { get; set; }


        public virtual FacilityType FacilityType { get; set; }
        public virtual Client Client { get; set; }
    }
}
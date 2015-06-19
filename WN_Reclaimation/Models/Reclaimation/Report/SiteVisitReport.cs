using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wn_web.Models.Reclaimation.Report
{
    public class SiteVisitReport
    {
        [DisplayName("Site Visit Report ID")]
        [JsonProperty("Site Visit Report ID")]
        public int SiteVisitReportID { get; set; }

        [DisplayName("Site ID")]
        [JsonProperty("Site ID")]
        public string ReviewSiteID { get; set; }

        [DisplayName("Facility Type")]
        [JsonProperty("Facility Type")]
        public string FacilityTypeName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string Username { get; set; }

        public string Group { get; set; }

        public string Client { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [DisplayName("Refuse Pass/Fail")]
        [JsonProperty("Refuse Pass/Fail")]
        public string RefusePF { get; set; }

        [DisplayName("Refuse Comment")]
        [JsonProperty("Refuse Comment")]
        public string RefuseComment { get; set; }

        [DisplayName("Drainage Pass/Fail")]
        [JsonProperty("Drainage Pass/Fail")]
        public string DrainagePF { get; set; }

        [DisplayName("Drainage Comment")]
        [JsonProperty("Drainage Comment")]
        public string DrainageComment { get; set; }

        [DisplayName("Rock Gravel Pass/Fail")]
        [JsonProperty("Rock Gravel Pass/Fail")]
        public string RockGravelPF { get; set; }

        [DisplayName("Rock Gravel Comment")]
        [JsonProperty("Rock Gravel Comment")]
        public string RockGravelComment { get; set; }

        [DisplayName("Bare Ground Pass/Fail")]
        [JsonProperty("Bare Ground Pass/Fail")]
        public string BareGroundPF { get; set; }

        [DisplayName("Bare Ground Comment")]
        [JsonProperty("Bare Ground Comment")]
        public string BareGroundComment { get; set; }

        [DisplayName("Soil Stability Pass/Fail")]
        [JsonProperty("Soil Stability Pass/Fail")]
        public string SoilStabilityPF { get; set; }

        [DisplayName("Soil Stability Comment")]
        [JsonProperty("Soil Stability Comment")]
        public string SoilStabilityComment { get; set; }

        [DisplayName("Contours Pass/Fail")]
        [JsonProperty("Contours Pass/Fail")]
        public string ContoursPF { get; set; }

        [DisplayName("Contours Comment")]
        [JsonProperty("Contours Comment")]
        public string ContoursComment { get; set; }

        [DisplayName("Coarse Woody Debris Pass/Fail")]
        [JsonProperty("Coarse Woody Debris Pass/Fail")]
        public string CWDPF { get; set; }

        [DisplayName("Coarse Woody Debris Comment")]
        [JsonProperty("Coarse Woody Debris Comment")]
        public string CWDComment { get; set; }

        [DisplayName("Erosion Pass/Fail")]
        [JsonProperty("Erosion Pass/Fail")]
        public string ErosionPF { get; set; }

        [DisplayName("Erosion Comment")]
        [JsonProperty("Erosion Comment")]
        public string ErosionComment { get; set; }

        [DisplayName("Soil Characteristics Pass/Fail")]
        [JsonProperty("Soil Characteristics Pass/Fail")]
        public string SoilCharPF { get; set; }

        [DisplayName("Soil Characteristics Comment")]
        [JsonProperty("Soil Characteristics Comment")]
        public string SoilCharComment { get; set; }

        [DisplayName("Topsoil Depth Pass/Fail")]
        [JsonProperty("Topsoil Depth Pass/Fail")]
        public string TopsoilDepthPF { get; set; }

        [DisplayName("Topsoil Depth Comment")]
        [JsonProperty("Topsoil Depth Comment")]
        public string TopsoilDepthComment { get; set; }

        [DisplayName("Rooting Restrictions Pass/Fail")]
        [JsonProperty("Rooting Restrictions Pass/Fail")]
        public string RootingPF { get; set; }

        [DisplayName("Rooting Restrictions Comment")]
        [JsonProperty("Rooting Restrictions Comment")]
        public string RootingComment { get; set; }

        [DisplayName("Woody Stem Density Pass/Fail")]
        [JsonProperty("Woody Stem Density Pass/Fail")]
        public string WSDPF { get; set; }

        [DisplayName("Woody Stem Density Comment")]
        [JsonProperty("Woody Stem Density Comment")]
        public string WSDComment { get; set; }

        [DisplayName("Tree Health Pass/Fail")]
        [JsonProperty("Tree Health Pass/Fail")]
        public string TreeHealthPF { get; set; }

        [DisplayName("Tree Health Comment")]
        [JsonProperty("Tree Health Comment")]
        public string TreeHealthComment { get; set; }


        [DisplayName("Weeds and Invasives Pass/Fail")]
        [JsonProperty("Weeds and Invasives Pass/Fail")]
        public string WeedsInvasivesPF { get; set; }


        [DisplayName("Weeds and Invasives Comment")]
        [JsonProperty("Weeds and Invasives Comment")]
        public string WeedsInvasivesComment { get; set; }

        [DisplayName("Native Species Cover Pass/Fail")]
        [JsonProperty("Native Species Cover Pass/Fail")]
        public string NSCPF { get; set; }

        [DisplayName("Native Species Cover Comment")]
        [JsonProperty("Native Species Cover Comment")]
        public string NSCComment { get; set; }

        [DisplayName("Litter/LFH Pass/Fail")]
        [JsonProperty("Litter/LFH Pass/Fail")]
        public string LitterPF { get; set; }

        [DisplayName("Litter/LFH Comment")]
        [JsonProperty("Litter/LFH Comment")]
        public string LitterComment { get; set; }

        public string Recommendation { get; set; }


        public virtual ReviewSite ReviewSite { get; set; }
        public virtual FacilityType FacilityType { get; set; }
    }
}
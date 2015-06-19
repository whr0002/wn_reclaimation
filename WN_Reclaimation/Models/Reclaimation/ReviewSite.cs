using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wn_web.Models.Reclaimation
{
    public class ReviewSite
    {
        [Required]
        [DisplayName("Site ID")]
        [JsonProperty("Site ID")]
        public string ReviewSiteID { get; set; }

        [DisplayName("Data Owner")]
        [JsonProperty("Data Owner")]
        public string DataOwner { get; set; }

        [DisplayName("Disposition Number")]
        [JsonProperty("Disposition Number")]
        public string DispositionNumber { get; set; }

        [DisplayName("SWP Number")]
        [JsonProperty("SWP Number")]
        public string SWPNumber { get; set; }

        public string AFE { get; set; }

        [DisplayName("Provincial Area")]
        [JsonProperty("Provincial Area")]
        public string ProvincialAreaName { get; set; }

        [DisplayName("Provincial Area Type")]
        [JsonProperty("Provincial Area Type")]
        public string ProvincialAreaTypeName { get; set; }

        [DisplayName("Operating Area")]
        [JsonProperty("Operating Area")]
        public string OperatingAreaName { get; set; }

        [DisplayName("County ")]
        [JsonProperty("County ")]
        public string CountyName { get; set; }

        [DisplayName("Natural Region")]
        [JsonProperty("Natural Region")]
        public string NaturalRegionName { get; set; }

        [DisplayName("Natural Sub Region")]
        [JsonProperty("Natural Sub Region")]
        public string NaturalSubRegionName { get; set; }

        [DisplayName("FMA Holder")]
        [JsonProperty("FMA Holder")]
        public string FMAHolderName { get; set; }

        [DisplayName("Seed Zone")]
        [JsonProperty("Seed Zone")]
        public string SeedZone { get; set; }

        [DisplayName("Wellbore ID")]
        [JsonProperty("Wellbore ID")]
        public string WellboreID { get; set; }

        public string UWI { get; set; }

        [DisplayName("Wellsite Name")]
        [JsonProperty("Wellsite Name")]
        public string WellsiteName { get; set; }

        [DisplayName("UTM Zone")]
        [JsonProperty("UTM Zone")]
        public string UTMZone { get; set; }



        public virtual ProvincialArea ProvincialArea { get; set; }
        public virtual ProvincialAreaType ProvincialAreaType { get; set; }
        public virtual OperatingArea OperatingArea { get; set; }
        public virtual County County { get; set; }
        public virtual NaturalRegion NaturalRegion { get; set; }
        public virtual NaturalSubRegion NaturalSubRegion { get; set; }
        public virtual FMAHolder FMAHolder { get; set; }

    }
}
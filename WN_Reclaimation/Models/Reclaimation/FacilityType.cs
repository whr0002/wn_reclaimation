using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace wn_web.Models.Reclaimation
{
    public class FacilityType
    {
        [DisplayName("Facility Type")]
        [JsonProperty("Facility Type")]
        public string FacilityTypeName { get; set; }
    }
}
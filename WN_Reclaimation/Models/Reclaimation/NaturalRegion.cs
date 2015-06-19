using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace wn_web.Models.Reclaimation
{
    public class NaturalRegion
    {
        [DisplayName("Natural Region")]
        [JsonProperty("Natural Region")]
        public string NaturalRegionName { get; set; }
    }
}
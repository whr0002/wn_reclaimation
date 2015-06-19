using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace wn_web.Models.Reclaimation
{
    public class NaturalSubRegion
    {
        [DisplayName("Natural Sub Region")]
        [JsonProperty("Natural sub Region")]
        public string NaturalSubRegionName { get; set; }
    }
}
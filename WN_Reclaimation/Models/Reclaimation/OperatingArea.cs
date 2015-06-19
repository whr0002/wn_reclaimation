using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace wn_web.Models.Reclaimation
{
    public class OperatingArea
    {
        [DisplayName("Operating Area")]
        [JsonProperty("Operating Area")]
        public string OperatingAreaName { get; set; }
    }
}
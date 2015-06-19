using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace wn_web.Models.Reclaimation
{
    public class ProvincialArea
    {
        [DisplayName("Provincial Area")]
        [JsonProperty("Provincial Area")]
        public string ProvincialAreaName { get; set; }
    }
}
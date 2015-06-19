using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace wn_web.Models.Reclaimation
{
    public class Landscape
    {
        [DisplayName("Landscape")]
        [JsonProperty("Landscape")]
        public string LandscapeName { get; set; }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace wn_web.Models.Reclaimation
{
    public class Vegetation
    {
        [DisplayName("Vegetation")]
        [JsonProperty("Vegetation")]
        public string VegetationName { get; set; }
    }
}
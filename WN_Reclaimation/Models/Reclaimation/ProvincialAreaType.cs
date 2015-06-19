using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace wn_web.Models.Reclaimation
{
    public class ProvincialAreaType
    {
        [DisplayName("Provincial Area Type")]
        [JsonProperty("Provincial Area Type")]
        public string ProvincialAreaTypeName { get; set; }
    }
}
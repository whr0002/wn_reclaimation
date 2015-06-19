using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace wn_web.Models.Reclaimation
{
    public class Aspect
    {
        [DisplayName("Aspect")]
        [JsonProperty("Aspect")]
        public string AspectName { get; set; }
    }
}
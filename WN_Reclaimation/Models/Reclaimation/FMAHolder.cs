using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace wn_web.Models.Reclaimation
{
    public class FMAHolder
    {
        [DisplayName("FMA Holder")]
        [JsonProperty("FMA Holder")]
        public string FMAHolderName { get; set; }
    }
}
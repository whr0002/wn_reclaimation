using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace wn_web.Models.Reclaimation
{
    public class RelevantCriteria
    {
        [DisplayName("Relevant Criteria")]
        [JsonProperty("Relevant Criteria")]
        public string RelevantCriteriaName { get; set; }
    }
}
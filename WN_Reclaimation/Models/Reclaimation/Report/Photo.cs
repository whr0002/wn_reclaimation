using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wn_web.Models.Reclaimation.Report
{
    public class Photo
    {
        [Required]
        public string Path { get; set; }

        public string FormTypeName { get; set; }

        public int FormID { get; set; }

        public string Description { get; set; }

        public string Classification { get; set; }

        public virtual FormType FormType { get; set; }

    }
}
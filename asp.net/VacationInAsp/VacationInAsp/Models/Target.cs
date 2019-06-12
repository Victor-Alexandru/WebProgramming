using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VacationInAsp.Models
{
    public class Target
    {

        public long target_id { get; set; }

        public long destination_id { get; set; }
        public string target_name { get; set; }

    }
}
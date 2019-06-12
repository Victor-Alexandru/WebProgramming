using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VacationInAsp.Models
{
    public class Destination
    {
        private int id;
        private string locationName;
        private string countryName;
        private int costPerDay;

        public Destination()
        {
        }

        public Destination(long id, string locationName, string countryName, string description, long costPerDay)
        {
            this.destination_id = id;
            this.location_name = locationName;
            this.country_name = countryName;
            this.description = description;
            this.cost_per_day= costPerDay;
        }

        public long destination_id { get; set; }
        public string location_name { get; set; }
        public string country_name { get; set; }
        public string description { get; set; }
        public long cost_per_day { get; set; }
    }
}
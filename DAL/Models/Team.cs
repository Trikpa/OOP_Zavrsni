using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DAL.Models
{
	public class Team
	{
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("goals")]
        public long Goals { get; set; }

        [JsonProperty("penalties")]
        public long Penalties { get; set; }
    }
}

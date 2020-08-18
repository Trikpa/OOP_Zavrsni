using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DAL.Models
{
	public class Player
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("captain")]
		public bool IsCaptain { get; set; }

		[JsonProperty("shirt_number")]
		public int ShirtNumber { get; set; }

		[JsonProperty("position")]
		public string Position { get; set; }
	}
}

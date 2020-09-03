using System;
using System.Collections.Generic;
using System.Text;
using DAL.JsonConverters;
using DAL.Models.Enums;
using Newtonsoft.Json;

namespace DAL.Models
{
	public class Player : IComparable<Player>
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("captain")]
		public bool IsCaptain { get; set; }

		[JsonProperty("shirt_number")]
		public int ShirtNumber { get; set; }

		[JsonProperty("position")]
		[JsonConverter(typeof(PositionConverter))]
		public Position Position { get; set; }

		public override string ToString() => $"{Name} ({ShirtNumber})";
		public override bool Equals( object obj )
		{
			if ( obj is Player p )
				return p.ToString().Equals(this.ToString());

			return false;
		}
		public int CompareTo( Player other ) => this.Name.CompareTo(other.Name);
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DAL.Models
{
	public class Representation : IComparable<Representation>
	{
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("alternate_name")]
        public string AlternateName { get; set; }

        [JsonProperty("fifa_code")]
        public string FifaCode { get; set; }

        [JsonProperty("group_id")]
        public int GroupId { get; set; }

        [JsonProperty("group_letter")]
        public string GroupLetter { get; set; }

        public int CompareTo( Representation other ) => this.Country.CompareTo(other.Country);

		public override bool Equals( object obj )
		{
            if ( obj is Representation other )
                if ( other.Id == this.Id &&
                    other.GroupLetter == this.GroupLetter &&
                    other.GroupId == this.GroupId &&
                    other.FifaCode == this.FifaCode &&
                    other.Country == this.Country &&
                    other.AlternateName == this.AlternateName)
                        return true;

            return false;
		}

        public override int GetHashCode() => Id.GetHashCode();

		public override string ToString() => $"{Country} ({FifaCode})";
	}
}

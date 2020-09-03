using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using DAL.Utilities.Events;

namespace DAL.Models
{
	public class PlayerVM
	{
		public Player Player { get; set; }
		public string PicturePath { get; set; } = string.Empty;
		public bool IsFavorite { get; set; } = false;

		public override string ToString() => Player.ToString();
		public override bool Equals( object obj )
		{
			if ( obj is PlayerVM p )
				return p.Player.Equals(this.Player);

			return false;
		}
		public override int GetHashCode() => Player.Name.GetHashCode();
	}
}

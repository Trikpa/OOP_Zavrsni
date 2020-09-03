using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL.Utilities.Events
{
	public class PlayerFavoritedEventArgs : EventArgs
	{
		public PlayerVM Player { get; set; }
	}

	public delegate void PlayerFavoritedEventHandler( object sender, PlayerFavoritedEventArgs args );
}

using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models.Enums;

namespace DAL.Models
{
	public class PlayersSaveFile
	{
		public List<PlayerVM> Players { get; set; }
		public ChampionshipType ChampionshipType { get; set; }
		public Representation Representation { get; set; }
	}
}

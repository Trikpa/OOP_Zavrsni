using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models.Enums;

namespace DAL.Models
{
	public class RepresentationSaveFile
	{
		public Representation Representation { get; set; }
		public ChampionshipType ChampionshipType { get; set; }

		public RepresentationSaveFile( Representation representation, ChampionshipType championshipType )
		{
			Representation = representation;
			ChampionshipType = championshipType;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using DAL.Models.Enums;
using Newtonsoft.Json;

namespace DAL.Utilities
{
	public class Settings
	{
		public string Language { get; set; }
		public ChampionshipType ChampionshipType { get; set; }

		public Settings( string language, ChampionshipType championshipType )
		{
			Language = language;
			ChampionshipType = championshipType;
		}

		public static void SaveSettings( ChampionshipType championshipType, string filePath )
		{
			Settings settings = new Settings(Thread.CurrentThread.CurrentUICulture.Name, championshipType);

			string serializedString = JsonConvert.SerializeObject(settings);

			File.WriteAllText(filePath, serializedString);
		}
	}
}

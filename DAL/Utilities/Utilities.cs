using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DAL.Models;
using DAL.Models.Enums;
using Newtonsoft.Json;

namespace DAL.Utilities
{
	public static class Utilities
	{
		public static void SetCultureForForm( string culture, Form form )
		{
			CultureInfo ci = new CultureInfo(culture);
			Thread.CurrentThread.CurrentCulture = ci;
			Thread.CurrentThread.CurrentUICulture = ci;

			foreach ( Control control in form.Controls )
			{
				var resources = new ComponentResourceManager(form.GetType());

				var text = resources.GetString(control.Name + ".Text", ci);

				if ( text != null )
					control.Text = text;
			}
		}
		
		public static void SetCulture( string culture )
		{
			CultureInfo ci = new CultureInfo(culture);
			Thread.CurrentThread.CurrentCulture = ci;
			Thread.CurrentThread.CurrentUICulture = ci;
		}

		public static void SaveDataToFile( object objectToSave, string filePath )
		{
			try
			{
				var jsonString = JsonConvert.SerializeObject(objectToSave);

				File.WriteAllText(filePath, jsonString);
			}
			catch ( Exception )
			{
			}
		}

		public static Settings LoadSettings( string settingsFilePath )
		{
			string jsonSettings = File.ReadAllText(settingsFilePath);

			Settings settings = JsonConvert.DeserializeObject<Settings>(jsonSettings);

			return settings;
		}

		public static void SavePlayersToFile( List<Player> playersData, ChampionshipType championshipType, Representation representation, string filePath )
		{
			List<PlayerVM> players = new List<PlayerVM>();

			foreach ( var player in playersData )
				players.Add(new PlayerVM { Player = player });

			var jsonString = JsonConvert.SerializeObject(new PlayersSaveFile { Players = players, ChampionshipType = championshipType, Representation = representation });

			File.WriteAllText(filePath, jsonString);
		}
		
		public static void SavePlayersToFile( List<PlayerVM> playersData, ChampionshipType championshipType, Representation representation, string filePath )
		{
			var jsonString = JsonConvert.SerializeObject(new PlayersSaveFile { Players = playersData, ChampionshipType = championshipType, Representation = representation });

			File.WriteAllText(filePath, jsonString);
		}

		public static void SavePlayerToFile( PlayerVM player, PlayersSaveFile saveFile, string filePath )
		{
			saveFile.Players[ saveFile.Players.FindIndex(p => p.Equals(player)) ] = player;

			var json = JsonConvert.SerializeObject(saveFile);

			File.WriteAllText(filePath, json);
		}
	}
}

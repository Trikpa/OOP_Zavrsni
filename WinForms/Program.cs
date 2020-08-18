using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Utilities;

namespace WinForms
{
	static class Program
	{
		private const string SETTINGS_FILEPATH = "../../settings.json";

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			if ( !File.Exists(SETTINGS_FILEPATH) )
				Application.Run(new StartingWindow());
			else
			{
				try
				{
					Settings settings = JsonConvert.DeserializeObject<Settings>( File.ReadAllText(SETTINGS_FILEPATH) );

					CultureInfo ci = new CultureInfo(settings.Language);
					Thread.CurrentThread.CurrentCulture = ci;
					Thread.CurrentThread.CurrentUICulture = ci;

					Application.Run(new StatisticsForm(settings.ChampionshipType));
				}
				catch ( Exception e )
				{
					Application.Run(new StartingWindow());
					MessageBox.Show($"Error trying to read settings file! {e.Message}");
				}
			}
		}
	}
}

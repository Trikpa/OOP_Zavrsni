using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Utilities;

namespace WinForms
{
	public partial class StartingWindow : Form
	{
		private const string SETTINGS_FILEPATH = "../../settings.json";
		public StartingWindow()
		{
			InitializeComponent();
			FillLanguageBox();
		}

		private void FillLanguageBox()
		{
			cbLanguage.Items.Add(new Language("Hrvatski", "hr"));
			cbLanguage.Items.Add(new Language("English", "en"));
		}

		private void CbLanguage_SelectedIndexChanged( object sender, EventArgs e )
		{
			var chosenLanguage = ( sender as ComboBox ).SelectedItem as Language;
			SetCulture(chosenLanguage.Tag);
		}

		private void GenderSelected( object sender, EventArgs e )
		{
			var clickedButton = sender as Button;

			SaveSettings(clickedButton.Tag.ToString());
			OpenNextForm(clickedButton.Tag.ToString());
		}

		private void OpenNextForm( string championshipType )
		{
			this.Hide();
			new StatisticsForm(championshipType).Show();
		}

		private void SaveSettings( string championshipType )
		{
			string selectedChampionship = "male";

			switch ( championshipType )
			{
				case "male":
					selectedChampionship = "male";
					break;
				case "female":
					selectedChampionship = "female";
					break;
			}

			var settings = new Settings
			{
				ChampionshipType = selectedChampionship,
				Language = Thread.CurrentThread.CurrentUICulture.Name
			};

			string serializedString = JsonConvert.SerializeObject(settings);
			try
			{
				File.WriteAllText(SETTINGS_FILEPATH, serializedString);
			}
			catch ( Exception e )
			{
				MessageBox.Show($"Error! {e.Message}");
			}
		}

		private void SetCulture( string culture )
		{
			CultureInfo ci = new CultureInfo(culture);
			Thread.CurrentThread.CurrentCulture = ci;
			Thread.CurrentThread.CurrentUICulture = ci;

			foreach ( Control control in Controls )
			{
				var resources = new ComponentResourceManager(typeof(StartingWindow));

				var text = resources.GetString(control.Name + ".Text", ci);

				if ( text != null )
					control.Text = text;
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Models.Enums;
using DAL.Utilities;
using Newtonsoft.Json;

namespace WinForms
{
	public partial class SettingsForm : Form
	{
		public Settings Settings { get; private set; }
		public SettingsForm()
		{
			InitializeComponent();
			InitializeLanguageAndRepresentationCB();
			StartPosition = FormStartPosition.CenterScreen;
		}

		private void InitializeLanguageAndRepresentationCB()
		{
			FillLanguageBox();
			FillRepresentationBox();
			LoadSettings();
		}

		private void LoadSettings()
		{
			try
			{
				string settingsString = File.ReadAllText(Properties.Settings.Default.Settings_Filepath);

				Settings = JsonConvert.DeserializeObject<Settings>(settingsString);

				string appLanguage = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;

				foreach ( var item in cbLanguage.Items )
				{
					var currentLanguage = item as Language;
					if ( currentLanguage.Tag == appLanguage )
						cbLanguage.SelectedItem = currentLanguage;
				}

				cbChampionship.SelectedItem = Settings.ChampionshipType;
			}
			catch ( Exception ex )
			{
				MessageBox.Show($"Unable to read settings. {ex.Message}");
			}
		}

		private void FillRepresentationBox()
		{
			cbChampionship.Items.Add(ChampionshipType.Male);
			cbChampionship.Items.Add(ChampionshipType.Female);
		}

		private void FillLanguageBox()
		{
			cbLanguage.Items.Add(new Language("Hrvatski", "hr"));
			cbLanguage.Items.Add(new Language("English", "en"));
		}

		private void BtnSave_Click( object sender, EventArgs e )
		{
			Settings.Language = (cbLanguage.SelectedItem as Language).Tag;
			Settings.ChampionshipType = (ChampionshipType)cbChampionship.SelectedItem;
		}
	}
}

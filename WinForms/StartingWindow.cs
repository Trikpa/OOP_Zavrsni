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
using DAL.Models.Enums;

namespace WinForms
{
	public partial class StartingWindow : Form
	{
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
			Utilities.SetCultureForForm(chosenLanguage.Tag, this);
		}

		private void GenderSelected( object sender, EventArgs e )
		{
			var clickedButton = sender as Button;
			var chosenChampionship = (ChampionshipType)Enum.Parse(typeof(ChampionshipType), clickedButton.Tag.ToString());

			try
			{
				Settings.SaveSettings(chosenChampionship, Properties.Settings.Default.Settings_Filepath);
			}
			catch ( Exception ex )
			{
				MessageBox.Show($"Error while trying to save settings. {ex.Message}");
			}

			OpenChampionshipForm(chosenChampionship);
		}

		private void OpenChampionshipForm( ChampionshipType championshipType )
		{
			this.Hide();
			new PlayersForm(championshipType).Show();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DAL.Models.Enums;
using DAL.Utilities;
using Newtonsoft.Json;

namespace Wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private Settings Settings { get; set; }

		public MainWindow()
		{
			LoadSettingsFile();
			Utilities.SetCulture(Settings.Language);

			InitializeComponent();

			InitLanguage();

			InitCbChampionship();
		}

		private void LoadSettingsFile()
		{
			if ( File.Exists(Properties.Settings.Default.Settings_Filepath) )
				Settings = Utilities.LoadSettings(Properties.Settings.Default.Settings_Filepath);
			else
			{
				string lang = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;

				Settings = new Settings(lang, ChampionshipType.Male);

				Utilities.SaveDataToFile(Settings, Properties.Settings.Default.Settings_Filepath);
			}
		}

		private void InitLanguage()
		{
			if ( Settings.Language == "hr" )
				cbLanguage.SelectedIndex = 0;
			else
				cbLanguage.SelectedIndex = 1;
		}

		private void InitCbChampionship()
		{
			cbChampionship.Items.Add(ChampionshipType.Male);
			cbChampionship.Items.Add(ChampionshipType.Female);

			cbChampionship.SelectedItem = Settings.ChampionshipType;
		}

		private void CbLanguage_OnSelectionChanged( object sender, SelectionChangedEventArgs e )
		{
			var cbox = sender as ComboBox;

			var cboxSelectedItem = cbox.SelectedItem as ComboBoxItem;

			if ( cboxSelectedItem.Tag.ToString() == "hr" )
				Utilities.SetCulture("hr");
			else if ( cboxSelectedItem.Tag.ToString() == "en" )
				Utilities.SetCulture("en");

			Settings.Language = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
		}

		private void CbChampionship_SelectionChanged( object sender, SelectionChangedEventArgs e )
			=> Settings.ChampionshipType = ( (ChampionshipType)cbChampionship.SelectedItem );

		private void BtnSave_Click( object sender, RoutedEventArgs e )
		{
			Utilities.SaveDataToFile(Settings, Properties.Settings.Default.Settings_Filepath);
			this.Hide();
			new RepresentationWindow(Settings.ChampionshipType).Show();
		}
	}
}

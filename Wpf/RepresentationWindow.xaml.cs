using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Windows.Shapes;
using DAL.Models;
using DAL.Models.Enums;
using DAL.Repository;
using DAL.Utilities;
using DAL.Utilities.Interfaces;
using Newtonsoft.Json;
using Wpf.UserControls;

namespace Wpf
{
	/// <summary>
	/// Interaction logic for RepresentationWindow.xaml
	/// </summary>
	public partial class RepresentationWindow : Window
	{
		private ChampionshipType ChampionshipType { get; set; }
		private List<Representation> Representations { get; set; }
		private List<PlayerVM> Players { get; set; } = new List<PlayerVM>();
		private List<Match> MatchesPlayed { get; set; }
		private IRepresentationRepo RepresentationRepo { get; set; }
		private Representation FavoriteRepresentation { get; set; }

		public RepresentationWindow( ChampionshipType championshipType )
		{
			InitializeComponent();

			ChampionshipType = championshipType;

			FillCbChampionship();

			LoadCbRepresentations();
		}

		private async void LoadCbRepresentations()
		{
			switch ( ChampionshipType )
			{
				case ChampionshipType.Male:
					RepresentationRepo = new MaleRepresentation();
					break;
				case ChampionshipType.Female:
					RepresentationRepo = new FemaleRepresentation();
					break;
			}

			Cursor = Cursors.Wait;
			Representations = (List<Representation>)await RepresentationRepo.GetAllTeams();
			Cursor = Cursors.Arrow;

			if ( Representations != null )
			{
				Representations.Sort();

				foreach ( var representation in Representations )
					cbRepresentations.Items.Add(representation);

				if ( File.Exists(Properties.Settings.Default.Representation_Filepath) )
				{
					var jsonRepresentation = File.ReadAllText(Properties.Settings.Default.Representation_Filepath);

					if ( !string.IsNullOrEmpty(jsonRepresentation) )
					{
						RepresentationSaveFile saveFile = JsonConvert.DeserializeObject<RepresentationSaveFile>(jsonRepresentation);
						if ( saveFile.ChampionshipType == this.ChampionshipType )
						{
							FavoriteRepresentation = saveFile.Representation;
							cbRepresentations.SelectedItem = FavoriteRepresentation;
						}
					}
				}
			}
			else
				MessageBox.Show("Unable to fetch representation data!");
		}

		private async void BtnRepresentationInfo_Click( object sender, RoutedEventArgs e )
		{
			var chosenRep = (sender as Button).Tag.ToString();

			if ( chosenRep != null && chosenRep == "favoriteRepresentation" )
				new RepresentationInfoWindow(MatchesPlayed, FavoriteRepresentation).ShowDialog();
			else
			{
				if ( cbOpponents.SelectedItem is Team opponent )
				{
					List<Match> opponentMatches = await RepresentationRepo.GetMatchesForCountry(new Representation { Country = opponent.Country, FifaCode = opponent.Code });
					new RepresentationInfoWindow(opponentMatches, opponent).ShowDialog();
				}
			}
		}

		private void BtnFormation_Click( object sender, RoutedEventArgs e )
		{
			if ( cbOpponents.SelectedItem is Team opponentRep )
			{
				foreach ( var match in MatchesPlayed )
					if ( ( match.HomeTeam.Code == FavoriteRepresentation.FifaCode && match.AwayTeam.Code == opponentRep.Code ) || ( match.AwayTeam.Code == FavoriteRepresentation.FifaCode && match.HomeTeam.Code == opponentRep.Code ) )
						new FormationWindow(match, FavoriteRepresentation).ShowDialog();
			}
			else
				MessageBox.Show("Odaberite protivničku reprezentaciju! Select an opponent representation!");
		}

		private async void CbRepresentations_SelectionChanged( object sender, SelectionChangedEventArgs e )
		{
			spFavoriteRepresentation.Children.Clear();
			spOpponentRepresentation.Children.Clear();
			cbOpponents.Items.Clear();

			Players.Clear();

			FavoriteRepresentation = cbRepresentations.SelectedItem as Representation;

			if (File.Exists(Properties.Settings.Default.Players_Filepath))
			{
				var jsonSaveFile = File.ReadAllText(Properties.Settings.Default.Players_Filepath);
				if (!string.IsNullOrEmpty(jsonSaveFile))
				{
					PlayersSaveFile playersSaveFile = JsonConvert.DeserializeObject<PlayersSaveFile>(jsonSaveFile);
					if (playersSaveFile.ChampionshipType == this.ChampionshipType && playersSaveFile.Representation.FifaCode == FavoriteRepresentation.FifaCode)
					{
						Players = playersSaveFile.Players;
						FillStackPanelWithPlayers(spFavoriteRepresentation, Players);
						InitializeOpponentComponents();
						return;
					}
				}
			}

			List<Player> players = await RepresentationRepo.GetPlayers(FavoriteRepresentation.FifaCode);
			players.Sort();

			foreach ( var player in players )
				Players.Add(new PlayerVM { Player = player });

			Utilities.SaveDataToFile(new RepresentationSaveFile(FavoriteRepresentation, ChampionshipType), Properties.Settings.Default.Representation_Filepath); ;
			Utilities.SavePlayersToFile(Players, ChampionshipType, FavoriteRepresentation, Properties.Settings.Default.Players_Filepath);

			FillStackPanelWithPlayers(spFavoriteRepresentation, Players);

			InitializeOpponentComponents();
		}

		private async void InitializeOpponentComponents()
		{
			MatchesPlayed = await RepresentationRepo.GetMatchesForCountry(FavoriteRepresentation);

			foreach ( var match in MatchesPlayed )
			{
				if ( match.HomeTeam.Code == FavoriteRepresentation.FifaCode )
					cbOpponents.Items.Add(match.AwayTeam);
				else
					cbOpponents.Items.Add(match.HomeTeam);
			}
		}

		private void FillStackPanelWithPlayers( StackPanel stackPanel, List<PlayerVM> players )
		{
			foreach ( var player in players )
				stackPanel.Children.Add(new PlayerUC(player));
		}

		private void Window_Closed( object sender, EventArgs e ) => Application.Current.Shutdown();

		private async void CbOpponents_SelectionChanged( object sender, SelectionChangedEventArgs e )
		{
			spOpponentRepresentation.Children.Clear();


			if ( cbOpponents.SelectedItem is Team selectedRep )
			{
				List<Player> players = await RepresentationRepo.GetPlayers(selectedRep.Code);

				foreach ( var player in players )
					spOpponentRepresentation.Children.Add(new PlayerUC(player));
			}
		}

		private void CbChampionship_SelectionChanged( object sender, SelectionChangedEventArgs e )
		{
			ChampionshipType = (ChampionshipType)cbChampionship.SelectedItem;
			LoadCbRepresentations();
			Utilities.SaveDataToFile(new Settings(Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName, ChampionshipType), Properties.Settings.Default.Settings_Filepath);
		}

		private void FillCbChampionship()
		{
			cbChampionship.Items.Add(ChampionshipType.Male);
			cbChampionship.Items.Add(ChampionshipType.Female);

			cbChampionship.SelectionChanged -= CbChampionship_SelectionChanged;

			cbChampionship.SelectedItem = ChampionshipType;

			cbChampionship.SelectionChanged += CbChampionship_SelectionChanged;
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Models;
using DAL.Models.Enums;
using DAL.Repository;
using DAL.Utilities;
using DAL.Utilities.Interfaces;
using Newtonsoft.Json;
using DAL.Utilities.Events;

namespace WinForms
{
	public partial class PlayersForm : Form
	{
		private ChampionshipType ChampionshipType { get; set; }
		private List<Representation> RepresentationsData { get; set; }
		private List<Player> PlayersData { get; set; }
		private IRepresentationRepo RepresentationRepo { get; set; }
		private List<PlayerVM> Players { get; set; } = new List<PlayerVM>();

		private int favoritePlayerCount;

		private Representation favoriteRepresentation;

		public PlayersForm( ChampionshipType championshipType )
		{
			InitializeComponent();
			ChampionshipType = championshipType;
		}

		private void StatisticsForm_Load( object sender, EventArgs e )
		{
			if ( File.Exists(Properties.Settings.Default.Representation_Filepath) )
			{
				try
				{
					string favoriteRepresentationJson = File.ReadAllText(Properties.Settings.Default.Representation_Filepath);

					RepresentationSaveFile saveFile = JsonConvert.DeserializeObject<RepresentationSaveFile>(favoriteRepresentationJson);

					if ( saveFile.ChampionshipType == this.ChampionshipType )
						favoriteRepresentation = saveFile.Representation;
				}
				catch ( Exception )
				{
					throw;
				}
			}
			
			GetTeamDataAsync(ChampionshipType);
		}

		private async void GetTeamDataAsync( ChampionshipType championshipType )
		{
			switch ( championshipType )
			{
				case ChampionshipType.Male:
					RepresentationRepo = new MaleRepresentation();
					break;
				case ChampionshipType.Female:
					RepresentationRepo = new FemaleRepresentation();
					break;
			}

			Cursor = Cursors.WaitCursor;
			RepresentationsData = (List<Representation>)await RepresentationRepo.GetAllTeams();
			Cursor = Cursors.Default;

			if (RepresentationsData == null)
			{
				MessageBox.Show("Unable to fetch player data");
			}
			else
			{
				RepresentationsData.Sort();
				FillRepresentationCombobox(); 
			}
		}

		private void FillRepresentationCombobox()
		{
			cbRepresentations.Items.Clear();

			foreach ( var representation in RepresentationsData )
				cbRepresentations.Items.Add(representation);

			if ( favoriteRepresentation != null )
				cbRepresentations.SelectedIndex = cbRepresentations.FindString(favoriteRepresentation.ToString());
		}

		private async void OnRepresentationSelected( object sender, EventArgs e )
		{
			flpPlayers.Controls.Clear();

			var cbox = sender as ComboBox;
			//favoriteRep instead of chosen
			favoriteRepresentation = cbox.SelectedItem as Representation;

			Utilities.SaveDataToFile(new RepresentationSaveFile(favoriteRepresentation, ChampionshipType), Properties.Settings.Default.Representation_Filepath);

			PlayersData = await RepresentationRepo.GetPlayers(favoriteRepresentation.FifaCode);
			PlayersData.Sort();

			FillFLPPlayers();
		}

		private void FillFLPPlayers()
		{
			flpPlayers.Controls.Clear();
			Players.Clear();

			if ( File.Exists(Properties.Settings.Default.Players_Filepath) )
			{
				try
				{
					var jsonPlayers = File.ReadAllText(Properties.Settings.Default.Players_Filepath);
					PlayersSaveFile players = JsonConvert.DeserializeObject<PlayersSaveFile>(jsonPlayers);

					if ( players != null && players.ChampionshipType == this.ChampionshipType && players.Representation.Equals(favoriteRepresentation) )
					{
						foreach ( var player in players.Players )
						{
							Players.Add(player);
							PlayerUC control = new PlayerUC(player);

							control.OnPlayerFavorited += OnPlayerFavorited;

							flpPlayers.Controls.Add(control);
						}

						Utilities.SavePlayersToFile(Players, ChampionshipType, favoriteRepresentation, Properties.Settings.Default.Players_Filepath);
					}
					else
					{
						foreach ( var player in PlayersData )
						{
							PlayerVM playerVM = new PlayerVM { Player = player };

							Players.Add(playerVM);

							var playerControl = new PlayerUC(playerVM);
							playerControl.OnPlayerFavorited += OnPlayerFavorited;
							flpPlayers.Controls.Add(playerControl);
						}

						Utilities.SavePlayersToFile(Players, ChampionshipType, favoriteRepresentation, Properties.Settings.Default.Players_Filepath);
					}
				}
				catch ( Exception )
				{
					throw;
				}
			}
			else
			{
				foreach ( var player in PlayersData )
				{
					PlayerVM playerVM = new PlayerVM { Player = player };

					Players.Add(playerVM);

					var playerControl = new PlayerUC(playerVM);
					playerControl.OnPlayerFavorited += OnPlayerFavorited;
					flpPlayers.Controls.Add(playerControl);
				}

				Utilities.SavePlayersToFile(Players, ChampionshipType, favoriteRepresentation, Properties.Settings.Default.Players_Filepath);
			}

			favoritePlayerCount = GetFavoritePlayerCount();
			lblPlayerCounter.Text = $"({favoritePlayerCount}/3)";
		}

		private void OnPlayerFavorited( object sender, PlayerFavoritedEventArgs args )
		{
			if ( favoritePlayerCount >= 3 )
			{
				if ( !args.Player.IsFavorite ) --favoritePlayerCount;

				args.Player.IsFavorite = false;
				( sender as PlayerUC ).ButtonImage = Properties.Resources.star_unfilled;
			}
			else if ( args.Player.IsFavorite )
				++favoritePlayerCount;
			else
				--favoritePlayerCount;

			lblPlayerCounter.Text = $"({favoritePlayerCount}/3)";

			Utilities.SavePlayersToFile(Players, ChampionshipType, favoriteRepresentation, Properties.Settings.Default.Players_Filepath);
		}

		private int GetFavoritePlayerCount()
		{
			int count = 0;

			foreach ( var player in Players )
				if ( player.IsFavorite )
					++count;

			return count;
		}

		private void OnFormClosed( object sender, FormClosedEventArgs e ) => Application.Exit();

		private void OnBtnSettings_Clicked( object sender, EventArgs e )
		{
			using ( var modal = new SettingsForm() )
			{
				var result = modal.ShowDialog();
				if (result == DialogResult.OK)
				{
					if ( modal.Settings.ChampionshipType != this.ChampionshipType )
					{
						flpPlayers.Controls.Clear();

						this.ChampionshipType = modal.Settings.ChampionshipType;
						GetTeamDataAsync(ChampionshipType);
					}

					Utilities.SetCultureForForm(modal.Settings.Language, this);
					Settings.SaveSettings(ChampionshipType, Properties.Settings.Default.Settings_Filepath);
				}
			}
		}

		private async void BtnStatistics_Click( object sender, EventArgs e )
		{
			List<Match> matches = await RepresentationRepo.GetMatchesForCountry(favoriteRepresentation);

			new StatisticsForm(matches, Players, favoriteRepresentation).Show();
		}
	}
}

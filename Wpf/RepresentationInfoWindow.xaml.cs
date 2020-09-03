using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Wpf
{
	/// <summary>
	/// Interaction logic for RepresentationInfoWindow.xaml
	/// </summary>
	public partial class RepresentationInfoWindow : Window
	{
		public RepresentationInfoWindow(List<Match> matches, Representation representation)
		{
			InitializeComponent();
			MakeStatisticAndApplyToLabels(matches, representation.Country, representation.FifaCode);
		}
		
		public RepresentationInfoWindow(List<Match> matches, Team team )
		{
			InitializeComponent();
			MakeStatisticAndApplyToLabels(matches, team.Country, team.Code);
		}

		private void MakeStatisticAndApplyToLabels( List<Match> matches, string country, string code )
		{
			lblRepresentationName.Content = $"{country} ({code})";
			lblGamesPlayed.Content = matches.Count();

			int gamesWon = 0;
			int gamesLost = 0;
			int gamesDrew = 0;

			int goalsScored = 0;
			int goalsReceived = 0;

			foreach ( var match in matches )
			{
				if ( match.WinnerCode == code )
					++gamesWon;
				else if ( match.Winner == "Draw" )
					++gamesDrew;
				else
					++gamesLost;

				if ( match.HomeTeam.Code == code )
				{
					goalsScored += (int)match.HomeTeam.Goals;
					goalsReceived += (int)match.AwayTeam.Goals;
				}
				else
				{
					goalsReceived += (int)match.HomeTeam.Goals;
					goalsScored += (int)match.AwayTeam.Goals;
				}
			}

			int goalDifferential = goalsScored - goalsReceived;

			lblGamesWon.Content = gamesWon;
			lblGamesLost.Content = gamesLost;
			lblGamesDrew.Content = gamesDrew;

			lblGoalsScored.Content = goalsScored;
			lblGoalsReceived.Content = goalsReceived;
			lblGoalDifference.Content = goalDifferential;
		}
	}
}

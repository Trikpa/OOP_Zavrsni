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
using Wpf.UserControls;

namespace Wpf
{
	/// <summary>
	/// Interaction logic for FormationWindow.xaml
	/// </summary>
	public partial class FormationWindow : Window
	{
		private List<Player> StartingElevenHome { get; set; }
		private List<Player> StartingElevenAway { get; set; }
		private Match Match { get; set; }

		private Color HomeTeamColor = Colors.CornflowerBlue;
		private Color AwayTeamColor = Colors.Firebrick;
		public FormationWindow(Match match, Representation favoriteRepresentation)
		{
			InitializeComponent();
			Match = match;

			GetStartingElevens(favoriteRepresentation);
			DrawPlayersOnField();
		}

		private void GetStartingElevens(Representation favoriteRep)
		{
			if ( Match.HomeTeam.Code == favoriteRep.FifaCode )
			{
				StartingElevenHome = Match.HomeTeamStatistics.StartingEleven;
				StartingElevenAway = Match.AwayTeamStatistics.StartingEleven;
			}
			else
			{
				StartingElevenAway = Match.HomeTeamStatistics.StartingEleven;
				StartingElevenHome = Match.AwayTeamStatistics.StartingEleven;
			}
		}
		private void DrawPlayersOnField()
		{
			foreach ( var player in StartingElevenHome )
			{
				switch ( player.Position )
				{
					case Position.Defender:
						spLeftTeamDefenders.Children.Add(new FieldPlayerUC(Match, player, HomeTeamColor));
						break;
					case Position.Forward:
						spLeftTeamForwards.Children.Add(new FieldPlayerUC(Match, player, HomeTeamColor));
						break;
					case Position.Goalie:
						spLeftTeamGoalie.Children.Add(new FieldPlayerUC(Match, player, HomeTeamColor));
						break;
					case Position.Midfield:
						spLeftTeamMidfielders.Children.Add(new FieldPlayerUC(Match, player, HomeTeamColor));
						break;
				}
			}
			
			foreach ( var player in StartingElevenAway )
			{
				switch ( player.Position )
				{
					case Position.Defender:
						spRightTeamDefenders.Children.Add(new FieldPlayerUC(Match, player, AwayTeamColor));
						break;
					case Position.Forward:
						spRightTeamForwards.Children.Add(new FieldPlayerUC(Match, player, AwayTeamColor));
						break;
					case Position.Goalie:
						spRightTeamGoalie.Children.Add(new FieldPlayerUC(Match, player, AwayTeamColor));
						break;
					case Position.Midfield:
						spRightTeamMidfielders.Children.Add(new FieldPlayerUC(Match, player, AwayTeamColor));
						break;
				}
			}
		}
	}
}

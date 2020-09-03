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
	/// Interaction logic for FieldPlayerInfoWindow.xaml
	/// </summary>
	public partial class FieldPlayerInfoWindow : Window
	{
		private Player Player { get; set; }
		private Match Match { get; set; }
		public FieldPlayerInfoWindow(Player player, Match match)
		{
			InitializeComponent();

			Player = player;
			Match = match;

			SetControls();
		}

		private void SetControls()
		{
			lblPlayerName.Content = Player.ToString();
			lblPlayerPosition.Content = Player.Position.ToString();
			imgPlayerIsCaptain.Source = Player.IsCaptain ? imgPlayerIsCaptain.FindResource("imgCheck") as ImageSource : imgPlayerIsCaptain.FindResource("imgCross") as ImageSource;

			int playerGoals = 0;
			int playerYellowCards = 0;

			foreach ( var player in Match.HomeTeamStatistics.StartingEleven )
			{
				if ( player == Player )
				{
					foreach ( var teamEvent in Match.HomeTeamEvents )
					{
						if (teamEvent.Player == player.Name)
						{
							if ( teamEvent.TypeOfEvent == TypeOfEvent.Goal )
								++playerGoals;
							else if ( teamEvent.TypeOfEvent == TypeOfEvent.YellowCard )
								++playerYellowCards;
						}
					}
				}
			}
			
			foreach ( var player in Match.AwayTeamStatistics.StartingEleven )
			{
				if ( player == Player )
				{
					foreach ( var teamEvent in Match.AwayTeamEvents )
					{
						if (teamEvent.Player == player.Name)
						{
							if ( teamEvent.TypeOfEvent == TypeOfEvent.Goal )
								++playerGoals;
							else if ( teamEvent.TypeOfEvent == TypeOfEvent.YellowCard )
								++playerYellowCards;
						}
					}
				}
			}

			lblPlayerGoalsScored.Content = playerGoals;
			lblPlayerYellowCards.Content = playerYellowCards;
		}
	}
}

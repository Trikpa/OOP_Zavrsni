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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DAL.Models;

namespace Wpf.UserControls
{
	/// <summary>
	/// Interaction logic for FieldPlayerUC.xaml
	/// </summary>
	public partial class FieldPlayerUC : UserControl
	{
		private Player Player { get; set; }
		private Match Match { get; set; }

		public FieldPlayerUC(Match match, Player player, Color color)
		{
			InitializeComponent();
			Match = match;
			Player = player;

			lblPlayerName.Content = Player.ToString();
			rectTeamColor.Fill = new SolidColorBrush(color);
		}

		private void UserControl_MouseLeftButtonUp( object sender, MouseButtonEventArgs e ) => new FieldPlayerInfoWindow(Player, Match).ShowDialog();
	}
}

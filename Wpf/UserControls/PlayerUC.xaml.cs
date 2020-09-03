using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
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
	/// Interaction logic for PlayerUC.xaml
	/// </summary>
	public partial class PlayerUC : UserControl
	{
		private PlayerVM Player { get; set; }
		public PlayerUC(PlayerVM player)
		{
			InitializeComponent();
			Player = player;

			SetComponents();
		}
		
		public PlayerUC(Player player)
		{
			InitializeComponent();
			Player = new PlayerVM { Player = player };

			SetComponents();
		}

		private void SetComponents()
		{
			if ( !string.IsNullOrEmpty(Player.PicturePath) )
			{
				try
				{
					imgPlayer.Source = new BitmapImage(new Uri(Player.PicturePath, UriKind.Relative));
				}
				catch ( Exception )
				{
				}
			}

			lblPlayerName.Content = Player.Player.Name;
			lblPlayerPosition.Content = Player.Player.Position.ToString();

			if ( Player.Player.IsCaptain )
				imgCaptain.Source = imgCaptain.FindResource("imgCheck") as ImageSource;
			else
				imgCaptain.Source = imgCaptain.FindResource("imgCross") as ImageSource;
		}
	}
}

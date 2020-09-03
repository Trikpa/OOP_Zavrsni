using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Models;
using DAL.Utilities.Events;
using System.IO;
using DAL.Utilities;
using Newtonsoft.Json;

namespace WinForms
{
	public partial class PlayerUC : UserControl
	{
		public event PlayerFavoritedEventHandler OnPlayerFavorited;

		public PlayerVM PlayerVM { get; set; }

		public Image ButtonImage
		{ 
			get => btnFavoritePlayer.Image;
			set => btnFavoritePlayer.Image = value; 
		}

		public PlayerUC( PlayerVM player )
		{
			InitializeComponent();

			PlayerVM = player;

			lblPlayerName.Text = player.Player.ToString();
			lblPlayerPosition.Text = player.Player.Position.ToString();
			lblTeamCaptain.Text = player.Player.IsCaptain ? Resources.Strings.yes.ToUpper() : Resources.Strings.no.ToUpper();

			if ( PlayerVM.IsFavorite )
				btnFavoritePlayer.Image = Properties.Resources.star_filled;

			try
			{
				if (  !string.IsNullOrEmpty(PlayerVM.PicturePath) )
					pbPlayerPicture.Image = Image.FromFile(PlayerVM.PicturePath);
			}
			catch ( Exception ex )
			{
				MessageBox.Show($"Unable to display picture for player {PlayerVM.Player.Name}. {ex.Message}");
			}
		}

		private void FavoriteButton_OnClick( object sender, EventArgs e )
		{
			PlayerVM.IsFavorite = !PlayerVM.IsFavorite;

			var button = sender as Button;

			if ( PlayerVM.IsFavorite )
				button.Image = Properties.Resources.star_filled;
			else
				button.Image = Properties.Resources.star_unfilled;

			OnPlayerFavorited?.Invoke(this, new PlayerFavoritedEventArgs { Player = PlayerVM });
		}

		private void PbPlayerPicture_Click( object sender, EventArgs e )
		{
			if(fileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					var filePath = fileDialog.FileName;

					string fileName = Path.GetFileName(filePath);

					string newFile = $"{Properties.Settings.Default.PlayerPictures_Filepath}{fileName}";

					if (!File.Exists(newFile))
						File.Copy(filePath, newFile);

					this.PlayerVM.PicturePath = newFile;

					pbPlayerPicture.Image = Image.FromFile(newFile);

					var jsonSaveFile = File.ReadAllText(Properties.Settings.Default.Players_Filepath);

					PlayersSaveFile saveFile = JsonConvert.DeserializeObject<PlayersSaveFile>(jsonSaveFile);

					Utilities.SavePlayerToFile(PlayerVM, saveFile, Properties.Settings.Default.Players_Filepath);
				}
				catch ( Exception ex )
				{
					MessageBox.Show($"Unable to open file. {ex.Message}");
				}
			}
		}
	}
}

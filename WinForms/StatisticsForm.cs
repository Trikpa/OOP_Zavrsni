using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Models;

namespace WinForms
{
	public partial class StatisticsForm : Form
	{
		private List<Match> Matches { get; set; }
		private List<PlayerVM> Players { get; set; }
		private List<PlayerStatisticVM> PlayerStatistics { get; set; }
		private Representation Representation { get; set; }
		public StatisticsForm(List<Match> matches, List<PlayerVM> players, Representation representation)
		{
			InitializeComponent();

			Matches = matches;
			Players = players;
			Representation = representation;
		}

		private void StatisticsForm_Load( object sender, EventArgs e )
		{
			FillPlayerStatistics();
			FillDataTablePlayers();
			FillDataTableMatches();
		}

		private void FillPlayerStatistics()
		{
			PlayerStatistics = new List<PlayerStatisticVM>();

			foreach ( var player in Players )
				PlayerStatistics.Add(new PlayerStatisticVM(player, Matches, Representation));
		}

		private void FillDataTablePlayers()
		{
			DataGridViewImageColumn playerImage = new DataGridViewImageColumn
			{
				AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
				ImageLayout = DataGridViewImageCellLayout.Zoom,
				DataPropertyName = "playerImage",
				Visible = true,
				Name = "playerImage",
				HeaderText = Resources.Strings.image
			};

			dataTablePlayers.Columns.Add(playerImage);
			dataTablePlayers.Columns.Add("playerName", Resources.Strings.name);
			dataTablePlayers.Columns.Add("playerYellowCards", Resources.Strings.yellowCards);
			dataTablePlayers.Columns.Add("playerScoredGoals", Resources.Strings.scoredGoals);

			foreach ( var player in PlayerStatistics )
			{
				if ( File.Exists(player.Player.PicturePath) )
					dataTablePlayers.Rows.Add(Image.FromFile(player.Player.PicturePath), player.Player.ToString(), player.NumOfYellowCards, player.NumOfScoredGoals);
				else
					dataTablePlayers.Rows.Add(Properties.Resources.default_profile_picture_100px, player.Player.ToString(), player.NumOfYellowCards, player.NumOfScoredGoals);
			}
		}

		private void FillDataTableMatches()
		{
			dataTableMatches.Columns.Add("matchLocation", Resources.Strings.location);
			dataTableMatches.Columns.Add("matchAttendance", Resources.Strings.attendance);
			dataTableMatches.Columns.Add("matchHomeTeam", Resources.Strings.homeTeam);
			dataTableMatches.Columns.Add("matchAwayTeam", Resources.Strings.awayTeam);

			foreach ( var match in Matches )
				dataTableMatches.Rows.Add(match.Location, match.Attendance, match.HomeTeam.Country, match.AwayTeam.Country);
		}

		private void BtnPrint_Click( object sender, EventArgs e ) => printPreviewDialog.ShowDialog();

		private void PrintStatistics_PrintPage( object sender, System.Drawing.Printing.PrintPageEventArgs e )
		{
			Bitmap bitmapMatches = new Bitmap(dataTableMatches.Width, dataTableMatches.Height);
			dataTableMatches.DrawToBitmap(bitmapMatches, new Rectangle(0, 0, dataTableMatches.Width, dataTableMatches.Height));
			e.Graphics.DrawImage(bitmapMatches, 0, 0);

			Bitmap bitmapPlayers = new Bitmap(dataTablePlayers.Width, dataTablePlayers.Height);
			dataTablePlayers.DrawToBitmap(bitmapPlayers, new Rectangle(0, 0, dataTablePlayers.Width, dataTablePlayers.Height));
			e.Graphics.DrawImage(bitmapPlayers, 0, 250);
		}
	}
}

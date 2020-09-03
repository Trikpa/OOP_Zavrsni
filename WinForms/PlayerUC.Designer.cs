namespace WinForms
{
	partial class PlayerUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerUC));
			this.lblPlayerName = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblTeamCaptain = new System.Windows.Forms.Label();
			this.lblPlayerPosition = new System.Windows.Forms.Label();
			this.btnFavoritePlayer = new System.Windows.Forms.Button();
			this.pbPlayerPicture = new System.Windows.Forms.PictureBox();
			this.fileDialog = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.pbPlayerPicture)).BeginInit();
			this.SuspendLayout();
			// 
			// lblPlayerName
			// 
			resources.ApplyResources(this.lblPlayerName, "lblPlayerName");
			this.lblPlayerName.Name = "lblPlayerName";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// lblTeamCaptain
			// 
			resources.ApplyResources(this.lblTeamCaptain, "lblTeamCaptain");
			this.lblTeamCaptain.Name = "lblTeamCaptain";
			// 
			// lblPlayerPosition
			// 
			resources.ApplyResources(this.lblPlayerPosition, "lblPlayerPosition");
			this.lblPlayerPosition.Name = "lblPlayerPosition";
			// 
			// btnFavoritePlayer
			// 
			this.btnFavoritePlayer.FlatAppearance.BorderSize = 0;
			resources.ApplyResources(this.btnFavoritePlayer, "btnFavoritePlayer");
			this.btnFavoritePlayer.Image = global::WinForms.Properties.Resources.star_unfilled;
			this.btnFavoritePlayer.Name = "btnFavoritePlayer";
			this.btnFavoritePlayer.UseVisualStyleBackColor = false;
			this.btnFavoritePlayer.Click += new System.EventHandler(this.FavoriteButton_OnClick);
			// 
			// pbPlayerPicture
			// 
			resources.ApplyResources(this.pbPlayerPicture, "pbPlayerPicture");
			this.pbPlayerPicture.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pbPlayerPicture.Image = global::WinForms.Properties.Resources.default_profile_picture_100px;
			this.pbPlayerPicture.Name = "pbPlayerPicture";
			this.pbPlayerPicture.TabStop = false;
			this.pbPlayerPicture.Click += new System.EventHandler(this.PbPlayerPicture_Click);
			// 
			// fileDialog
			// 
			this.fileDialog.FileName = "Select an image";
			resources.ApplyResources(this.fileDialog, "fileDialog");
			// 
			// PlayerUC
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.btnFavoritePlayer);
			this.Controls.Add(this.lblTeamCaptain);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblPlayerPosition);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblPlayerName);
			this.Controls.Add(this.pbPlayerPicture);
			this.Name = "PlayerUC";
			((System.ComponentModel.ISupportInitialize)(this.pbPlayerPicture)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pbPlayerPicture;
		private System.Windows.Forms.Label lblPlayerName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblTeamCaptain;
		private System.Windows.Forms.Label lblPlayerPosition;
		private System.Windows.Forms.Button btnFavoritePlayer;
		private System.Windows.Forms.OpenFileDialog fileDialog;
	}
}

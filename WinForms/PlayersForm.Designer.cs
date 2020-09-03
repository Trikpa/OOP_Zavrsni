namespace WinForms
{
	partial class PlayersForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayersForm));
			this.cbRepresentations = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lbl3FavoritePlayers = new System.Windows.Forms.Label();
			this.lblPlayerCounter = new System.Windows.Forms.Label();
			this.btnSettings = new System.Windows.Forms.Button();
			this.flpPlayers = new System.Windows.Forms.FlowLayoutPanel();
			this.btnStatistics = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cbRepresentations
			// 
			this.cbRepresentations.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbRepresentations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRepresentations.FormattingEnabled = true;
			resources.ApplyResources(this.cbRepresentations, "cbRepresentations");
			this.cbRepresentations.Name = "cbRepresentations";
			this.cbRepresentations.SelectedIndexChanged += new System.EventHandler(this.OnRepresentationSelected);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// lbl3FavoritePlayers
			// 
			resources.ApplyResources(this.lbl3FavoritePlayers, "lbl3FavoritePlayers");
			this.lbl3FavoritePlayers.Name = "lbl3FavoritePlayers";
			// 
			// lblPlayerCounter
			// 
			resources.ApplyResources(this.lblPlayerCounter, "lblPlayerCounter");
			this.lblPlayerCounter.Name = "lblPlayerCounter";
			// 
			// btnSettings
			// 
			resources.ApplyResources(this.btnSettings, "btnSettings");
			this.btnSettings.Image = global::WinForms.Properties.Resources.settings_icon_24px;
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.UseVisualStyleBackColor = true;
			this.btnSettings.Click += new System.EventHandler(this.OnBtnSettings_Clicked);
			// 
			// flpPlayers
			// 
			resources.ApplyResources(this.flpPlayers, "flpPlayers");
			this.flpPlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpPlayers.Name = "flpPlayers";
			// 
			// btnStatistics
			// 
			resources.ApplyResources(this.btnStatistics, "btnStatistics");
			this.btnStatistics.Name = "btnStatistics";
			this.btnStatistics.UseVisualStyleBackColor = true;
			this.btnStatistics.Click += new System.EventHandler(this.BtnStatistics_Click);
			// 
			// PlayersForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnStatistics);
			this.Controls.Add(this.flpPlayers);
			this.Controls.Add(this.btnSettings);
			this.Controls.Add(this.lblPlayerCounter);
			this.Controls.Add(this.lbl3FavoritePlayers);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbRepresentations);
			this.Name = "PlayersForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
			this.Load += new System.EventHandler(this.StatisticsForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbRepresentations;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbl3FavoritePlayers;
		private System.Windows.Forms.Button btnSettings;
		private System.Windows.Forms.Label lblPlayerCounter;
		private System.Windows.Forms.FlowLayoutPanel flpPlayers;
		private System.Windows.Forms.Button btnStatistics;
	}
}
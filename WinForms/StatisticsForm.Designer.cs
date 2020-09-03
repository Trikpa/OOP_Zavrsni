namespace WinForms
{
	partial class StatisticsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsForm));
			this.label1 = new System.Windows.Forms.Label();
			this.dataTableMatches = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.dataTablePlayers = new System.Windows.Forms.DataGridView();
			this.printStatistics = new System.Drawing.Printing.PrintDocument();
			this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
			this.btnPrint = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataTableMatches)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTablePlayers)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// dataTableMatches
			// 
			resources.ApplyResources(this.dataTableMatches, "dataTableMatches");
			this.dataTableMatches.AllowUserToAddRows = false;
			this.dataTableMatches.AllowUserToDeleteRows = false;
			this.dataTableMatches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataTableMatches.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataTableMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataTableMatches.Name = "dataTableMatches";
			this.dataTableMatches.ReadOnly = true;
			this.dataTableMatches.RowTemplate.Height = 28;
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// dataTablePlayers
			// 
			resources.ApplyResources(this.dataTablePlayers, "dataTablePlayers");
			this.dataTablePlayers.AllowUserToAddRows = false;
			this.dataTablePlayers.AllowUserToDeleteRows = false;
			this.dataTablePlayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataTablePlayers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataTablePlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataTablePlayers.Name = "dataTablePlayers";
			this.dataTablePlayers.ReadOnly = true;
			this.dataTablePlayers.RowTemplate.Height = 28;
			// 
			// printStatistics
			// 
			this.printStatistics.DocumentName = "statistic";
			this.printStatistics.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintStatistics_PrintPage);
			// 
			// printPreviewDialog
			// 
			resources.ApplyResources(this.printPreviewDialog, "printPreviewDialog");
			this.printPreviewDialog.Document = this.printStatistics;
			this.printPreviewDialog.Name = "printPreviewDialog";
			this.printPreviewDialog.UseAntiAlias = true;
			// 
			// btnPrint
			// 
			resources.ApplyResources(this.btnPrint, "btnPrint");
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Tag = "players";
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
			// 
			// StatisticsForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnPrint);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataTableMatches);
			this.Controls.Add(this.dataTablePlayers);
			this.Name = "StatisticsForm";
			this.Load += new System.EventHandler(this.StatisticsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataTableMatches)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTablePlayers)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dataTableMatches;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dataTablePlayers;
		private System.Drawing.Printing.PrintDocument printStatistics;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
		private System.Windows.Forms.Button btnPrint;
	}
}
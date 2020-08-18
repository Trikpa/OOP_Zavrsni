namespace WinForms
{
	partial class StartingWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartingWindow));
			this.cbLanguage = new System.Windows.Forms.ComboBox();
			this.lblLanguage = new System.Windows.Forms.Label();
			this.lblInstruction = new System.Windows.Forms.Label();
			this.btnMale = new System.Windows.Forms.Button();
			this.btnFemale = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cbLanguage
			// 
			this.cbLanguage.FormattingEnabled = true;
			resources.ApplyResources(this.cbLanguage, "cbLanguage");
			this.cbLanguage.Name = "cbLanguage";
			this.cbLanguage.SelectedIndexChanged += new System.EventHandler(this.CbLanguage_SelectedIndexChanged);
			// 
			// lblLanguage
			// 
			resources.ApplyResources(this.lblLanguage, "lblLanguage");
			this.lblLanguage.Name = "lblLanguage";
			// 
			// lblInstruction
			// 
			resources.ApplyResources(this.lblInstruction, "lblInstruction");
			this.lblInstruction.Name = "lblInstruction";
			// 
			// btnMale
			// 
			resources.ApplyResources(this.btnMale, "btnMale");
			this.btnMale.Name = "btnMale";
			this.btnMale.Tag = "male";
			this.btnMale.UseVisualStyleBackColor = true;
			this.btnMale.Click += new System.EventHandler(this.GenderSelected);
			// 
			// btnFemale
			// 
			resources.ApplyResources(this.btnFemale, "btnFemale");
			this.btnFemale.Name = "btnFemale";
			this.btnFemale.Tag = "female";
			this.btnFemale.UseVisualStyleBackColor = true;
			this.btnFemale.Click += new System.EventHandler(this.GenderSelected);
			// 
			// StartingWindow
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnFemale);
			this.Controls.Add(this.btnMale);
			this.Controls.Add(this.lblInstruction);
			this.Controls.Add(this.lblLanguage);
			this.Controls.Add(this.cbLanguage);
			this.Name = "StartingWindow";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbLanguage;
		private System.Windows.Forms.Label lblLanguage;
		private System.Windows.Forms.Label lblInstruction;
		private System.Windows.Forms.Button btnMale;
		private System.Windows.Forms.Button btnFemale;
	}
}
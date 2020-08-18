using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
	public partial class StatisticsForm : Form
	{
		public StatisticsForm( string championshipType )
		{
			InitializeComponent();
			label1.Text = championshipType;
		}

		private void OnFormClosed( object sender, FormClosedEventArgs e ) => Application.Exit();
	}
}

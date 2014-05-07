using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mucss_test
{
	public partial class Form1 : Form
	{
	mucss.Parser parser;
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			parser = new mucss.Parser(txtCSS.Text);
		}
	}
}

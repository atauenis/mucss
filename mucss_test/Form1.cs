using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mucss;

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
			DateTime dt1 = DateTime.Now;
			this.UseWaitCursor = true;
			parser = new mucss.Parser(txtCSS.Text);
			List<mucss.Selector> sels = parser.GetAllStyles();
			DateTime dt2 = DateTime.Now;
			this.UseWaitCursor = false;
			
			txtResult.Text = string.Format("Parsed {0} selectors for {1} msec.\r\n",sels.Count(),(dt2-dt1).TotalMilliseconds);
			string Buffer = "";
			foreach (Selector s in sels)
			{
				Buffer+=s.Pattern + ":";
				foreach (Declaration d in s.Declarations)
				{
					Buffer += "\r\n\t" + d.Property + "=" + d.Value;
				}
				Buffer+="\r\n";
			}
			txtResult.Text+=Buffer;
		}
	}
}

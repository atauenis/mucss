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
	mucss.Stylesheet parser;
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.UseWaitCursor = true;
			DateTime dt1 = DateTime.Now;
			parser = new mucss.Stylesheet(txtCSS.Text);
			Dictionary<string, Selector> sels = parser.GetAllSelectors();
			DateTime dt2 = DateTime.Now;
			this.UseWaitCursor = false;
			
			#if !DEBUG
			txtResult.Text = string.Format("Parsed {0} selectors for {1} msec.\r\n",sels.Count(),(dt2-dt1).TotalMilliseconds);
			#else
			txtResult.Text = string.Format("Parsed {0} selectors for {1} msec (debug mode).\r\n",sels.Count(),(dt2-dt1).TotalMilliseconds);
			#endif
			string Buffer = "";
			foreach (Selector s in sels.Values)
			{
				Buffer+=s.Pattern + ":";
				foreach (Declaration d in s.Declarations.Values)
				{
					Buffer += "\r\n\t" + d.Property + "=" + d.Value;
				}
				Buffer+="\r\n";
			}

			#if DEBUG
			Buffer+= "\r\n\r\nDebug log:";
			Buffer+=parser.log;
			#endif

			txtResult.Text+=Buffer;
		}
	}
}

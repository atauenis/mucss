using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace mucss
{
	/// <summary>μCSS</summary>
    public class Parser
    {
		private string css;
		private List<Selector> selectors = new List<Selector>();

		/// <summary>Initialize the μCSS and load the <paramref name="CSS"/> into it.</summary>
		/// <param name="CSS">The cascade style sheets to be loaded</param>
		public Parser(string CSS)
		{
			List<string> sels = new List<string>();

			css = CSS;

			MatchCollection mc = new Regex(@"[\w\d:.#, ]*[\w]*\{[\w\r\n-: #;]*\}", RegexOptions.Singleline).Matches(css);
			foreach (Match m in mc)
			{
				Selector sel = new Selector() { Declarations = new List<Declaration>() };

				//finding selectors
				string selbody = Regex.Replace(m.Value,@"\/\*[\w\d \r\n\t]*\*\/",""); //remove comments
				//todo: улучшить маску вырезания комментариев
				sels.Add(selbody);//убрать

				sel.Pattern = Regex.Match(selbody,@"[\w\d:.#, ]*[\w]*{").Value.Replace("{","");
				sel.InnerCSS = selbody;

				selbody = Regex.Replace(selbody, @"[\w\d:.#, ]*[\w]*{", "").Replace("}", ""); //remove selector

				//split declarations
				string[] decs = selbody.Split(';');
				
				//removing line breaks
				for (int i = 0; i < decs.Length; i++)
				{
					decs[i] = decs[i].Replace("\n","").Replace("\r","");
				}

				//ennoble the internal arrays to a civilized struct
				List<Declaration> declars = new List<Declaration>();
				foreach (string declar in decs)
				{
					string[] parts = declar.Split(':');
					if(parts.Length < 2) continue;

					Declaration dec = new Declaration();
					dec.Property = parts[0];
					dec.Value = parts[1];
					dec.InnerCSS  = declar;

					sel.Declarations.Add(dec);
				}
				selectors.Add(sel);
			}
		}

		public Selector Get(string Query){
			foreach (Selector s in selectors)
			{
				if(Regex.IsMatch(s.Pattern,Query))
				return s;
			}

			throw new ArgumentOutOfRangeException("No style was found for " + Query);
		}
    }



	/// <summary>CSS selector (i.e. a:hover{})</summary>
	public struct Selector
	{
		/// <summary>The pattern of this selector (i.e. a:hover)</summary>
		public string Pattern;
		/// <summary>The stuff of this selector</summary>
		public List<Declaration> Declarations;
		/// <summary>The full content of the selector</summary>
		public string InnerCSS;
	}

	/// <summary>CSS declarations (i.e. color: #ABCDEF)</summary>
	public struct Declaration
	{
		/// <summary>The declaration's property name</summary>
		public string Property;
		/// <summary>The declaration's property value</summary>
		public string Value;
		/// <summary>The full content of the declaration</summary>
		public string InnerCSS;
	}
}

using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace nand2tetris_asm
{
	public class TableBase
	{
		protected Dictionary<string, string> data;

		protected static Regex normalizer = new Regex(@"\s", RegexOptions.Compiled);

		public string this[string op]
		{
			get
			{
				var normalized = normalizer.Replace(op, "");
				return data[normalized];
			}
		}
	}
}

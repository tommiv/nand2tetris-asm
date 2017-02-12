using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace nand2tetris_asm
{
	public class Preprocessor
	{
		private static readonly Regex Comment = new Regex("\\s*//(.*)", RegexOptions.Compiled);

		public static List<string> Do(string[] input)
		{
			return input
				.Select(x => Comment.Replace(x, ""))
				.Select(x => x.Trim())
				.Where(x => !String.IsNullOrWhiteSpace(x))
				.ToList();
		}
	}
}

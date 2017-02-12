using System.Collections.Generic;

namespace nand2tetris_asm
{
	public class SymbolsProcessor
	{
		public SymbolsTable Table;
		public List<string> ProcessedLines;

		public void Do(List<string> input)
		{
			var table = new SymbolsTable();
			var lines = new List<string>();

			for (int i = 0; i < input.Count; i++)
			{
				var line = input[i];

				if (line.StartsWith("("))
				{
					var label = line.Trim(new char[] { '(', ')' });
					table.AddSymbol(label, (uint)lines.Count);
				}
				else
				{
					lines.Add(line);
				}
			}

			this.Table = table;
			this.ProcessedLines = lines;
		}
	}
}

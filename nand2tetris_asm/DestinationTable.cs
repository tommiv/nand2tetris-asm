using System.Collections.Generic;

namespace nand2tetris_asm
{
	public class DestinationTable : TableBase
	{
		public DestinationTable()
		{ 
			this.data = new Dictionary<string, string>
			{
				{"null", "000"},
				{"M",    "001"},
				{"D",    "010"},
				{"MD",   "011"},
				{"A",    "100"},
				{"AM",   "101"},
				{"AD",   "110"},
				{"AMD",  "111"},
			};
		}
	}
}

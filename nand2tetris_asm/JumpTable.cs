using System.Collections.Generic;

namespace nand2tetris_asm
{
	public class JumpTable : TableBase
	{
		public JumpTable()
		{
			this.data = new Dictionary<string, string>
			{
				{"null", "000"},
				{"JGT",  "001"},
				{"JEQ",  "010"},
				{"JGE",  "011"},
				{"JLT",  "100"},
				{"JNE",  "101"},
				{"JLE",  "110"},
				{"JMP",  "111"},
			};
		}
	}
}

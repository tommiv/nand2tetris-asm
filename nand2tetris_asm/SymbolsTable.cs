using System;
using System.Collections.Generic;

namespace nand2tetris_asm
{
	public class SymbolsTable
	{
		private const int REGISTERS_COUNT = 16;

		private Dictionary<string, uint> data;

		private uint variablesPointer = 0x0010;

		public SymbolsTable()
		{
			data = new Dictionary<string, uint>
			{
				{"SP",     0x0000},
				{"LCL",    0x0001},
				{"ARG",    0x0002},
				{"THIS",   0x0003},
				{"THAT",   0x0004},
				{"SCREEN", 0x4000},
				{"KBD",    0x6000},
			};

			for (uint i = 0; i < REGISTERS_COUNT; i++)
			{
				data.Add("R" + i, 0x0000 + i);
			}
		}

		public void AddSymbol(string symbol, uint addr)
		{
			this.data.Add(symbol, addr);
		}

		public void AddVariable(string symbol)
		{
			if (data.ContainsKey(symbol))
			{
				throw new Exception("Duplicate symbol " + symbol);
			}

			this.data.Add(symbol, this.variablesPointer);

			this.variablesPointer++;
		}

		public uint this[string symbol]
		{
			get
			{
				return data[symbol];
			}
		}

		public bool HasSymbol(string symbol)
		{
			return data.ContainsKey(symbol);
		}
	}
}

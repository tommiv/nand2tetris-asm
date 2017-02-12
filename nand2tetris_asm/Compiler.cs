using System;
using System.Collections.Generic;
using System.Linq;

namespace nand2tetris_asm
{
	public class Compiler
	{
		private const int WORD_SIZE = 16;

		ComputationTable compTable = new ComputationTable();
		DestinationTable destTable = new DestinationTable();
		JumpTable        jumpTable = new JumpTable();

		private string TranslateAddressToken(Token token)
		{
			uint address = Convert.ToUInt16(token.Content);
			string addrBinValue = Convert.ToString(address, 2);
			return addrBinValue.PadLeft(WORD_SIZE, '0');
		}

		private string TranslateComputationToken(Token dest, Token comp, Token jump)
		{
			var preambleBin = "111";
			var compBin = compTable[comp.Content];
			var destBin = destTable[dest.Content];
			var jumpBin = jumpTable[jump.Content];

			return preambleBin + compBin + destBin + jumpBin;
		}

		private string CompileLine(List<Token> tokens)
		{
			if (tokens[0].Type == TokenType.AddressInstruction)
			{
				return TranslateAddressToken(tokens[0]);
			}
			else
			{
				return TranslateComputationToken(tokens[0], tokens[1], tokens[2]);
			}
		}

		public List<string> Do(List<List<Token>> input)
		{
			return input.Select(CompileLine).ToList();
		}
	}
}

using System.Collections.Generic;

namespace nand2tetris_asm
{
	// DISCLAIMER: I had to write a fair top-down parser probably.
	// But it's too light lexic to set up a state machine.
	// It also the part of contract that there is NO invalid asm input
	// I'm ok with this, I don't even have a Invalid token type in enum

	public class Tokenizer
	{
		private static List<TokenType> CInstruction = new List<TokenType>
		{
			TokenType.DestPart,
			TokenType.CompPart,
			TokenType.JumpPart
		};

		public static List<Token> Tokenize(string input)
		{
			var tokens = new List<Token>();

			// a-instruction
			if (input.StartsWith("@"))
			{
				var token = new Token(TokenType.AddressInstruction, input.Substring(1));
				tokens.Add(token);
			}
			// labels here?
			// c-instruction
			else
			{
				var destPartPieces = input.Split('=');
				string rest;
				if (destPartPieces.Length == 2)
				{
					var dest = new Token(TokenType.DestPart, destPartPieces[0]);
					tokens.Add(dest);
					rest = destPartPieces[1];
				}
				else
				{
					var nullDest = new Token(TokenType.DestPart, "null");
					tokens.Add(nullDest);
					rest = destPartPieces[0];
				}

				var otherPartPieces = rest.Split(';');

				var comp = new Token(TokenType.CompPart, otherPartPieces[0]);
				tokens.Add(comp);

				if (otherPartPieces.Length == 2)
				{
					var jump = new Token(TokenType.JumpPart, otherPartPieces[1]);
					tokens.Add(jump);
				}
				else
				{
					var nullJump = new Token(TokenType.JumpPart, "null");
					tokens.Add(nullJump);
				}
			}

			return tokens;
		}
	}
}

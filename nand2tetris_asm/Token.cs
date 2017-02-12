namespace nand2tetris_asm
{
	public class Token
	{
		public TokenType Type    { get; set; }
		public string    Content { get; set; }

		public Token(TokenType type, string content)
		{
			this.Type = type;
			this.Content = content;
		}
	}
}

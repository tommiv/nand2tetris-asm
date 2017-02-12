using System;
using System.IO;
using System.Linq;

namespace nand2tetris_asm
{
	class MainClass
	{
		private static string buildOutputPath(string inputPath)
		{
			var dir = Path.GetDirectoryName(inputPath);
			var filename = Path.GetFileNameWithoutExtension(inputPath) + ".hack";
			return Path.Combine(dir, filename);
		}

		public static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				throw new ArgumentException("No input file provided");
			}

			var sourceCode = File.ReadAllLines(args[0]);
			var processedCode = Preprocessor.Do(sourceCode);

			var symProc = new SymbolsProcessor();
			symProc.Do(processedCode);

			var unsymbolizedCode = symProc.ProcessedLines;
			var symbols = symProc.Table;

			var instructionSet = unsymbolizedCode.Select(Tokenizer.Tokenize).ToList();

			var compiledAscii = new Compiler(symbols).Do(instructionSet);
			File.WriteAllLines(buildOutputPath(args[0]), compiledAscii);
		}
	}
}

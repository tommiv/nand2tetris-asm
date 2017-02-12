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
			var instructionSet = processedCode.Select(Tokenizer.Tokenize).ToList();
			var compiledAscii = new Compiler().Do(instructionSet);
			File.WriteAllLines(buildOutputPath(args[0]), compiledAscii);
		}
	}
}

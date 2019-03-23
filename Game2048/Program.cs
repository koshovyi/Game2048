using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Game2048.Tests")]

namespace Game2048
{
	class Program
	{

		static void Main(string[] args)
		{
			Board board = new Board();
			board[0, 1] = 2;

			Console.WriteLine("Hello World!");
			Console.Read();
		}

	}
}

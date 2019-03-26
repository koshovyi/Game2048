using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Game2048.Tests")]

namespace Game2048
{
	class Program
	{

		static void Main(string[] args)
		{
			Board gameBoard = new Board();

			gameBoard.SetHorizontalSlice(0, 2, 0, 2, 4);
			gameBoard.SetHorizontalSlice(1, 8, 8, 2, 2);
			gameBoard.SetHorizontalSlice(2, 2, 0, 0, 2);
			gameBoard.SetHorizontalSlice(3, 8, 4, 4, 16);

			gameBoard.MoveRight();

			Console.WriteLine("Hello World!");
			Console.Read();
		}

	}
}

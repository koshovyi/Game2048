using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Game2048.Tests")]

namespace Game2048
{
	class Program
	{

		const int CELL_HEIGHT = 3;
		const int CELL_WIDTH = 6;
		const int BORDER_PADDING_TOP = 1;
		const int BORDER_PADDING_LEFT = 2;
		const int MAX_CELL_VALUE_LENGTH = 4;

		static Board _board;

		private static bool _gameIsOver;

		static void Main(string[] args)
		{
			Console.Title = "2048 Console version";
			Console.CursorVisible = false;
			Console.WindowHeight = 15;
			Console.WindowWidth = 70;

			_gameIsOver = false;
			_board = new Board();
			_board.GameOver += _board_GameOver;

			DrawBoard();
			DrawTitle();
			DrawAbout();
			DrawScore();

			ConsoleKeyInfo key;
			do
			{
				key = Console.ReadKey();

				switch (key.Key)
				{
					case ConsoleKey.LeftArrow:
						_board.MoveLeft(true);
						break;
					case ConsoleKey.RightArrow:
						_board.MoveRight(true);
						break;
					case ConsoleKey.UpArrow:
						_board.MoveUp(true);
						break;
					case ConsoleKey.DownArrow:
						_board.MoveDown(true);
						break;
				}
				DrawBoard();
				DrawScore();
			}
			while (key.Key != ConsoleKey.Escape && !_gameIsOver);

			if (_gameIsOver)
				DrawGameOver();
			else
			{
				Console.Clear();
				Console.WriteLine("Good bye :)");
			}
			Console.Read();
		}

		private static void _board_GameOver(object sender, EventArgs e)
		{
			_gameIsOver = true;
		}

		static void SetCursorPosition(uint x, uint y)
		{
			Console.CursorLeft = (int)x + BORDER_PADDING_LEFT;
			Console.CursorTop = (int)y + BORDER_PADDING_TOP;
		}

		static void DrawBoard()
		{
			for (uint x = 0; x < Board.GAME_SIZE; x++)
				for (uint y = 0; y < Board.GAME_SIZE; y++)
					DrawCell(x, y);
		}

		static void DrawCell(uint x, uint y)
		{
			if (_board[x, y] > 0)
				DrawCellWithValue(x, y);
			else
				DrawCellWithoutValue(x, y);
		}

		static void DrawCellWithValue(uint x, uint y)
		{
			SetCursorPosition(x * CELL_WIDTH, y * CELL_HEIGHT);
			DrawCharsLine(ASCII.BORDER2_CORNER_LEFT_UP,
				ASCII.BORDER2_HORIZONTAL_LINE,
				ASCII.BORDER2_HORIZONTAL_LINE,
				ASCII.BORDER2_HORIZONTAL_LINE,
				ASCII.BORDER2_HORIZONTAL_LINE,
				ASCII.BORDER2_CORNER_RIGHT_UP
			);
			Console.WriteLine();

			SetCursorPosition(x * CELL_WIDTH, y * CELL_HEIGHT + 1);
			DrawCharsLine(ASCII.BORDER2_VERTICAL_LINE);
			DrawCellValue(_board[x, y]);
			DrawCharsLine(ASCII.BORDER2_VERTICAL_LINE);
			Console.WriteLine();

			SetCursorPosition(x * CELL_WIDTH, y * CELL_HEIGHT + 2);
			DrawCharsLine(ASCII.BORDER2_CORNER_LEFT_DOWN,
				ASCII.BORDER2_HORIZONTAL_LINE,
				ASCII.BORDER2_HORIZONTAL_LINE,
				ASCII.BORDER2_HORIZONTAL_LINE,
				ASCII.BORDER2_HORIZONTAL_LINE,
				ASCII.BORDER2_CORNER_RIGHT_DOWN
			);
			Console.WriteLine();
		}

		static void DrawCellValue(uint value)
		{
			string v = value.ToString();
			if (v.Length < MAX_CELL_VALUE_LENGTH)
			{
				Console.ForegroundColor = ConsoleColor.Gray;
				for (int i = 0; i < MAX_CELL_VALUE_LENGTH - v.Length; i++)
					Console.Write('0');
			}
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write(v);
			Console.ResetColor();
		}

		static void DrawCellWithoutValue(uint x, uint y)
		{
			SetCursorPosition(x * CELL_WIDTH, y * CELL_HEIGHT);
			DrawCharsLine(ASCII.BORDER_CORNER_LEFT_UP,
				ASCII.BORDER_HORIZONTAL_LINE,
				ASCII.BORDER_HORIZONTAL_LINE,
				ASCII.BORDER_HORIZONTAL_LINE,
				ASCII.BORDER_HORIZONTAL_LINE,
				ASCII.BORDER_CORNER_RIGHT_UP
			);
			Console.WriteLine();

			SetCursorPosition(x * CELL_WIDTH, y * CELL_HEIGHT + 1);
			DrawCharsLine(ASCII.BORDER_VERTICAL_LINE);
			Console.Write("    ");
			DrawCharsLine(ASCII.BORDER_VERTICAL_LINE);
			Console.WriteLine();

			SetCursorPosition(x * CELL_WIDTH, y * CELL_HEIGHT + 2);
			DrawCharsLine(ASCII.BORDER_CORNER_LEFT_DOWN,
				ASCII.BORDER_HORIZONTAL_LINE,
				ASCII.BORDER_HORIZONTAL_LINE,
				ASCII.BORDER_HORIZONTAL_LINE,
				ASCII.BORDER_HORIZONTAL_LINE,
				ASCII.BORDER_CORNER_RIGHT_DOWN
			);
			Console.WriteLine();
		}

		static void DrawCharsLine(params ASCII[] chars)
		{
			Console.ForegroundColor = ConsoleColor.DarkMagenta;
			foreach (ASCII ascii in chars)
				Console.Write((char)ascii);
			Console.ResetColor();
		}

		static void DrawTitle()
		{
			string[] logos = new string[]
			{
				" _______  _______  _   ___   _____  ",
				"|       ||  _    || | |   | |  _  | ",
				"|____   || | |   || |_|   | | |_| | ",
				" ____|  || | |   ||       ||   _   |",
				"| ______|| |_|   ||___    ||  | |  |",
				"| |_____ |       |    |   ||  |_|  |",
				"|_______||_______|    |___||_______|"
			};
			Console.ForegroundColor = ConsoleColor.Green;
			SetCursorPosition(26, 0);
			foreach (string logo in logos)
			{
				Console.Write(logo);
				SetCursorPosition(26, (uint)Console.CursorTop);
			}
			Console.ResetColor();
		}

		static void DrawAbout()
		{
			Console.CursorTop = 9;
			Console.CursorLeft = 28;
			Console.WriteLine("Author:\tKoshovyi Dmytro");
			Console.CursorTop = 10;
			Console.CursorLeft = 28;
			Console.WriteLine("Site:\twww.koshovyi.com");
		}

		static void DrawScore()
		{
			Console.CursorTop = 11;
			Console.CursorLeft = 28;
			Console.WriteLine("Score:\t" + _board.Score.ToString());
		}

		static void DrawGameOver()
		{
			Console.CursorTop = 12;
			Console.CursorLeft = 28;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Oops!... Game Over :(");
		}

	}
}

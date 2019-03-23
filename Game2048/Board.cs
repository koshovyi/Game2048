using System;
using System.Collections.Generic;
using System.Text;

namespace Game2048
{

	internal sealed class Board
	{

		public const uint GAME_SIZE = 4;

		public const decimal PROBABILITY_2 = 90.9090909m;

		private uint[,] _cells;

		private Random _random;

		public Board()
		{
			this._cells = new uint[GAME_SIZE, GAME_SIZE];
			this._random = new Random(DateTime.Now.Millisecond);
		}

		public void Reset()
		{
			for (uint x = 0; x < GAME_SIZE; x++)
				for (uint y = 0; y < GAME_SIZE; y++)
					this[x, y] = 0;
		}

		internal uint[] GetVerticalSlice(uint x)
		{
			List<uint> result = new List<uint>();
			for (uint y = 0; y < GAME_SIZE; y++)
				result.Add(_cells[x, y]);
			return result.ToArray();
		}

		internal void SetVerticalSlice(uint x, params uint[] values)
		{
			for (uint y = 0; y < GAME_SIZE; y++)
				this[x, y] = values[y];
		}

		internal uint[] GetHorizontalSlice(uint y)
		{
			List<uint> result = new List<uint>();
			for (uint x = 0; x < GAME_SIZE; x++)
				result.Add(_cells[x, y]);
			return result.ToArray();
		}

		internal void SetHorizontalSlice(uint y, params uint[] values)
		{
			for (uint x = 0; x < GAME_SIZE; x++)
				this[x, y] = values[x];
		}

		internal uint this[uint x, uint y]
		{
			get { return this._cells[x, y]; }
			set { this._cells[x, y] = value; }
		}

		public void MoveUp()
		{
		}

		public void MoveDown()
		{
		}

		public void MoveLeft()
		{
			for(int x = 0; x < GAME_SIZE; x++)
			{

			}
		}

		public void MoveRight()
		{
		}

	}

}

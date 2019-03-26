using System;
using System.Collections.Generic;
using System.Linq;
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

		internal IEnumerable<uint> GetVerticalSlice(uint x, bool withoutZero = false)
		{
			for (uint y = 0; y < GAME_SIZE; y++)
				if ((withoutZero && _cells[x, y] > 0) ^ !withoutZero)
					yield return _cells[x, y];
		}

		internal void SetVerticalSlice(uint x, params uint[] values)
		{
			for (uint y = 0; y < GAME_SIZE; y++)
				this[x, y] = values[y];
		}

		internal IEnumerable<uint> GetHorizontalSlice(uint y, bool withoutZero = false)
		{
			for (uint x = 0; x < GAME_SIZE; x++)
				if ((withoutZero && _cells[x, y] > 0) ^ !withoutZero)
					yield return _cells[x, y];
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
			for(uint x = 0; x < GAME_SIZE; x++)
			{
				uint[] slice = GetHorizontalSlice(x, false).ToArray();
				slice = CollapseCells(slice);

				uint? last = null;
				for(uint i = 0; i < slice.Length; i++)
				{
					if (!last.HasValue && slice[i] == 0)
						last = i;
					else if(last.HasValue && slice[i] > 0)
					{
						slice[last.Value] = slice[i];
						slice[i] = 0;
						last = null;
					}
				}

				this.SetHorizontalSlice(x, slice);

			}
		}

		public void MoveRight()
		{
			for (uint x = 0; x < GAME_SIZE; x++)
			{
				uint[] slice = GetHorizontalSlice(x, false).ToArray();
				slice = CollapseCells(slice);

				uint? last = null;
				for (uint i = 0; i < slice.Length; i++)
				{
					if (!last.HasValue && slice[i] > 0)
						last = i;
					else if (last.HasValue && slice[i] == 0)
					{
						slice[i] = slice[last.Value];
						slice[last.Value] = 0;
						last = i;
					}
				}

				this.SetHorizontalSlice(x, slice);

			}
		}

		internal uint[] CollapseCells(uint[] slice)
		{
			uint? last = null;
			for (uint i = 0; i < slice.Length; i++)
			{
				if (slice[i] > 0)
				{
					if (last.HasValue && slice[i] == slice[last.Value])
					{
						slice[last.Value] <<= 1;
						slice[i] = 0;
						last = null;
					}
					else
						last = i;
				}
			}
			return slice;
		}

	}

}

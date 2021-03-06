﻿using System;
using System.Collections.Generic;

namespace Game2048
{

	internal sealed class Board
	{

		public const uint GAME_SIZE = 4;

		public const double PROBABILITY_2 = 90.9090909d;

		private uint[,] _cells;
		
		private Random _random;

		private enum KEY_ARROW : uint
		{
			UNKNOWN = 0,
			LEFT = 1,
			RIGHT = 2,
			UP = 3,
			DOWN = 4,
		}

		public uint Score { get; private set; }

		public event EventHandler GameOver;

		public Board()
		{
			this._cells = new uint[GAME_SIZE, GAME_SIZE];
			this._random = new Random(DateTime.Now.Millisecond);
			this.Reset(true);
		}

		public void Reset(bool newCells = false)
		{
			this.Score = 0;
			for (uint x = 0; x < GAME_SIZE; x++)
				for (uint y = 0; y < GAME_SIZE; y++)
					this[x, y] = 0;
			if (newCells)
			{
				this.NewCell();
				this.NewCell();
			}
		}

		#region Slices

		internal uint[] GetVerticalSlice(uint x)
		{
			uint[] result = new uint[GAME_SIZE];
			for (uint y = 0; y < GAME_SIZE; y++)
				result[y] = _cells[x, y];
			return result;
		}

		internal void SetVerticalSlice(uint x, params uint[] values)
		{
			for (uint y = 0; y < GAME_SIZE; y++)
				this[x, y] = values[y];
		}

		internal uint[] GetHorizontalSlice(uint y)
		{
			uint[] result = new uint[GAME_SIZE];
			for (uint x = 0; x < GAME_SIZE; x++)
				result[x] = _cells[x, y];
			return result;
		}

		internal void SetHorizontalSlice(uint y, params uint[] values)
		{
			for (uint x = 0; x < GAME_SIZE; x++)
				this[x, y] = values[x];
		}

		#endregion

		#region New cells

		internal void NewCell()
		{
			if (this.HasEmptyCell())
			{
				uint x, y;
				do
				{
					x = (uint)_random.Next(0, (int)GAME_SIZE);
					y = (uint)_random.Next(0, (int)GAME_SIZE);
				}
				while (this[x, y] > 0);

				this[x, y] = NewCellValue();
			}
			else
				CheckIfGameIsOver();
		}

		internal bool CheckIfGameIsOver()
		{
			bool CheckRow(uint[] slice)
			{
				uint? last = slice[0];
				for (int i = 1; i < slice.Length; i++)
				{
					if (slice[i] == last.Value)
						return false;
					else
						last = slice[i];
				}
				return true;
			}

			for (uint x = 0; x < GAME_SIZE; x++)
			{
				uint[] slice = GetVerticalSlice(x);
				if (!CheckRow(slice))
					return false;
			}
			for (uint y = 0; y < GAME_SIZE; y++)
			{
				uint[] slice = GetHorizontalSlice(y);
				if (!CheckRow(slice))
					return false;
			}

			GameOver?.Invoke(this, EventArgs.Empty);
			return true;
		}

		internal bool HasEmptyCell()
		{
			for (uint x = 0; x < GAME_SIZE; x++)
				for (uint y = 0; y < GAME_SIZE; y++)
					if (this[x, y] == 0)
						return true;
			return false;
		}

		internal uint NewCellValue()
		{
			double random = _random.Next(0, 100) + _random.NextDouble();
			if (random > PROBABILITY_2)
				return 4;
			else
				return 2;
		}

		#endregion

		#region Moves

		public void MoveUp(bool newCell = false) => Move(KEY_ARROW.UP, newCell);

		public void MoveDown(bool newCell = false) => Move(KEY_ARROW.DOWN, newCell);

		public void MoveLeft(bool newCell = false) => Move(KEY_ARROW.LEFT, newCell);

		public void MoveRight(bool newCell = false) => Move(KEY_ARROW.RIGHT, newCell);
		
		private void Move(KEY_ARROW arrow, bool newCell = false)
		{
			for (uint x = 0; x < GAME_SIZE; x++)
			{
				uint[] slice;
				slice = arrow == KEY_ARROW.RIGHT || arrow == KEY_ARROW.LEFT 
					? GetHorizontalSlice(x) 
					: GetVerticalSlice(x);
				slice = CollapseCells(slice);
				slice = arrow == KEY_ARROW.LEFT || arrow == KEY_ARROW.UP
					? ZeroToLeft(slice)
					: ZeroToRight(slice);
				if (arrow == KEY_ARROW.RIGHT || arrow == KEY_ARROW.LEFT)
					this.SetHorizontalSlice(x, slice);
				else
					this.SetVerticalSlice(x, slice);
			}
			if (newCell)
				this.NewCell();
		}

		#endregion

		internal uint[] ZeroToLeft(uint[] slice)
		{
			uint[] result = new uint[GAME_SIZE];
			for (int i = 0; i < slice.Length; i++)
				result[i] = slice[i];
			return result;
		}

		internal uint[] ZeroToRight(uint[] slice)
		{
			uint[] result = new uint[GAME_SIZE];
			for (int i = 0; i < slice.Length; i++)
				result[GAME_SIZE - slice.Length + i] = slice[i];
			return result;
		}

		internal uint[] CollapseCells(uint[] slice)
		{
			List<uint> result = new List<uint>();

			uint? last = null;
			for (uint i = 0; i < slice.Length; i++)
			{
				if (slice[i] > 0)
				{
					if (last.HasValue && slice[i] == slice[last.Value])
					{
						slice[last.Value] <<= 1;
						slice[i] = 0;
						this.Score += slice[last.Value];
						last = null;
					}
					else
						last = i;
				}
			}

			foreach (uint r in slice)
				if (r > 0)
					result.Add(r);

			return result.ToArray();
		}

		internal uint this[uint x, uint y]
		{
			get { return this._cells[x, y]; }
			set { this._cells[x, y] = value; }
		}

	}

}

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game2048.Tests
{
	[TestClass]
	public class Main
	{

		[TestMethod]
		public void InitCleanAndReset()
		{
			Board gameBoard = new Board();

			bool IsEmpty(Board game)
			{
				for (uint x = 0; x < Board.GAME_SIZE; x++)
					for (uint y = 0; y < Board.GAME_SIZE; y++)
						if(game[x, y] > 0)
							return false;
				return true;
			}

			Assert.IsTrue(IsEmpty(gameBoard));

			gameBoard[0, 0] = 2;
			gameBoard[0, 1] = 4;
			gameBoard[0, 2] = 8;
			gameBoard[0, 3] = 16;

			Assert.IsFalse(IsEmpty(gameBoard));

			gameBoard.Reset();

			Assert.IsTrue(IsEmpty(gameBoard));

		}

		[TestMethod]
		public void GetHorizontalSlice()
		{
			Board gameBoard = new Board();

			gameBoard[0, 0] = 2;
			gameBoard[1, 0] = 4;
			gameBoard[2, 0] = 8;
			gameBoard[3, 0] = 16;

			gameBoard[0, 1] = 16;
			gameBoard[1, 1] = 8;
			gameBoard[2, 1] = 4;
			gameBoard[3, 1] = 2;

			gameBoard[0, 2] = 2;
			gameBoard[1, 2] = 2;
			gameBoard[2, 2] = 2;
			gameBoard[3, 2] = 2;

			gameBoard[0, 3] = 0;
			gameBoard[1, 3] = 0;
			gameBoard[2, 3] = 0;
			gameBoard[3, 3] = 0;

			var slice0 = gameBoard.GetHorizontalSlice(0).ToArray();
			Assert.AreEqual(4, slice0);
			Assert.AreEqual(2u, slice0[0]);
			Assert.AreEqual(4u, slice0[1]);
			Assert.AreEqual(8u, slice0[2]);
			Assert.AreEqual(16u, slice0[3]);

			var slice1 = gameBoard.GetHorizontalSlice(1).ToArray();
			Assert.AreEqual(4, slice1.Length);
			Assert.AreEqual(16u, slice1[0]);
			Assert.AreEqual(8u, slice1[1]);
			Assert.AreEqual(4u, slice1[2]);
			Assert.AreEqual(2u, slice1[3]);

			var slice2 = gameBoard.GetHorizontalSlice(2).ToArray();
			Assert.AreEqual(4, slice2.Length);
			Assert.AreEqual(2u, slice2[0]);
			Assert.AreEqual(2u, slice2[1]);
			Assert.AreEqual(2u, slice2[2]);
			Assert.AreEqual(2u, slice2[3]);

			var slice3 = gameBoard.GetHorizontalSlice(3).ToArray();
			Assert.AreEqual(4, slice3.Length);
			Assert.AreEqual(0u, slice3[0]);
			Assert.AreEqual(0u, slice3[1]);
			Assert.AreEqual(0u, slice3[2]);
			Assert.AreEqual(0u, slice3[3]);

		}

		[TestMethod]
		public void GetHorizontalSliceWithoutZero()
		{
			Board gameBoard = new Board();

			gameBoard[0, 0] = 2;
			gameBoard[1, 0] = 4;
			gameBoard[2, 0] = 8;
			gameBoard[3, 0] = 16;

			gameBoard[0, 1] = 16;
			gameBoard[1, 1] = 8;
			gameBoard[2, 1] = 4;
			gameBoard[3, 1] = 2;

			gameBoard[0, 2] = 2;
			gameBoard[1, 2] = 2;
			gameBoard[2, 2] = 2;
			gameBoard[3, 2] = 2;

			gameBoard[0, 3] = 0;
			gameBoard[1, 3] = 0;
			gameBoard[2, 3] = 0;
			gameBoard[3, 3] = 0;

			var slice0 = gameBoard.GetHorizontalSlice(0, true).ToArray();
			Assert.AreEqual(4, slice0);
			Assert.AreEqual(2u, slice0[0]);
			Assert.AreEqual(4u, slice0[1]);
			Assert.AreEqual(8u, slice0[2]);
			Assert.AreEqual(16u, slice0[3]);

			var slice1 = gameBoard.GetHorizontalSlice(1, true).ToArray();
			Assert.AreEqual(4, slice1.Length);
			Assert.AreEqual(16u, slice1[0]);
			Assert.AreEqual(8u, slice1[1]);
			Assert.AreEqual(4u, slice1[2]);
			Assert.AreEqual(2u, slice1[3]);

			var slice2 = gameBoard.GetHorizontalSlice(2, true).ToArray();
			Assert.AreEqual(4, slice2.Length);
			Assert.AreEqual(2u, slice2[0]);
			Assert.AreEqual(2u, slice2[1]);
			Assert.AreEqual(2u, slice2[2]);
			Assert.AreEqual(2u, slice2[3]);

			var slice3 = gameBoard.GetHorizontalSlice(3, true).ToArray();
			Assert.AreEqual(0, slice3.Length);

		}

		[TestMethod]
		public void GetVerticalSlice()
		{
			Board gameBoard = new Board();

			gameBoard[0, 0] = 2;
			gameBoard[1, 0] = 4;
			gameBoard[2, 0] = 8;
			gameBoard[3, 0] = 16;

			gameBoard[0, 1] = 16;
			gameBoard[1, 1] = 8;
			gameBoard[2, 1] = 4;
			gameBoard[3, 1] = 2;

			gameBoard[0, 2] = 2;
			gameBoard[1, 2] = 2;
			gameBoard[2, 2] = 2;
			gameBoard[3, 2] = 2;

			gameBoard[0, 3] = 0;
			gameBoard[1, 3] = 0;
			gameBoard[2, 3] = 0;
			gameBoard[3, 3] = 0;

			var slice0 = gameBoard.GetVerticalSlice(0).ToArray();
			Assert.AreEqual(4, slice0.Length);
			Assert.AreEqual(2u, slice0[0]);
			Assert.AreEqual(16u, slice0[1]);
			Assert.AreEqual(2u, slice0[2]);
			Assert.AreEqual(0u, slice0[3]);

			var slice1 = gameBoard.GetVerticalSlice(1).ToArray();
			Assert.AreEqual(4, slice1.Length);
			Assert.AreEqual(4u, slice1[0]);
			Assert.AreEqual(8u, slice1[1]);
			Assert.AreEqual(2u, slice1[2]);
			Assert.AreEqual(0u, slice1[3]);

			var slice2 = gameBoard.GetVerticalSlice(2).ToArray();
			Assert.AreEqual(4, slice2.Length);
			Assert.AreEqual(8u, slice2[0]);
			Assert.AreEqual(4u, slice2[1]);
			Assert.AreEqual(2u, slice2[2]);
			Assert.AreEqual(0u, slice2[3]);

			var slice3 = gameBoard.GetVerticalSlice(3).ToArray();
			Assert.AreEqual(4, slice3.Length);
			Assert.AreEqual(16u, slice3[0]);
			Assert.AreEqual(2u, slice3[1]);
			Assert.AreEqual(2u, slice3[2]);
			Assert.AreEqual(0u, slice3[3]);

		}

		[TestMethod]
		public void GetVerticalSliceWithoutZero()
		{
			Board gameBoard = new Board();

			gameBoard[0, 0] = 2;
			gameBoard[1, 0] = 4;
			gameBoard[2, 0] = 8;
			gameBoard[3, 0] = 16;

			gameBoard[0, 1] = 16;
			gameBoard[1, 1] = 8;
			gameBoard[2, 1] = 4;
			gameBoard[3, 1] = 2;

			gameBoard[0, 2] = 2;
			gameBoard[1, 2] = 2;
			gameBoard[2, 2] = 2;
			gameBoard[3, 2] = 2;

			gameBoard[0, 3] = 0;
			gameBoard[1, 3] = 0;
			gameBoard[2, 3] = 0;
			gameBoard[3, 3] = 0;

			var slice0 = gameBoard.GetVerticalSlice(0, true).ToArray();
			Assert.AreEqual(3, slice0.Length);
			Assert.AreEqual(2u, slice0[0]);
			Assert.AreEqual(16u, slice0[1]);
			Assert.AreEqual(2u, slice0[2]);

			var slice1 = gameBoard.GetVerticalSlice(1, true).ToArray();
			Assert.AreEqual(3, slice1.Length);
			Assert.AreEqual(4u, slice1[0]);
			Assert.AreEqual(8u, slice1[1]);
			Assert.AreEqual(2u, slice1[2]);

			var slice2 = gameBoard.GetVerticalSlice(2, true).ToArray();
			Assert.AreEqual(3, slice2.Length);
			Assert.AreEqual(8u, slice2[0]);
			Assert.AreEqual(4u, slice2[1]);
			Assert.AreEqual(2u, slice2[2]);

			var slice3 = gameBoard.GetVerticalSlice(3, true).ToArray();
			Assert.AreEqual(3, slice3.Length);
			Assert.AreEqual(16u, slice3[0]);
			Assert.AreEqual(2u, slice3[1]);
			Assert.AreEqual(2u, slice3[2]);

		}

		[TestMethod]
		public void SetHorizontalSlice()
		{
			Board gameBoard = new Board();

			gameBoard.SetHorizontalSlice(0, 2, 4, 8, 16);
			gameBoard.SetHorizontalSlice(1, 16, 8, 4, 2);
			gameBoard.SetHorizontalSlice(2, 2, 2, 2, 2);
			gameBoard.SetHorizontalSlice(3, 0, 0, 0, 0);

			var slice0 = gameBoard.GetHorizontalSlice(0).ToArray();
			Assert.AreEqual(4, slice0.Length);
			Assert.AreEqual(2u, slice0[0]);
			Assert.AreEqual(4u, slice0[1]);
			Assert.AreEqual(8u, slice0[2]);
			Assert.AreEqual(16u, slice0[3]);

			var slice1 = gameBoard.GetHorizontalSlice(1).ToArray();
			Assert.AreEqual(4, slice1.Length);
			Assert.AreEqual(16u, slice1[0]);
			Assert.AreEqual(8u, slice1[1]);
			Assert.AreEqual(4u, slice1[2]);
			Assert.AreEqual(2u, slice1[3]);

			var slice2 = gameBoard.GetHorizontalSlice(2).ToArray();
			Assert.AreEqual(4, slice2.Length);
			Assert.AreEqual(2u, slice2[0]);
			Assert.AreEqual(2u, slice2[1]);
			Assert.AreEqual(2u, slice2[2]);
			Assert.AreEqual(2u, slice2[3]);

			var slice3 = gameBoard.GetHorizontalSlice(3).ToArray();
			Assert.AreEqual(4, slice3.Length);
			Assert.AreEqual(0u, slice3[0]);
			Assert.AreEqual(0u, slice3[1]);
			Assert.AreEqual(0u, slice3[2]);
			Assert.AreEqual(0u, slice3[3]);
		}

		[TestMethod]
		public void SetVerticalSlice()
		{
			Board gameBoard = new Board();

			gameBoard.SetVerticalSlice(0, 2, 16, 2, 0);
			gameBoard.SetVerticalSlice(1, 4, 8, 2, 0);
			gameBoard.SetVerticalSlice(2, 8, 4, 2, 0);
			gameBoard.SetVerticalSlice(3, 16, 2, 2, 0);

			var slice0 = gameBoard.GetVerticalSlice(0).ToArray();
			Assert.AreEqual(4, slice0.Length);
			Assert.AreEqual(2u, slice0[0]);
			Assert.AreEqual(16u, slice0[1]);
			Assert.AreEqual(2u, slice0[2]);
			Assert.AreEqual(0u, slice0[3]);

			var slice1 = gameBoard.GetVerticalSlice(1).ToArray();
			Assert.AreEqual(4, slice1.Length);
			Assert.AreEqual(4u, slice1[0]);
			Assert.AreEqual(8u, slice1[1]);
			Assert.AreEqual(2u, slice1[2]);
			Assert.AreEqual(0u, slice1[3]);

			var slice2 = gameBoard.GetVerticalSlice(2).ToArray();
			Assert.AreEqual(4, slice2.Length);
			Assert.AreEqual(8u, slice2[0]);
			Assert.AreEqual(4u, slice2[1]);
			Assert.AreEqual(2u, slice2[2]);
			Assert.AreEqual(0u, slice2[3]);

			var slice3 = gameBoard.GetVerticalSlice(3).ToArray();
			Assert.AreEqual(4, slice3.Length);
			Assert.AreEqual(16u, slice3[0]);
			Assert.AreEqual(2u, slice3[1]);
			Assert.AreEqual(2u, slice3[2]);
			Assert.AreEqual(0u, slice3[3]);
		}

		[TestMethod]
		public void ConditionTest()
		{

			int Count(bool withoutZero, params int[] numbers)
			{
				int count = 0;
				foreach(int n in numbers)
				{
					if((withoutZero && n > 0) ^ !withoutZero)
						count += 1;
				}
				return count;
			}

			Assert.AreEqual(5, Count(true, 1, 2, 3, 4, 5));
			Assert.AreEqual(5, Count(true, 1, 2, 0, 3, 4, 0, 5));
			Assert.AreEqual(7, Count(false, 1, 2, 0, 3, 4, 0, 5));

		}

	}
}

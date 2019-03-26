using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Game2048.Tests
{
	[TestClass]
	public class Moves
	{

		[TestMethod]
		public void MoveLeft()
		{
			Board gameBoard = new Board();

			gameBoard.SetHorizontalSlice(0, 2, 0, 2, 4);
			gameBoard.SetHorizontalSlice(1, 8, 8, 2, 2);
			gameBoard.SetHorizontalSlice(2, 2, 0, 0, 2);
			gameBoard.SetHorizontalSlice(3, 8, 4, 4, 16);

			gameBoard.MoveLeft();

			var slice0 = gameBoard.GetHorizontalSlice(0).ToArray();
			Assert.AreEqual(4u, slice0[0]);
			Assert.AreEqual(4u, slice0[1]);
			Assert.AreEqual(0u, slice0[2]);
			Assert.AreEqual(0u, slice0[3]);

			var slice1 = gameBoard.GetHorizontalSlice(1).ToArray();
			Assert.AreEqual(16u, slice1[0]);
			Assert.AreEqual(4u, slice1[1]);
			Assert.AreEqual(0u, slice1[2]);
			Assert.AreEqual(0u, slice1[3]);

			var slice2 = gameBoard.GetHorizontalSlice(2).ToArray();
			Assert.AreEqual(4u, slice2[0]);
			Assert.AreEqual(0u, slice2[1]);
			Assert.AreEqual(0u, slice2[2]);
			Assert.AreEqual(0u, slice2[3]);

			var slice3 = gameBoard.GetHorizontalSlice(3).ToArray();
			Assert.AreEqual(8u, slice3[0]);
			Assert.AreEqual(8u, slice3[1]);
			Assert.AreEqual(16u, slice3[2]);
			Assert.AreEqual(0u, slice3[3]);

		}

		[TestMethod]
		public void MoveRight()
		{
			Board gameBoard = new Board();

			gameBoard.SetHorizontalSlice(0, 2, 0, 2, 4);
			gameBoard.SetHorizontalSlice(1, 8, 8, 2, 2);
			gameBoard.SetHorizontalSlice(2, 2, 0, 0, 2);
			gameBoard.SetHorizontalSlice(3, 8, 4, 4, 16);

			gameBoard.MoveRight();

			var slice0 = gameBoard.GetHorizontalSlice(0).ToArray();
			Assert.AreEqual(0u, slice0[0]);
			Assert.AreEqual(0u, slice0[1]);
			Assert.AreEqual(4u, slice0[2]);
			Assert.AreEqual(4u, slice0[3]);

			var slice1 = gameBoard.GetHorizontalSlice(1).ToArray();
			Assert.AreEqual(0u, slice1[0]);
			Assert.AreEqual(0u, slice1[1]);
			Assert.AreEqual(16u, slice1[2]);
			Assert.AreEqual(4u, slice1[3]);

			var slice2 = gameBoard.GetHorizontalSlice(2).ToArray();
			Assert.AreEqual(0u, slice2[0]);
			Assert.AreEqual(0u, slice2[1]);
			Assert.AreEqual(0u, slice2[2]);
			Assert.AreEqual(4u, slice2[3]);

			var slice3 = gameBoard.GetHorizontalSlice(3).ToArray();
			Assert.AreEqual(0u, slice3[0]);
			Assert.AreEqual(8u, slice3[1]);
			Assert.AreEqual(8u, slice3[2]);
			Assert.AreEqual(16u, slice3[3]);

		}

	}
}

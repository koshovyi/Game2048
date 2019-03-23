using Microsoft.VisualStudio.TestTools.UnitTesting;

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
			gameBoard.SetHorizontalSlice(2, 2, 0, 0, 0);
			gameBoard.SetHorizontalSlice(3, 8, 4, 4, 16);

			gameBoard.MoveLeft();


		}

	}
}

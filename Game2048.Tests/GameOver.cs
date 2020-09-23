using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game2048.Tests
{
	[TestClass]
	public class GameOver
	{

		[TestMethod]
		public void GameOverTrue()
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
			gameBoard[1, 2] = 4;
			gameBoard[2, 2] = 8;
			gameBoard[3, 2] = 16;

			gameBoard[0, 3] = 16;
			gameBoard[1, 3] = 8;
			gameBoard[2, 3] = 4;
			gameBoard[3, 3] = 2;

			bool result = gameBoard.CheckIfGameIsOver();
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void GameOverFalse1()
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
			gameBoard[1, 2] = 4;
			gameBoard[2, 2] = 8;
			gameBoard[3, 2] = 16;

			gameBoard[0, 3] = 16;
			gameBoard[1, 3] = 4;
			gameBoard[2, 3] = 8;
			gameBoard[3, 3] = 2;

			bool result = gameBoard.CheckIfGameIsOver();
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void GameOverFalse2()
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
			gameBoard[1, 2] = 4;
			gameBoard[2, 2] = 8;
			gameBoard[3, 2] = 16;

			gameBoard[0, 3] = 16;
			gameBoard[1, 3] = 8;
			gameBoard[2, 3] = 8;
			gameBoard[3, 3] = 2;

			bool result = gameBoard.CheckIfGameIsOver();
			Assert.IsFalse(result);
		}

	}
}

// Program.cs
using System;

namespace Connect4
{
	/// <summary>
	/// Class implements a two player game of Connect 4. The board is 7 columns and 6 rows
	/// </summary>
	public class Connect4
	{
		/// <summary>
		/// Store the board's column size.
		/// </summary>
		public static int boardColumnSize; 
		/// <summary>
		/// Store the board's row size.
		/// </summary>
		public static int boardRowSize; 

		/// <summary>
		/// A 2D array representing the board.
		/// </summary>
		public static int[,] board;
		/// <summary>
		/// Store which player's turn it is.
		/// </summary>
		public static int playerNumber;

		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main (string[] args)
		{
			// Instantiate the Connect4 class.
			Connect4 connect4 = new Connect4 ();

			// Initialize the static variables declared above
			boardColumnSize = 6; 
			boardRowSize = 7; 
			playerNumber = -1;

			board = new int[boardColumnSize,boardRowSize];

			// Stores whether the game has been won
			bool haveWon = false;

			// Prompt player to proceed with their move
			Console.WriteLine ("Connect4!");
			Console.WriteLine ("Enter whole number between 0-6 representing the column.");
			Console.WriteLine ("Player 1 has a turn: ");

			// Store player's input 
			int playerInput = -1;
			// Always start off with the first player
			playerNumber = 1;

			// Loop indefinately until the game has been won
			while (!haveWon) {
				// Read player input and parse an integer representing the column number of the move
				if (int.TryParse (Console.ReadLine (), out playerInput) && playerInput >= 0 && playerInput < 7)
					haveWon = connect4.Play (playerInput);
				else {
					Console.WriteLine ("Only whole numbers between 0-6 representing the columns for move.");
					Console.WriteLine ("Player " + playerNumber + " has a turn:");
				}
			} 

			// If the game has been won by a player, any following moves should return ”Game has finished!”.
			while (Console.ReadLine () != "y") {
				Console.WriteLine ("Game has finished!");
				Console.WriteLine ("Enter y to quit.");
			}

		}

		/// <summary>
		/// Inserts moves in the board, assign turns to player, and prints the board out.
		/// </summary>
		/// <param name="playerInput">Player input.</param>
		public bool Play (int playerInput) {
			
			if (InsertMove (playerInput)) {
				// if valid move -> show board and allow other player to play
				ShowBoard ();
				if (CheckIfWon ()) {
					return true;
				} else {
					if (playerNumber == 1)
						playerNumber = 2;
					else if (playerNumber == 2)
						playerNumber = 1;
				}
			} else {
				// if not a valid move -> show error and show board
				// allow the same player to go again
				Console.WriteLine ("Column Full -- Try again!");
				ShowBoard ();
			}
			
			Console.WriteLine ("Player " + playerNumber + " has a turn:");

			return false;
		}

		/// <summary>
		/// Inserts the move.
		/// </summary>
		/// <returns><c>true</c>, if the move was valid, <c>false</c> otherwise.</returns>
		/// <param name="moveNumber">Column number played by player.</param>
		public bool InsertMove (int moveNumber) {
			int rowNumber = boardColumnSize - 1;
			bool isColumnFull = false;

			// loop and check to see a top slot to fill
			while (!isColumnFull) {
				if (board [rowNumber, moveNumber] != 1 && board [rowNumber, moveNumber] != 2) {
					// if the column and row is empty: insert move
					board [rowNumber, moveNumber] = playerNumber;
					return true;
				} else if (rowNumber > 0) {
					// decrement row number if slot is taken
					// decrement until an empty row is available in the column
					rowNumber--;
				} else {
					// the column is full -> show error
					isColumnFull = true;
					return false;
				}
			}
			return false;
		}

		/// <summary>
		/// Checks if four slots have been vertically, horizontally, or diagonally by either player.
		/// </summary>
		/// <returns><c>true</c>, if four slots have been filled by either player, <c>false</c> otherwise.</returns>
		public bool CheckIfWon () {
			// count number of 1s and 2s vertically, horizontally, or diagonally 
			// if count == 4 -> game won

			int player1StraightCount = 0;
			int player2StraightCount = 0;

			// checking horizontally:
			for (int i=0; i<boardColumnSize; i++){
				for (int j=0; j<boardRowSize; j++){
					if (board [i, j] == 1) {
						player1StraightCount += 1;
						player2StraightCount = 0;
					} else if (board [i, j] == 2) {
						player2StraightCount += 1;
						player1StraightCount = 0;
					} else if (board [i, j] == 0) {
						player1StraightCount = 0;
						player2StraightCount = 0;
					}

					if (player1StraightCount >= 4) {
						Console.WriteLine ("Player 1 wins!");
						return true;
					} else if (player2StraightCount >= 4) {
						Console.WriteLine ("Player 2 wins!");
						return true;
					}
				}
				player1StraightCount = 0;
				player2StraightCount = 0;
			}

			player1StraightCount = 0;
			player2StraightCount = 0;

			// checking vertically: 
			for (int j=0; j<boardRowSize; j++){
				for (int i=0; i<boardColumnSize; i++){
					if (board [i, j] == 1) {
						player1StraightCount += 1;
						player2StraightCount = 0;
					} else if (board [i, j] == 2) {
						player2StraightCount += 1;
						player1StraightCount = 0;
					} else if (board [i, j] == 0) {
						player1StraightCount = 0;
						player2StraightCount = 0;
					}

					if (player1StraightCount >= 4) {
						Console.WriteLine ("Player 1 wins!");
						return true;
					} else if (player2StraightCount >= 4) {
						Console.WriteLine ("Player 2 wins!");
						return true;
					}
				}
				player1StraightCount = 0;
				player2StraightCount = 0;
			}

			// check diagonally: \
			/*
		 	(0,0) (0,1) (0,2) (0,3) (0,4) (0,5) (0,6) 
			(1,0) (1,1) (1,2) (1,3) (1,4) (1,5) (1,6) 
			(2,0) (2,1) (2,2) (2,3) (2,4) (2,5) (2,6) 
			(3,0) (3,1) (3,2) (3,3) (3,4) (3,5) (3,6) 
			(4,0) (4,1) (4,2) (4,3) (4,4) (4,5) (4,6) 
			(5,0) (5,1) (5,2) (5,3) (5,4) (5,5) (5,6) 

			(0,0)
			(1,0) (0,1)
			(2,0) (1,1) (0,2)
			(3,0) (2,1) (1,2) (0,3)
			(4,0) (3,1) (2,2) (1,3) (0,4) 
			(5,0) (4,1) (3,2) (2,3) (1,4) (0,5)
			(5,1) (4,2) (3,3) (2,4) (1,5) (0,6)
			(5,2) (4,3) (3,4) (2,5) (1,6)
			(5,3) (4,4) (3,5) (2,6)
			(5,4) (4,5) (3,6)
			(5,5) (4,6)
			(5,6)
			*/

			if (checkDiagonal (0, 0, false))
				return true;

			// check alternate diagonally: /
			/*
			(0,6)
			(1,6) (0,5)
			(2,6) (1,5) (0,4)
			(3,6) (2,5) (1,4) (0,3)
			(4,6) (3,5) (2,4) (1,3) (0,2) 
			(5,6) (4,5) (3,4) (2,3) (1,2) (0,1) 
			(5,5) (4,4) (3,3) (2,2) (1,1) (0,0) 
			(5,4) (4,3) (3,2) (2,1) (1,0)
			(5,3) (4,2) (3,1) (2,0) 
			(5,2) (4,1) (3,0) 
			(5,1) (4,0) 
			(5,0) 
			*/

			if (checkDiagonal (0, 6, true))
				return true;

			return false;
		}

		public bool checkDiagonal (int colCounter, int rowCounter, bool isDiagonalAlt) {
			int counter = 0;

			while (counter < boardColumnSize+boardRowSize-1) {
				if (DiagonalHelper (colCounter, rowCounter, isDiagonalAlt)) {
					return true;
				}

				if (counter < boardColumnSize-1) {
					colCounter++;
				} else {
					if (isDiagonalAlt)
						rowCounter--;
					else 
						rowCounter++;
				}
				counter++;
			}
			return false;
		}

		/// <summary>
		/// Helper function for checking a 4 slot match for either player diagonally.
		/// </summary>
		/// <returns><c>true</c>, if 4 slots were filled diagonally, <c>false</c> otherwise.</returns>
		/// <param name="col">Column from whence to start searching for 4 diagonal slots.</param>
		/// <param name="row">Row from whence to start searching for 4 diagonal slots.</param>
		public bool DiagonalHelper (int col, int row, bool isDiagonalAlt) {
			int player1DiagonalCount = 0;
			int player2DiagonalCount = 0;

			while (col >= 0 && col < boardColumnSize && row >= 0 && row < boardRowSize) {
				if (board [col, row] == 1) {
					player1DiagonalCount += 1;
					player2DiagonalCount = 0;
				} else if (board [col, row] == 2) {
					player2DiagonalCount += 1;
					player1DiagonalCount = 0;
				} else if (board [col, row] == 0) {
					player1DiagonalCount = 0;
					player2DiagonalCount = 0;
				}

				if (player1DiagonalCount >= 4) {
					Console.WriteLine ("Player 1 wins!");
					return true;
				} else if (player2DiagonalCount >= 4) {
					Console.WriteLine ("Player 2 wins!");
					return true;
				}
				col--;
				if (isDiagonalAlt)
					row--;
				else
					row++;
			}
			return false;
		}

		/// <summary>
		/// Prints out the current board.
		/// </summary>
		public void ShowBoard () {
			Console.WriteLine ();
			Console.WriteLine ("=Column Num:=");
			Console.WriteLine ("0 1 2 3 4 5 6");
			Console.WriteLine ("=============");
			for (int i=0; i<boardColumnSize; i++){
				for (int j=0; j<boardRowSize; j++){
					Console.Write (board[i,j] + " ");
				}
				Console.WriteLine ();
			}
			Console.WriteLine ();
		}
	}
}
	
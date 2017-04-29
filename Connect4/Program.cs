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
			Console.WriteLine ("Enter whole number between 1-7 representing the column.");
			Console.WriteLine ("Player 1 move: ");

			// Store player's input 
			int playerInput = -1;
			// Always start off with the first player
			playerNumber = 1;

			// Loop indefinately until the game has been won
			while (!haveWon) {
				// Read player input and parse an integer representing the column number of the move
				if (int.TryParse (Console.ReadLine (), out playerInput) && playerInput >= 0 && playerInput < 7)
					haveWon = connect4.Play (playerInput);
				else
					Console.WriteLine ("Only whole numbers between 0-6 representing the columns for move.");
			} 

		}


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
			
			Console.WriteLine ("Player " + playerNumber + " move:");

			return false;
		}


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
			return true;
		}

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
					} else if (board [i, j] == 2) {
						player2StraightCount += 1;
					}

					if (player1StraightCount >= 4) {
						Console.WriteLine ("Player 1 wins!");
						return true;
					} else if (player2StraightCount >= 4) {
						Console.WriteLine ("Player 2 wins!");
						return true;
					}
				}
//				Console.WriteLine ("Column: Player 1: " + player1StraightCount + " Player 2: " + player2StraightCount);
//				player1StraightCount = 0;
//				player2StraightCount = 0;
			}

			player1StraightCount = 0;
			player2StraightCount = 0;

			// checking vertically: 
			for (int j=0; j<boardRowSize; j++){
				for (int i=0; i<boardColumnSize; i++){
					if (board [i, j] == 1) {
						player1StraightCount += 1;
					} else if (board [i, j] == 2) {
						player2StraightCount += 1;
					}

					if (player1StraightCount >= 4) {
						Console.WriteLine ("Player 1 wins!");
						return true;
					} else if (player2StraightCount >= 4) {
						Console.WriteLine ("Player 2 wins!");
						return true;
					}
				}
//				Console.WriteLine ("Row: Player 1: " + player1StraightCount + " Player 2: " + player2StraightCount);
//				player1StraightCount = 0;
//				player2StraightCount = 0;
			}

			// check diagonally: 


			return false;
		}
			
		public void ShowBoard () {
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
	
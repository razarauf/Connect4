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
				if (int.TryParse (Console.ReadLine (), out playerInput) && playerInput > 0)
					haveWon = connect4.Play (playerInput-1);
				else
					Console.WriteLine ("Only whole numbers between 1-7 representing the columns for move.");
			} 

		}


		public bool Play (int playerInput) {
			
			if (InsertMove (playerInput)) {
				ShowBoard ();
				if (playerNumber == 1)
					playerNumber = 2;
				else if (playerNumber == 2)
					playerNumber = 1;
			} else {
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
					rowNumber--;
				} else {
					// the column is full 
					isColumnFull = true;
					return false;
				}
			}
			return true;
		}

		public bool CheckIfWon () {
			// check if 4 vertically, horizontally, or diagonally 
			return true;
		}
			
		public void ShowBoard () {
			Console.WriteLine ("=============");
			Console.WriteLine ("1 2 3 4 5 6 7");
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
	
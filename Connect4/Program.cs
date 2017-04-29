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
			Console.WriteLine ("Connect4:");
			Console.WriteLine ("Player 1 starts: ");
			Console.WriteLine ("Enter whole number between 1-7 representing the column: ");

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
					Console.WriteLine ("Only whole numbers between 1-7 representing the columns");
			} 

		}


		public bool Play (int playerInput) {
			Console.WriteLine ("Player " + playerNumber + ":");
			if (InsertMove (playerInput)) {
				ShowBoard ();
			}
			else
				Console.Write ("Invalid Move");
				
			return true;
		}


		public bool InsertMove (int columnNumber) {
			board[boardColumnSize-1, columnNumber] = playerNumber;
			return true; 
		}

		public bool InsertValidMove (int columnNumber) {
			// check if the slot is taken 
			// If it is not taken -> insert
			// If it is taken -> increment row # 
			// try again until top reached -> if top reached return false and ask for column from same player
		}

		public bool CheckIfWon () {
			// check if 4 vertically, horizontally, or diagonally 
		}
			
		public bool ShowBoard () {
			for (int i=0; i<boardColumnSize; i++){
				for (int j=0; j<boardRowSize; j++){
					Console.Write (board[i,j] + " ");
				}
				Console.WriteLine ();
			}
			return true;
		}
	}
}
	
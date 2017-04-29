using System;

namespace Connect4
{
	public class Connect4
	{
		public static int boardColumnSize; 
		public static int boardRowSize; 

		public static int[,] board;
		public static int playerNumber;

		public static void Main (string[] args)
		{
			Connect4 connect4 = new Connect4 ();

			boardColumnSize = 6; 
			boardRowSize = 7; 
			playerNumber = -1;

			board = new int[boardColumnSize,boardRowSize];

			bool haveWon = false;


			Console.WriteLine ("Connect4:");
			Console.WriteLine ("Player 1 starts: ");
			Console.WriteLine ("Enter whole number between 1-7 representing the column: ");

			while (!haveWon) {
				int playerInput = -1;
				playerNumber = 1;

				if (int.TryParse (Console.ReadLine (), out playerInput) && playerInput > 0) {
				haveWon = connect4.Play (playerInput-1);
				}
				else
					Console.WriteLine ("Only whole numbers between 1-7 representing the columns");
				
			} 

		}

		public bool Play (int playerInput) {
			Console.WriteLine ("Player " + playerNumber + ":");
			if (InsertMove (playerInput))
				ShowBoard ();
			else
				Console.Write ("Invalid Move");
				
			return true;
		}

		public bool InsertMove (int columnNumber) {
			board[boardColumnSize-1, columnNumber] = playerNumber;
			return true; 
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
	
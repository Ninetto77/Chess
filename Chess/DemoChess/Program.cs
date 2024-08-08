using ChessLibrary;
using ChessClient;
using System;
using System.Collections.Generic;


namespace DemoChess
{
	internal class Program
	{
		private const string HOST = "https://localhost:44360/api/Game";
		private const string USER = "";
		static void Main(string[] args)
		{
			ClientChess client = new ClientChess(HOST, USER) ;
			//Chess chess = new Chess(client.GetCurrentGame().fen);

			Random rand = new Random();
			Chess chess = new Chess(client.GetCurrentGame().fen);//"rnbqkbnr/1p1111p1/8/8/8/8/1P1111P1/RNBQKBNR w KQkq - 0 1"

			List<string> list = new List<string>();
			while (true)
			{
				list = chess.GetAllMoves();
				Console.WriteLine(chess.fen);
				//Console.WriteLine(ChessToAscii(chess));
				Print(ChessToAscii(chess));
				Console.WriteLine(chess.IsCheck() ? "Check" : "Not check");

				foreach (string moves in list)
					Console.Write(moves + "\t");
				Console.WriteLine();
				Console.Write("> ");

                string move = Console.ReadLine();
				if (move == "q") break;
				if (move == "") move = list[rand.Next(list.Count)];
				//chess = chess.Move(move);
				chess = new Chess(client.SendMove(move).fen);

			}
		}

		static string ChessToAscii(ChessLibrary.Chess chess)
		{
				string text = "  +------------------+\n";
				for (int y = 7; y >= 0; y--)
				{
					text += y + 1;
					text += " | ";
					for (int x = 0; x < 8; x++)
						text += chess.GetFigureAt(x, y) + " ";
					text += " |\n";

				}

				text += "  +------------------+\n";
				text += "    a b c d e f g h\n";
			return text;
		}

		static void Print(string text)
		{
			ConsoleColor oldForeColor = Console.ForegroundColor;
			foreach(char x in text)
			{
				if (x >= 'a' && x <= 'z')
					Console.ForegroundColor = ConsoleColor.Red;
				else if (x >= 'A' && x <= 'Z')
					Console.ForegroundColor = ConsoleColor.White;
				else
					Console.ForegroundColor = ConsoleColor.Cyan;
				Console.Write(x);
			}
			Console.ForegroundColor = oldForeColor;
			
		}
	}
}

using System;
using ChessClient;

namespace ConsoleChess
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Program program = new Program();
			program.Start();
		}

		public const string HOST = "https://localhost:44360/api/Game";
		public const string	USER = "";

		ClientChess client;

		private void Start()
		{
			client = new ClientChess(HOST, USER);
            Console.WriteLine(client.GetCurrentGame());

			while (true)
			{
				Console.WriteLine("You move");
				string move = Console.ReadLine();
				
				if (move == "q") return;
				Console.Clear();
				Console.WriteLine(client.SendMove(move));
			}
        }
	}
}

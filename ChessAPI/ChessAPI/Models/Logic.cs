using ChessAPI.Models.DB;
using ChessLibrary;
using static Microsoft.EntityFrameworkCore.EntityState;

namespace ChessAPI.Models
{
	public class Logic
	{
		private ChessDBContext db;

        public Logic()
        {
			db = new ChessDBContext();
		}
        public Game GetCurrentGame()
		{
			Game game = db.Games.Where(g => g.Status == "play").OrderBy(g => g.Id).FirstOrDefault() ;
			if (game == null)
				game = CreateNewGame();

			return game;
		}

		public Game GetGame(int id)
		{
			return db.Games.Find(id);
		}

		//public Game NewGame()
		//{
		//	GetCurrentGame().Status = "done";
		//	Game game = CreateNewGame();
		//	return game;
		//}

		public Game MakeMove(int id, string move)
		{
			Game game = GetGame(id);
			if (game == null)
				return game;

			Chess chess = new Chess(game.Fen);
			Chess chessNext = chess.Move(move);

			if (chessNext.fen == game.Fen)
				return game;

			if (game.Status != "play")
				return game;


			game.Fen = chessNext.fen;

			if (chessNext.IsCheck())
				game.Status = "done";

			db.Entry(game).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			db.SaveChanges();

			return game;
		}

		private Game? CreateNewGame()
		{
			Game game = new Game();

			Chess chess = new Chess();

			game.Fen = chess.fen;
			game.Status = "play";

			db.Games.Add(game);
			db.SaveChanges();

			return game;
		}
	}
}

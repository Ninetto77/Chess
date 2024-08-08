using ChessAPI.Data.Interfaces;
using ChessAPI.Models.DB;

namespace ChessAPI.Data.Repository
{
	public class GamesRepository : IAllGamesRepository
	{
		public IEnumerable<Game> allGames => db.Games;

		private ChessDBContext db;
        public GamesRepository(ChessDBContext db)
        {
			this.db = db;
		}
	}
}

using ChessAPI.Models.DB;

namespace ChessAPI.Data.Interfaces
{
	public interface IAllGamesRepository
	{
		IEnumerable<Game> allGames { get; }
	}
}

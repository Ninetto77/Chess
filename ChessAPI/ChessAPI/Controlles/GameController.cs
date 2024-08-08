using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChessAPI.Models.DB;
using ChessAPI.Models;

namespace ChessAPI.Controlles
{
	[Route("api/[controller]")]
	[ApiController]
	public class GameController : ControllerBase
	{
        private readonly ChessDBContext _context;

        public GameController(ChessDBContext context)
        {
            _context = context;
        }

		// GET: Games
		public Game GetGames()
        {
            Logic logic = new Logic();
            Game game = logic.GetCurrentGame();
            return game;
        }

		// GET: Games/5
		[HttpGet("{id}")]
		public Game GetGame(int id)
		{
			Logic logic = new Logic();
			Game game = logic.GetGame(id);
			return game;
		}

		// GET: Games/5/Pe2e4
		[HttpGet("{id}/{move}")]
		public Game GetGame(int id, string move)
		{
			Logic logic = new Logic();
			Game game = logic.MakeMove(id, move);
			return game;
		}



		private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}

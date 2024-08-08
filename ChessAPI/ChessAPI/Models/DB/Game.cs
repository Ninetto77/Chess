using System.ComponentModel.DataAnnotations.Schema;

namespace ChessAPI.Models.DB;

public partial class Game
{
	[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }

    public string Fen { get; set; } = null!;

    public string Status { get; set; } = null!;
}

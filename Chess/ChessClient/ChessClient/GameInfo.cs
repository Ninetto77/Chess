using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessClient
{
	public struct GameInfo
	{
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }
		public string fen;
		public string status;

        public GameInfo(NameValueCollection list)
        {
            id = int.Parse(list["id"]);
			fen = list["fen"];
			status = list["status"];
        }

		public override string ToString()
		{
			return $"GameId = {id}\n" +
				$"fen = {fen}\n" +
				$"status = {status}";
		}
	}
}

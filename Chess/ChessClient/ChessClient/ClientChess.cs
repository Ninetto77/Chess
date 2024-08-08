using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace ChessClient
{
    public class ClientChess
    {
        public string host {  get; private set; }
        public string user {  get; private set; }
        private int CurrentGameID;

        public ClientChess(string host, string user)
        {
            this.host = host;   
            this.user = user;
        }


        public GameInfo GetCurrentGame()
        {
			GameInfo game =  new GameInfo (ParseJson(CallServer()));
            CurrentGameID = game.id;
            return game;
        }

		//public GameInfo NewGame()
		//{
		//	string json = CallServer((CurrentGameID + 1).ToString());

		//	GameInfo game = new GameInfo(ParseJson(CallServer()));
		//	CurrentGameID = game.id;
		//	return game;
		//}

		public GameInfo SendMove(string move)
        {
            string json = CallServer(CurrentGameID + "/" + move);
            var list = ParseJson(json);
            GameInfo game = new GameInfo (list);
            return game;
        }

        private string CallServer(string param = "")
        {
            WebRequest request = WebRequest.Create(host + user +"/" + param);
            WebResponse response = request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                     return sr.ReadToEnd();
                }
            }
        }

        private NameValueCollection ParseJson(string json)
        {
            NameValueCollection list = new NameValueCollection();

			string pattern = @"\""(\w+)\"":\""?([^,\""}]*)\""?";

			foreach (Match m in Regex.Matches(json, pattern))
			{
				if (m.Groups.Count == 3)
                    list[m.Groups[1].Value] = m.Groups[2].Value;
            }
			return list;
        }
    }

}

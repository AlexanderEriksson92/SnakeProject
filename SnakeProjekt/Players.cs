using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;


namespace SnakeProjekt
{
	internal class Players
	{
		public List<Player> PlayerList { get; set; } = new List<Player>();

		public class Player
		{
			public string Name { get; set; }
			public int Score { get; set; }
		}
		public void SavePlayersScore()
		{
			var options = new JsonSerializerOptions
			{
				WriteIndented = true
			}; 
			string jsonString = JsonSerializer.Serialize(PlayerList, options);
			File.WriteAllText("players.json", jsonString);
		}

		public List<Player> LoadPlayersScore()
		{
			try
			{
				string jsonString = File.ReadAllText("players.json");
				PlayerList = JsonSerializer.Deserialize<List<Player>>(jsonString) ?? new List<Player>();
			}
			catch (Exception)
			{
				PlayerList = new List<Player>();
			}
			return PlayerList;
		}
		public void AddPlayerScore(string name, int score)
		{
			PlayerList.Add(new Player { Name = name, Score = score });

			PlayerList = PlayerList.OrderByDescending(player => player.Score).ToList();
			if (PlayerList.Count > 10)
			{
				PlayerList.RemoveAt(PlayerList.Count - 1);
			}
		}
		public List<Player> GetPlayers()
		{
			return PlayerList;
		}
	}
}

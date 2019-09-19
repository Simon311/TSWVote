using System.IO;
using TShockAPI;
using Newtonsoft.Json;

namespace TSWVote
{
	internal class Config
	{
		internal static string ConfigPath
		{
			get { return Path.Combine(TShock.SavePath, "TSWVote.json"); }
		}

		public int ServerID = 0;
		public int NumberOfWebClients = 30;
		public int Timeout = 2000;
		public bool RequirePermission = false;
		public string PermissionName = "vote.vote";

		internal static Config Read()
		{
			if (!File.Exists(ConfigPath))
			{
				File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(new Config(), Formatting.Indented));
			}

			return JsonConvert.DeserializeObject<Config>(File.ReadAllText(ConfigPath));
		}

		internal void Write()
		{
			File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(this, Formatting.Indented));
		}
	}
}

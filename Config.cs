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
		public int Timeout = 10000;
		public bool RequirePermission = false;
		public string PermissionName = "vote.vote";

		internal static Config Read()
		{
			if (!Directory.Exists(TShock.SavePath))
			{
				// This should've probably been fixed with plugin load order,
				// But the problem is, I remember the plugin load order already having been set up correctly.
				// So I am going to assume something changed on TShock's side of things and this a quick fix,
				// Until they sort out the new updates and all the recent bugs they now have.

				Directory.CreateDirectory(TShock.SavePath);
			}

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

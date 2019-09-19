using Newtonsoft.Json;

namespace TSWVote
{
	internal class Response
	{
#pragma warning disable 0649
		public string response;
		public string message;
		public string question;
#pragma warning restore 0649

		public static Response Read(string text)
		{
			Response R = null;

			try
			{
				R = JsonConvert.DeserializeObject<Response>(text);
			}
			catch// (Exception ex)
			{
				//TShockAPI.Log.Error(ex.Message);
				//TShockAPI.Log.Error("Error parsing as JSON: " + text);
			}

			return R;
		}
	}
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SAL.Interfaces;

namespace SAL
{
	public static class TMDbApiConfig
	{
		public static string BASE_URL { get; set; }
		
		public static string SECURE_BASE_URL { get; set; }
		
		public static string BACKDROP_SIZE { get; set; }
		
		public static async Task InitializeAsync(IHttpClient httpClient)
		{
			var response = await httpClient.GetAsync(ServicesManagerConfig.TMDB_API_CONFIGURATION_URL);

			var content = await response.Content.ReadAsStringAsync();
			var jsonObject = JObject.Parse(content);
			var images = jsonObject["images"];
			
			BASE_URL = (string)(images["base_url"]);
			
			SECURE_BASE_URL = (string)(images["secure_base_url"]);
			
			var backdropSizes = JsonConvert.DeserializeObject<List<string>>(images["logo_sizes"].ToString());
			BACKDROP_SIZE = backdropSizes?.ElementAt(2); // TODO: Set the right size depending on the running device.
		}
	}
}

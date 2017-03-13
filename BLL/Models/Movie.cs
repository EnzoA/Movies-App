using Newtonsoft.Json;

namespace BLL.Models
{
	public class Movie
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("poster_path")]
		public string PosterPath { get; set; }
	}
}

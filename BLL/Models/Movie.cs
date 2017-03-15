using Newtonsoft.Json;

namespace BLL.Models
{
	public class Movie
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("poster_path")]
		public string PosterPath { get; set; }
	}
}

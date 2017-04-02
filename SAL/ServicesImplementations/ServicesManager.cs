using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BLL.Models;
using BLL.ExtensionMethods;
using SAL.Interfaces;

namespace SAL.ServicesImplementations
{
	public class ServicesManager : IServicesManager
	{
		#region Private fields

		private IHttpClient _httpClient;
		
		private static readonly Dictionary<string, string> URLS_TO_MOVIE_GROUP_NAMES_MAPPING = new Dictionary<string, string>
		{
			{ ServicesManagerConfig.TOP_RATED_URL, "Top Rated" },
			{ ServicesManagerConfig.POPULAR_URL, "Popular" },
			{ ServicesManagerConfig.NOW_PLAYING_URL, "Now Playing" }
		};

		#endregion

		#region Constructor

		public ServicesManager(IHttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		#endregion

		#region Public methods

		public async Task<IEnumerable<MovieGroup>> GetMovieGroupsAsync()
		{
			return await GetMovieGroupsAsync(onEachMovieGroupCallback: null);
		}

		public async Task<IEnumerable<MovieGroup>> GetMovieGroupsAsync(Action<MovieGroup> onEachMovieGroupCallback)
		{
			var movieGroups = new List<MovieGroup>();
			MovieGroup movieGroup = null;
			var urls = URLS_TO_MOVIE_GROUP_NAMES_MAPPING.Keys;
			
			foreach (var url in urls)
			{
				movieGroup = await GetMovieGroupAsync(url);
				movieGroups.Add(movieGroup);
				onEachMovieGroupCallback?.Invoke(movieGroup);
			}

			return movieGroups;
		}

		#endregion

		#region Private methods
		
		private async Task<MovieGroup> GetMovieGroupAsync(string url)
		{
			List<Movie> movies = null;
			
			try
			{
				var response = await _httpClient.GetAsync(url);
				var content = await response.Content.ReadAsStringAsync();
				var jsonObject = JObject.Parse(content);
				var results = jsonObject.Property("results").Value.ToString();

				var settings = new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore,
					MissingMemberHandling = MissingMemberHandling.Ignore
				};
				movies = JsonConvert.DeserializeObject<List<Movie>>(results, settings);
				System.Diagnostics.Debug.WriteLine(results.ToString());
			}
			catch (Exception ex)
			{
				throw ex;
			}

			var baseUrl = TMDbApiConfig.BASE_URL;
			var backdropSize = TMDbApiConfig.BACKDROP_SIZE;
			movies?.ForEach(m => m.PosterPath = $"{baseUrl}{backdropSize}{m.PosterPath}");

			string movieGroupName;
			URLS_TO_MOVIE_GROUP_NAMES_MAPPING.TryGetValue(url, out movieGroupName);
			var movieGroup = new MovieGroup { GroupName = movieGroupName };
			movieGroup.Movies = movies ?? new List<Movie>();

			return movieGroup;
		}

		#endregion
	}
}

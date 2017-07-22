namespace SAL
{
	internal static class ServicesManagerConfig
	{
		public static readonly string API_KEY = "7a66e7145c6234e287280cdff616f865";

		public static readonly string DEFAULT_LANGUAGE = "en-US";

		public static readonly string BASE_URL = "https://api.themoviedb.org/3/";

		public static readonly string TMDB_API_CONFIGURATION_URL = $"https://api.themoviedb.org/3/configuration?api_key={API_KEY}";

		public static readonly string MOVIE_GROUPS_BASE_URL = $"{BASE_URL}movie/{{0}}?api_key={API_KEY}&language={{1}}&page={{2}}";

		public static readonly string TOP_RATED_URL = string.Format(MOVIE_GROUPS_BASE_URL, "top_rated", DEFAULT_LANGUAGE, 1);

		public static readonly string POPULAR_URL = string.Format(MOVIE_GROUPS_BASE_URL, "popular", DEFAULT_LANGUAGE, 1);

		public static readonly string NOW_PLAYING_URL = string.Format(MOVIE_GROUPS_BASE_URL, "now_playing", DEFAULT_LANGUAGE, 1);

		public static readonly string SIMILAR_MOVIES_BASE_URL = $"{BASE_URL}movie/{{0}}/similar?api_key={API_KEY}&language={{1}}&page={{2}}";

		public static readonly string SIMILAR_MOVIES_URL = string.Format(SIMILAR_MOVIES_BASE_URL, "{0}", DEFAULT_LANGUAGE, 1);

		public static readonly string SEARCH_MOVIES_BASE_URL = $"{BASE_URL}search/movie?api_key={API_KEY}&language={{0}}&page={{1}}&query={{2}}";

		public static readonly string SEARCH_MOVIES_URL = string.Format(SEARCH_MOVIES_BASE_URL, DEFAULT_LANGUAGE, 1, "{0}");
	}
}

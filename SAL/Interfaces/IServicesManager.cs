using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using BLL.Models;

namespace SAL.Interfaces
{
	public interface IServicesManager
	{
		Task<IEnumerable<MovieGroup>> GetMovieGroupsAsync();

		Task<IEnumerable<MovieGroup>> GetMovieGroupsAsync(Action<MovieGroup> onEachMovieGroupCallback);

		Task<IEnumerable<Movie>> GetSimilarMovies(int movieId);

		Task<IEnumerable<Movie>> SearchMovies(string query, int searchLimit);
	}
}

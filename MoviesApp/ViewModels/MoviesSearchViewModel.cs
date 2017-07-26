using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

using MvvmCross.Core.ViewModels;

using SAL.Interfaces;
using MoviesApp.Core.ViewModelWrappers;
using BLL.ExtensionMethods;
using BLL.Models;

namespace MoviesApp.Core.ViewModels
{
	public class MoviesSearchViewModel : ViewModel
	{
		#region Constants

		private static readonly int SEARCH_LIMIT = 6;

		#endregion
		
		#region Bindable properties

		private ObservableCollection<MoviesSearchResultWrapper> _moviesSearchResults;
		public ObservableCollection<MoviesSearchResultWrapper> MoviesSearchResults
		{
			get { return _moviesSearchResults; }
			set { _moviesSearchResults = value; RaisePropertyChanged(() => MoviesSearchResults); }
		}

		private bool _isSearching;
		public bool IsSearching
		{
			get { return _isSearching; }
			set { _isSearching = value; RaisePropertyChanged(() => IsSearching); }
		}

		private ICommand _searchMoviesCommand;
		public ICommand SearchMoviesCommand
		{
			get
			{
				return _searchMoviesCommand = _searchMoviesCommand ?? new MvxCommand<string>(async query =>
				{
					try
					{
						if (string.IsNullOrEmpty(query))
						{
							IsSearching = false;
							MoviesSearchResults = new ObservableCollection<MoviesSearchResultWrapper>();
							return;
						}

						IsSearching = true;
						
						var moviesSearchResults = await _servicesManager.SearchMovies(query, SEARCH_LIMIT);
						
						var moviesSearchResultsWrappers = moviesSearchResults.Select(m => new MoviesSearchResultWrapper
						{
							Id = m.Id,
							Title = m.Title,
							Overview = m.Overview,
							PosterPath = m.PosterPath,
							ReleaseDate = m.ReleaseDate,
							OnMovieSelected = () => ShowViewModel<MovieDetailViewModel>(m)
						});
						
						MoviesSearchResults = new ObservableCollection<MoviesSearchResultWrapper>(moviesSearchResultsWrappers);
					}
					catch (Exception ex)
					{
						// Handle exception.
					}
					finally
					{
						await Task.Delay(500);
						IsSearching = false;
					}
				});
			}
		}

		#endregion

		#region Constructors

		public MoviesSearchViewModel(IServicesManager servicesManager) : base(servicesManager)
		{
			
		}

		#endregion
	}
}

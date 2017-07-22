using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using MvvmCross.Core.ViewModels;

using BLL.Models;
using SAL.Interfaces;

namespace MoviesApp.Core.ViewModels
{
	public class MoviesSearchViewModel : ViewModel
	{
		#region Bindable properties

		private ObservableCollection<Movie> _filteredMovies;
		public ObservableCollection<Movie> FilteredMovies
		{
			get { return _filteredMovies; }
			set { _filteredMovies = value; RaisePropertyChanged(() => FilteredMovies); }
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
						var filteredMovies = await _servicesManager.SearchMovies(query);
						FilteredMovies = new ObservableCollection<Movie>(filteredMovies);
					}
					catch (Exception ex)
					{
						// Handle exception.
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

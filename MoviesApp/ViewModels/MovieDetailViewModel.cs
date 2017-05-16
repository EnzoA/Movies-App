using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using BLL.Models;
using MvvmCross.Core.ViewModels;
using SAL.Interfaces;

namespace MoviesApp.Core.ViewModels
{
	public class MovieDetailViewModel : ViewModel
	{
		#region Bindable properties

		private Movie _selectedMovie;
		public Movie SelectedMovie
		{
			get { return _selectedMovie; }
			set { _selectedMovie = value; RaisePropertyChanged(() => SelectedMovie); }
		}

		private ObservableCollection<Movie> _similarMovies;
		public ObservableCollection<Movie> SimilarMovies
		{
			get { return _similarMovies; }
			set { _similarMovies = value; RaisePropertyChanged(() => SimilarMovies); }
		}

		private bool _isBusy;
		public bool IsBusy
		{
			get { return _isBusy; }
			set { _isBusy = value; RaisePropertyChanged(() => IsBusy); }
		}

		private bool _hasThrownError;
		public bool HasThrownError
		{
			get { return _hasThrownError; }
			set { _hasThrownError = value; RaisePropertyChanged(() => HasThrownError); }
		}

		private string _errorMessage;
		public string ErrorMessage
		{
			get { return _errorMessage; }
			set { _errorMessage = value; RaisePropertyChanged(() => ErrorMessage); }
		}

		private ICommand _selectFirstMovieCommand;
		public ICommand SelectFirstMovieCommand
		{
			get
			{
				return _selectFirstMovieCommand = _selectFirstMovieCommand ?? new MvxCommand(() => SelectMovie(movieIndex: 0));
			}
		}

		private ICommand _selectSecondMovieCommand;
		public ICommand SelectSecondMovieCommand
		{
			get
			{
				return _selectSecondMovieCommand = _selectSecondMovieCommand ?? new MvxCommand(() => SelectMovie(movieIndex: 1));
			}
		}

		private ICommand _selectThirdMovieCommand;
		public ICommand SelectThirdMovieCommand
		{
			get
			{
				return _selectThirdMovieCommand = _selectThirdMovieCommand ?? new MvxCommand(() => SelectMovie(movieIndex: 2));
			}
		}

		#endregion

		#region Constructors

		public MovieDetailViewModel(IServicesManager servicesManager) : base(servicesManager)
		{
			
		}

		#endregion

		#region Public methods

		public void Init(Movie selectedMovie)
		{
			SelectedMovie = selectedMovie;
			LoadSimilarMovies();
		}

		#endregion

		#region Private methods

		private async void LoadSimilarMovies()
		{
			IsBusy = true;
			ErrorMessage = string.Empty;
			HasThrownError = false;

			try
			{
				var similarMovies = await _servicesManager.GetSimilarMovies(SelectedMovie.Id);
				if (similarMovies != null && similarMovies.Any())
				{
					SimilarMovies = new ObservableCollection<Movie>(similarMovies);
				}
			}
			catch (Exception)
			{
				ErrorMessage = "An error has occurred while loading the similar movies"; // TODO: Use a Resx file
				HasThrownError = true;
			}
			finally
			{
				IsBusy = false;
			}
		}
		
		private void SelectMovie(int movieIndex)
		{
			if (SimilarMovies != null && SimilarMovies.Count() >= movieIndex + 1)
			{
				var selectedMovie = SimilarMovies.ElementAt(movieIndex);
				ShowViewModel<MovieDetailViewModel>(selectedMovie);
			}
		}
		
		#endregion
	}
}

using System;
using System.Linq;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using BLL.Models;

namespace MoviesApp.Core.ViewModelWrappers
{
	public class MovieGroupWrapper : MovieGroup
	{
		#region Private fields

		private Action<int> _onMovieSelectedCallback;

		#endregion

		#region Constructors

		public MovieGroupWrapper(MovieGroup movieGroup, Action<int> onMovieSelectedCallback)
		{
			GroupName = movieGroup?.GroupName;
			Movies = movieGroup?.Movies;
			_onMovieSelectedCallback = onMovieSelectedCallback;	
		}

		#endregion

		#region Commands

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

		#region Private methods

		private void SelectMovie(int movieIndex)
		{
			if (Movies != null && Movies.Count() >= movieIndex + 1)
			{
				var movieId = Movies.ElementAt(movieIndex).Id;
				_onMovieSelectedCallback?.Invoke(movieId);
			}
		}

		#endregion
	}
}

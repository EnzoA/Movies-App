using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using BLL.Models;

namespace MoviesApp.Core.ViewModelWrappers
{
	public class MovieGroupWrapper : MovieGroup
	{
		#region Constructors

		public MovieGroupWrapper()
		{

		}

		public	MovieGroupWrapper(MovieGroup movieGroup)
		{
			GroupName = movieGroup?.GroupName;
			Movies = movieGroup?.Movies;
		}

		#endregion

		#region Commands

		private ICommand _goToFirstMovieDetailCommand;
		public ICommand GoToFirstMovieDetailCommand
		{
			get
			{
				return _goToFirstMovieDetailCommand = _goToFirstMovieDetailCommand ?? new MvxCommand(() =>
				{
					
				});
			}
		}

		private ICommand _goToSecondMovieDetailCommand;
		public ICommand GoToSecondMovieDetailCommand
		{
			get
			{
				return _goToSecondMovieDetailCommand = _goToSecondMovieDetailCommand ?? new MvxCommand(() =>
				{
					
				});
			}
		}

		private ICommand _goToThirdMovieDetailCommand;
		public ICommand GoToThirdMovieDetailCommand
		{
			get
			{
				return _goToThirdMovieDetailCommand = _goToThirdMovieDetailCommand ?? new MvxCommand(() =>
				{

				});
			}
		}

		#endregion
	}
}

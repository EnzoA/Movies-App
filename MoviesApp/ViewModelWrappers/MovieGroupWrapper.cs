using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using BLL.Models;

namespace MoviesApp.Core.ViewModelWrappers
{
	public class MovieGroupWrapper : MovieGroup
	{
		private ICommand _goToMovieDetailCommand;
		public ICommand GoToMovieDetailCommand
		{
			get
			{
				return _goToMovieDetailCommand = _goToMovieDetailCommand ?? new MvxCommand(() =>
				{

				});
			}
		}
	}
}

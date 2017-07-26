using System;
using System.Windows.Input;

using MvvmCross.Core.ViewModels;

using BLL.Models;

namespace MoviesApp.Core.ViewModelWrappers
{
	public class MoviesSearchResultWrapper : Movie
	{
		#region Public properties

		public Action OnMovieSelected { get; set; }

		#endregion

		#region Commands

		private ICommand _selectMovieCommand;
		public ICommand SelectMovieCommand
		{
			get
			{
				return _selectMovieCommand = _selectMovieCommand ?? new MvxCommand(() => OnMovieSelected?.Invoke());
			}
		}

		#endregion
	}
}

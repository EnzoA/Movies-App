using System;
using System.Windows.Input;

using static Android.Support.V7.Widget.SearchView;

namespace MoviesApp.Droid.SearchableConfiguration
{
	public class MoviesSearchOnQueryTextListener : Java.Lang.Object, IOnQueryTextListener
	{
		private ICommand _searchMoviesCommand;

		public MoviesSearchOnQueryTextListener(ICommand searchMoviesCommand)
		{
			_searchMoviesCommand = searchMoviesCommand;
		}
		
		public bool OnQueryTextChange(string newText)
		{
			_searchMoviesCommand.Execute(newText);
			return true;
		}

		public bool OnQueryTextSubmit(string query)
		{
			return true;
		}
	}
}
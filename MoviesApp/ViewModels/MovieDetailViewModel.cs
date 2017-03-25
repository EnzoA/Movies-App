using BLL.Models;
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
		}

		#endregion
	}
}

using SAL.Interfaces;

namespace MoviesApp.Core.ViewModels
{
	public class MovieDetailViewModel : ViewModel
	{
		#region Private fields

		private int _movieId;

		#endregion
		
		#region Constructor

		public MovieDetailViewModel(IServicesManager servicesManager) : base(servicesManager)
		{
			
		}

		#endregion

		#region Public methods

		public void Init(int movieId)
		{
			_movieId = movieId;
		}

		#endregion
	}
}

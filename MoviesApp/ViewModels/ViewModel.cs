using MvvmCross.Core.ViewModels;
using SAL.Interfaces;

namespace MoviesApp.Core.ViewModels
{
	public abstract class ViewModel : MvxViewModel
	{
		protected IServicesManager _servicesManager;

		public ViewModel(IServicesManager servicesManager)
		{
			_servicesManager = servicesManager;
		}
	}
}

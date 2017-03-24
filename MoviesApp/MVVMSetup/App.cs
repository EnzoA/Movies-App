using MoviesApp.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using SAL;
using SAL.Interfaces;
using SAL.ServicesImplementations;

namespace MoviesApp.Core.MVVMSetup
{
	public class App : MvxApplication
	{
		public async override void Initialize()
		{
			RegisterAppStart<HomeViewModel>();
			Mvx.RegisterType(typeof(IHttpClient), typeof(HttpClientImpl));
			Mvx.ConstructAndRegisterSingleton<IServicesManager, ServicesManager>();
			await TMDbApiConfig.InitializeAsync(Mvx.Resolve<IHttpClient>());
		}
	}
}

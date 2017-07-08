using Android.Content;
using MvvmCross.Core.ViewModels;
using MoviesApp.Core.MVVMSetup;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace MoviesApp.Droid
{
	public class Setup : MvxAppCompatSetup
	{
		public Setup(Context applicationContext) : base(applicationContext)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}
	}
}
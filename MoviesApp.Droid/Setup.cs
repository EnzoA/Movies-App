using Android.Content;

using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

using MoviesApp.Core.MVVMSetup;

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
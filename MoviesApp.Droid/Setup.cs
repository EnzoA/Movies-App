using Android.Content;
using MoviesApp.Core.MVVMSetup;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;

namespace MoviesApp.Droid
{
	public class Setup : MvxAndroidSetup
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
using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace MoviesApp.Droid.Activities
{
	[Activity(Label = "Movies App",
			  Theme = "@style/SplashTheme",
			  MainLauncher = true,
			  NoHistory = true,
			  ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class SplashActivity : MvxSplashScreenActivity
	{
		
	}
}
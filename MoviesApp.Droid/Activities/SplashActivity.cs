using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace MoviesApp.Droid.Activities
{
	[Activity(Label = "Movies App",
			  Theme = "@style/SplashTheme",
			  MainLauncher = true,
			  NoHistory = true,
			  ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class SplashActivity : MvxSplashScreenAppCompatActivity
	{
		
	}
}
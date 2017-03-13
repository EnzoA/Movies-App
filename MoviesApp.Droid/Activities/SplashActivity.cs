using Android.App;
using Android.OS;
using Android.Content;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace MoviesApp.Droid.Activities
{
	[Activity(Label = "Movies App",
			  Theme = "@style/SplashTheme",
			  MainLauncher = true,
			  NoHistory = true,
			  ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class SplashActivity : MvxActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
		}

		protected override void OnResume()
		{
			base.OnResume();

			var setup = new Setup(this);

			StartActivity(new Intent(Application.Context, typeof(HomeActivity)));
		}
	}
}
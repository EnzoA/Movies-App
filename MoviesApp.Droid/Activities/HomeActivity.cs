using Android.App;
using Android.OS;
using MoviesApp.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace MoviesApp.Droid.Activities
{
	[Activity(Label = "Movies App",
			  Icon = "@drawable/icon",
			  Theme = "@style/MoviesAppTheme")]
	public class HomeActivity : MvxAppCompatActivity
	{
		public new HomeViewModel ViewModel
		{
			get { return (HomeViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView (Resource.Layout.home);
		}
	}
}
using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using MoviesApp.Core.ViewModels;

namespace MoviesApp.Droid.Activities
{
	[Activity(Label = "Movies App",
			  Icon = "@drawable/icon",
			  Theme = "@style/MoviesAppTheme")]
	public class HomeActivity : MvxActivity
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
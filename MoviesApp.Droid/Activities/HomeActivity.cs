using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using MoviesApp.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace MoviesApp.Droid.Activities
{
	[Activity(Icon = "@drawable/icon",
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
			var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.app_menu, menu);
			return base.OnCreateOptionsMenu(menu);
		}
	}
}
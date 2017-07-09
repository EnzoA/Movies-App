using Android.App;
using Android.OS;
using Android.Views;
using Android.Support.V7.Widget;
using MoviesApp.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace MoviesApp.Droid.Activities
{
	[Activity(Label = "Movie detail",
			  Theme = "@style/MoviesAppTheme")]
	public class MovieDetailActivity : MvxAppCompatActivity
	{
		public new MovieDetailViewModel ViewModel
		{
			get { return (MovieDetailViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.movie_detail);
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
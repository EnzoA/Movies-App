using Android.App;
using Android.OS;
using MoviesApp.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace MoviesApp.Droid.Activities
{
	[Activity(Label = "Movie detail",
			  Theme = "@android:style/Theme.Material")]
	public class MovieDetailActivity : MvxActivity
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
		}
	}
}
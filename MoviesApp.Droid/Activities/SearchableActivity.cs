using Android.App;
using Android.Content.PM;
using Android.OS;

using MvvmCross.Droid.Support.V7.AppCompat;

namespace MoviesApp.Droid.Activities
{
	[Activity(LaunchMode = LaunchMode.SingleTop, ScreenOrientation = ScreenOrientation.Portrait)]
	[IntentFilter(new[] { Android.Content.Intent.ActionSearch })]
	[MetaData("android.app.searchable", Resource = "@xml/searchable")]
	public class SearchableActivity : MvxAppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
		}
	}
}
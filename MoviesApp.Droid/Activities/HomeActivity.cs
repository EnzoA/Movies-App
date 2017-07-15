using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using MoviesApp.Core.ViewModels;

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
			
			// Set the toolbar as the action bar.
			var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			// Inflate the menu.
			MenuInflater.Inflate(Resource.Menu.app_menu, menu);

			// Get the search menu item and set the searchable configuration.
			var searchManager = (SearchManager)GetSystemService(SearchService);
			var componentName = new ComponentName(this, Java.Lang.Class.FromType(typeof(SearchableActivity)));
			var searchItem = menu.FindItem(Resource.Id.menu_search);
			var searchView = (SearchView)Android.Support.V4.View.MenuItemCompat.GetActionView(searchItem);
			searchView.SetSearchableInfo(searchManager.GetSearchableInfo(componentName));

			return base.OnCreateOptionsMenu(menu);
		}
	}
}
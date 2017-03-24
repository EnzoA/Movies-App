using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace MoviesApp.Droid.Activities
{
	[Activity(Label = "Movie detail")]
	public class MovieDetailActivity : MvxActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.movie_detail);
		}
	}
}
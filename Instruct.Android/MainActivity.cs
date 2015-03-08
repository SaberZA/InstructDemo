using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Instruct.Core;

namespace Instruct.Android
{
    [Activity(Label = "Instruct.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ListView _listView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            _listView = FindViewById<ListView>(Resource.Id.listViewMovies);

            LoadMovies();
        }

        private async void LoadMovies()
        {
            var movieService = new MovieService();
            var movieList = await movieService.GetTop100MoviesOfAllTime();
            var listAdapter = new ArrayAdapter<String>(this, global::Android.Resource.Layout.SimpleListItem1, movieList.Movies);
            _listView.Adapter = listAdapter;
        }
    }
}


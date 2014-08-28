﻿using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Parse;
using System.Collections.Generic;

namespace BookFace
{
	[Activity (Label = "BookFace", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, ListView.IOnItemClickListener
	{
		ListView listView;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Initialize parse
			ParseObject.RegisterSubclass<User>();
			ParseClient.Initialize("TlBHwmKpW4Un35ahy9vWpO8Th01ngQZ5Rg0wEqvc",
				"Ql8f77K7n5TryGtVxAyMYrHnItqYAAujzqnY9XQ7");

			// Initialize view
			SetContentView (Resource.Layout.Main);
			listView = FindViewById<ListView> (Resource.Id.listView);
			listView.OnItemClickListener = this;

			poopie ();
		}

		private async void poopie ()
		{
			var query = new ParseQuery<User> ();
			IEnumerable<User> result = await query.FindAsync ();
			var userList = new List<User> (result);
			listView.Adapter = new UserAdapter (this, userList.ToArray());
		}

		protected override void OnResume () 
		{
			base.OnResume ();


		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.ActionBar, menu);
			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
			case Resource.Id.action_add_user:
				StartActivity(typeof(AddActivity));
				break;
			}
			return base.OnOptionsItemSelected(item);
		}

		#region OnItemClickListener

		public void OnItemClick (AdapterView parent, View view, int position, long id)
		{
			// TODO:Respond to row press 
		}

		#endregion
	}
}



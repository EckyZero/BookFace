﻿using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Parse;
using System.Collections.Generic;
using Newtonsoft.Json;
using Java.IO;

namespace BookFace
{
	[Activity (Label = "BookFace", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, ListView.IOnItemClickListener
	{
		ListView listView;
		User[] users;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Initialize parse
			ParseObject.RegisterSubclass<User>();
			ParseClient.Initialize("TlBHwmKpW4Un35ahy9vWpO8Th01ngQZ5Rg0wEqvc",
				"Ql8f77K7n5TryGtVxAyMYrHnItqYAAujzqnY9XQ7");

			// Initialize view
			SetContentView (Resource.Layout.Main);
<<<<<<< HEAD
			var layout = FindViewById<ScrollView> (Resource.Id.scrollView1);
			listView = new PullDownListView(this);
			//SetContentView (listView);
			listView.OnItemClickListener = this;
			listView.mPulledDownListDelegate = delegate {
				Console.WriteLine("PULLLED DOWN!!!!");
				sync();
			};
			layout.AddView (listView);
=======
			listView = FindViewById<ListView> (Resource.Id.listView);
			listView.OnItemClickListener = this;

>>>>>>> origin/master
			sync ();
		}

		private async void sync ()
		{
			DateTime date = DateTime.Now;
			Console.WriteLine ("entered async");
			var query = new ParseQuery<User> ();
			IEnumerable<User> result = await query.FindAsync ();
<<<<<<< HEAD
		
			var userList = new List<User> (result);
			listView.Adapter = new UserAdapter (this, userList.ToArray());
		//	listView.SmoothScrollToPosition (4);
			TimeSpan time = DateTime.Now - date;
			Console.WriteLine ("left async "+ time.Milliseconds);

		}

		protected override void OnResume () 
		{
			base.OnResume ();


=======
			users = new List<User> (result).ToArray();
			listView.Adapter = new UserAdapter (this, users);
>>>>>>> origin/master
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
			case Resource.Id.action_sync:
				sync ();
				break;
			}
			return base.OnOptionsItemSelected(item);
		}

		#region OnItemClickListener

		public void OnItemClick (AdapterView parent, View view, int position, long id)
		{
			User user = users [position];
			Intent intent = new Intent (this, typeof(ProfileActivity));

			intent.PutExtra ("User", user.ObjectId);

			StartActivity (intent);
		}

		#endregion
	}
}



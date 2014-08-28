using System;

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
			listView = FindViewById<ListView> (Resource.Id.listView);
			listView.OnItemClickListener = this;

			sync ();
		}

		private async void sync ()
		{
			var query = new ParseQuery<User> ();
			IEnumerable<User> result = await query.FindAsync ();
			users = new List<User> (result).ToArray();
			listView.Adapter = new UserAdapter (this, users);
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



using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace BookFace
{
	[Activity (Label = "BookFace", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, ListView.IOnItemClickListener
	{
		User[] users = new User[]{};

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			User user = new User (null, "Hans Stegemoeller");
			users = new User[]{ user };

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			ListView listView = FindViewById<ListView> (Resource.Id.listView);

			listView.OnItemClickListener = this;
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



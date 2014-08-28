using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Parse;

namespace BookFace
{
	[Activity (Label = "BookFace", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, ListView.IOnItemClickListener
	{
		User[] users = new User[]{};

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			ParseObject.RegisterSubclass<User>();
			ParseClient.Initialize("TlBHwmKpW4Un35ahy9vWpO8Th01ngQZ5Rg0wEqvc",
				"Ql8f77K7n5TryGtVxAyMYrHnItqYAAujzqnY9XQ7");



			//var user = new ParseUser()
			//{
			//	Username = "Daniel103",
			//	Password = "1234",
			//	Email = "daniel103@gmail.com"
			//};

			// other fields can be set just like with ParseObject
			//user["phone"] = "415-392-0202";

			//await user.SignUpAsync();

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			ListView listView = FindViewById<ListView> (Resource.Id.listView);
			Console.WriteLine ("HELLO HANS!!!!!");

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



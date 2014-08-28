
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System.Net;
using Android.Graphics;
using Parse;

namespace BookFace
{
	[Activity (Label = "ProfileActivity")]			
	public class ProfileActivity : Activity
	{
		ImageView imageView;
		TextView nameTextView;
		User user;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Grab UI Elements
			SetContentView (Resource.Layout.profile_activity);
			imageView = FindViewById<ImageView> (Resource.Id.imageView);
			nameTextView = FindViewById<TextView> (Resource.Id.nameTextView);

			// Grab User data
			GetUser (Intent.GetStringExtra ("User"));
		}

		private async void GetUser(string objectId)
		{
//			ParseQuery<ParseObject> query = ParseUser.GetQuery("_User");
			user = (User)await ParseUser.Query.GetAsync(objectId);
//			var query = ParseUser.GetQuery ("_User").WhereEqualTo ("objectId", objectId);
//			var query = ParseObject.GetQuery ("User")
//				.WhereEqualTo ("objectId", objectId);
//			var query = new ParseQuery<User> ();
//			query.WhereEqualTo ("objectId", objectId);
//			user = await query.FirstAsync();

			WebClient webClient = new WebClient ();
			byte[] bytes = webClient.DownloadData (user.Photo.Url);
			Bitmap bitmap = BitmapFactory.DecodeByteArray (bytes, 0, bytes.Length);

			// Set UI Values
			nameTextView.Text = user.Name;
			imageView.SetImageBitmap (bitmap);
		}
	}
}


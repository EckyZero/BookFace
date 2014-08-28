using System;
using Android.App;
using Android.Widget;
using Parse;
using System.IO;
using System.ComponentModel;
using Android.Graphics;
using System.Net;

namespace BookFace
{
	public class UserAdapter : BaseAdapter
	{
		User[] users;
		Activity activity;

		public UserAdapter (Activity activity, User[] users)
		{
			this.activity = activity;
			this.users = users;
		}

		#region implemented abstract members of BaseAdapter

		public override Java.Lang.Object GetItem (int position)
		{
			return null;
		}

		public override long GetItemId (int position)
		{
			return 0;
		}

		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			User user = users [position];
			ParseFile photo = user.Photo;
			var view = activity.LayoutInflater.Inflate (Resource.Layout.UserCell, parent, false);
			TextView nameLabel = view.FindViewById<TextView> (Resource.Id.nameTextView);
			ImageView imageView = view.FindViewById<ImageView> (Resource.Id.photoImageView);
			WebClient webClient = new WebClient ();
			byte[] bytes = webClient.DownloadData (photo.Url);
			Bitmap bitmap = BitmapFactory.DecodeByteArray (bytes, 0, bytes.Length);

			imageView.SetImageBitmap (bitmap);
			nameLabel.Text = user.Name;

			return view;
		}

		public override int Count {
			get {
				return users.Length;
			}
		}

		#endregion
	}
}


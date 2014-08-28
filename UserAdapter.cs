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
			ImageView imageView = view.FindViewById<ImageView> (Resource.Id.photoImageView);
			TextView nameLabel = view.FindViewById<TextView> (Resource.Id.nameTextView);
			GetImage (imageView, photo.Url);
			nameLabel.Text = user.Name;

			return view;
		}

		public void GetImage(ImageView imageView, Uri url) {
	
			WebClient webClient = new WebClient ();
	
			webClient.DownloadDataCompleted += delegate(object e, DownloadDataCompletedEventArgs data) {
				if(data.Error == null) {
				byte[] bytes = data.Result;
				Bitmap bitmap = BitmapFactory.DecodeByteArray (bytes, 0, bytes.Length);
					Console.WriteLine("SIZE OF FILE: "+bytes.Length);
				imageView.SetImageBitmap (bitmap);
				}

			};
		//	webClient.do
	
			Console.WriteLine ("Going to d/l " + url.AbsolutePath);
			webClient.DownloadDataAsync (url);
	
		}
		public override int Count {
			get {
				return users.Length;
			}
		}

		#endregion
	}
}


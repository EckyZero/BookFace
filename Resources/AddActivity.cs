
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Provider;
using Android.Graphics;
using Java.IO;

using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;
using Android.Media;

using System.Drawing;

namespace BookFace
{
	public static class App{
		public static File _file;
		public static File _dir;     
		public static Bitmap bitmap;
	}

	[Activity (Label = "AddActivity")]			
	public class AddActivity : Activity
	{
		private ImageButton button;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.add_layout);

			if (IsThereAnAppToTakePictures())
			{
				CreateDirectoryForPictures();

				button = FindViewById<ImageButton>(Resource.Id.imageButton);
				if (App.bitmap != null) {
					button.SetImageBitmap (App.bitmap);
					App.bitmap = null;
				}
				button.Click += TakeAPicture;
			}
		}

		private bool IsThereAnAppToTakePictures()
		{
			Intent intent = new Intent(MediaStore.ActionImageCapture);
			IList<ResolveInfo> availableActivities = PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
			return availableActivities != null && availableActivities.Count > 0;
		}

		private void CreateDirectoryForPictures()
		{
			App._dir = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures), "CameraAppDemo");
			if (!App._dir.Exists())
			{
				App._dir.Mkdirs();
			}
		}

		private void TakeAPicture(object sender, EventArgs eventArgs)
		{
			Intent intent = new Intent(MediaStore.ActionImageCapture);

			App._file = new File(App._dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));

			intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(App._file));

			StartActivityForResult(intent, 0);
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);

			// make it available in the gallery
			Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
			Uri contentUri = Uri.FromFile(App._file);
			mediaScanIntent.SetData(contentUri);
			SendBroadcast(mediaScanIntent);

			// display in ImageView. We will resize the bitmap to fit the display
			// Loading the full sized image will consume to much memory 
			// and cause the application to crash.
			int height = Resources.DisplayMetrics.HeightPixels;
			int width = button.Width ;
			App.bitmap = App._file.Path.LoadAndResizeBitmap (width, height);

			button.SetImageBitmap (App.bitmap);
		}
	}
}


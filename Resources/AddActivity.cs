
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

namespace BookFace
{
	[Activity (Label = "AddActivity")]			
	public class AddActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.add_layout);
			FindViewById<ImageButton> (Resource.Id.imageButton);
		}
	}
}


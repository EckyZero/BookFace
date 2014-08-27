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
using Parse;

namespace BookFace
{
	[Application]
	public class ParseApp : Application
	{
		public ParseApp (IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{
		}

		public override void OnCreate ()
		{
			base.OnCreate ();
			Console.WriteLine ("PARSE WAS INITIATED!!!!!");
			// Initialize the parse client with your Application ID and .NET Key found on
			// your Parse dashboard
			ParseClient.Initialize("TlBHwmKpW4Un35ahy9vWpO8Th01ngQZ5Rg0wEqvc",
				"Ql8f77K7n5TryGtVxAyMYrHnItqYAAujzqnY9XQ7");
		}
	}
}


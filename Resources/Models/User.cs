using System;
using Android.Media;

namespace BookFace
{
	public class User
	{
		public Image photo;
		public string name;

		public User (Image photo, string name)
		{
			this.photo = photo;
			this.name = name;
		}
	}
}


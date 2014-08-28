using System;
using Parse;
using System.Runtime.Serialization;

namespace BookFace
{
	public class User : ParseUser
	{
		[ParseFieldName("username")]
		public string Name {
			get { return GetProperty<string> (); }
			set { SetProperty<string> (value); }
		}

		[ParseFieldName("photo")]
		public ParseFile Photo {
			get { return GetProperty<ParseFile> (); }
			set { SetProperty<ParseFile> (value); }
		}
	}
}


using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Utilities
{
	public class Language
	{
		public string Name { get; set; }
		public string Tag { get; set; }

		public Language( string name, string tag )
		{
			Name = name;
			Tag = tag;
		}
		public override string ToString() => Name;
	}
}

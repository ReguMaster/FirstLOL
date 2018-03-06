using System;

namespace Tester.Attribute
{
	[AttributeUsage( AttributeTargets.Method )]
	public class Ddragon : System.Attribute
	{
		public double VERSION;

		public Ddragon( )
		{
			this.VERSION = 1.0;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLFirstPick
{
	public static class GlobalVar
	{
		public static readonly string APP_DIR;
		public static string SCRIPT;

		static GlobalVar( )
		{
			APP_DIR = System.Windows.Forms.Application.StartupPath;
		}
	}
}

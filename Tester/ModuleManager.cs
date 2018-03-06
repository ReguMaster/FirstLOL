using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace Tester
{
	public static class ModuleManager
	{
		private const string Location = @"D:\Dropbox\Dev\C#-2\LOLFirstPick\Tester\bin\Debug\champions"; // TODO : 수정

		static ModuleManager( )
		{

		}

		public static void CheckChampionSquare( )
		{
			if ( Directory.Exists( ModuleManager.Location ) )
				Directory.CreateDirectory( ModuleManager.Location );

			WebClient webClient = new WebClient( );
			string[ ] squareFiles = Directory.GetFiles( ModuleManager.Location, "*.png" );

			//byte[ ] data = webClient.DownloadData( new Uri( "http://ddragon.leagueoflegends.com/cdn/" + clientVersion + "/img/champion/" + imageJSON[ "full" ].GetValue( ).ToString( ) ) );
		}
	}
}

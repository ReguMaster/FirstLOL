using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Json;
using System.Net;
using System.IO;
using Tester.Attribute;

namespace Tester
{
	public static class RiotAPI
	{
		private const string VersionURL = "https://ddragon.leagueoflegends.com/api/versions.json";
		private const string ChampionListURL = "http://ddragon.leagueoflegends.com/cdn/{0}/data/{1}/champion.json";

		[Ddragon( VERSION = 1.0 )]
		public static JsonObject[ ] GetClientVersions( )
		{
			HttpWebRequest request = ( HttpWebRequest ) WebRequest.Create( RiotAPI.VersionURL );
			request.Method = "GET";
			request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
			request.Timeout = 10000;

			using ( WebResponse res = request.GetResponse( ) )
			{
				using ( Stream responseStream = res.GetResponseStream( ) )
				{
					using ( StreamReader reader = new StreamReader( responseStream, Encoding.UTF8 ) )
					{
						string json = reader.ReadToEnd( );

						JsonArrayCollection jsonCollection = ( JsonArrayCollection ) ( new JsonTextParser( ) ).Parse( json );

						return jsonCollection.ToArray<JsonObject>( );
					}
				}
			}
		}

		[Ddragon( VERSION = 1.0 )]
		public static string GetLatestClientVersion( )
		{
			HttpWebRequest request = ( HttpWebRequest ) WebRequest.Create( RiotAPI.VersionURL );
			request.Method = "GET";
			request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
			request.Timeout = 10000;

			using ( WebResponse res = request.GetResponse( ) )
			{
				using ( Stream responseStream = res.GetResponseStream( ) )
				{
					using ( StreamReader reader = new StreamReader( responseStream, Encoding.UTF8 ) )
					{
						string json = reader.ReadToEnd( );

						JsonArrayCollection jsonCollection = ( JsonArrayCollection ) ( new JsonTextParser( ) ).Parse( json );

						return jsonCollection[ 0 ].GetValue( ).ToString( );
					}
				}
			}
		}

		[Ddragon( VERSION = 1.0 )]
		public static string[ ] GetChampionIDList( string clientVersion = "", string language = "ko_KR" )
		{
			if ( clientVersion.Equals( string.Empty ) )
				clientVersion = GetLatestClientVersion( );

			HttpWebRequest request = ( HttpWebRequest ) WebRequest.Create( string.Format( RiotAPI.ChampionListURL, clientVersion, language ) );
			request.Method = "GET";
			request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
			request.Timeout = 10000;

			using ( WebResponse res = request.GetResponse( ) )
			{
				using ( Stream responseStream = res.GetResponseStream( ) )
				{
					using ( StreamReader reader = new StreamReader( responseStream, Encoding.UTF8 ) )
					{
						string json = reader.ReadToEnd( );

						JsonObjectCollection jsonCollection = ( JsonObjectCollection ) ( new JsonTextParser( ) ).Parse( json );
						JsonObjectCollection dataList = ( JsonObjectCollection ) jsonCollection[ "data" ];
						string[ ] result = new string[ dataList.Count ];
						int count = 0;

						foreach ( JsonObject i in dataList )
							result[ count++ ] = i.Name;

						return result;
					}
				}
			}
		}
	}
}

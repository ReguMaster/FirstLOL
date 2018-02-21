using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Json;
using System.Windows.Forms;
using System.Collections;

namespace LOLFirstPick.Lib
{
	static class ChampionInitialize
	{
		public static void CheckVersion( Action<string> WorkMessageReceiver )
		{
			Hashtable savedChampionSquareHash = new Hashtable( );
			Hashtable webChampionSquareHash = new Hashtable( );
			List<string> errorChampionName = new List<string>( );
			string championSquareDir = GlobalVar.APP_DIR + @"\champions";

			if ( !Directory.Exists( championSquareDir ) )
			{
				Directory.CreateDirectory( GlobalVar.APP_DIR + @"\champions" );
			}

			string[ ] files = Directory.GetFiles( championSquareDir, "*.png" );

			foreach ( string fileName in files )
			{
				//System.Threading.Thread.Sleep( 5 );

				savedChampionSquareHash[ Path.GetFileNameWithoutExtension( fileName ) ] = Utility.GetMD5Hash( fileName ).ToString( ).Trim( );

				//WorkMessageReceiver.Invoke( "저장된 챔피언 '" + Path.GetFileNameWithoutExtension( fileName ) + "' 무결성 검사 시작 중 ..." );
			}

			try
			{
				string url = "https://kr.api.riotgames.com/lol/static-data/v3/champions?locale=ko_KR&tags=image&dataById=false&api_key=RGAPI-cd03e729-93dc-4694-8476-43f2f1cbf153";
				HttpWebRequest request = ( HttpWebRequest ) WebRequest.Create( url );
				request.Method = "GET";    // 기본값 "GET"

				using ( HttpWebResponse response = ( HttpWebResponse ) request.GetResponse( ) )
				{
					using ( Stream responseStream = response.GetResponseStream( ) )
					{
						using ( StreamReader reader = new StreamReader( responseStream, Encoding.UTF8 ) )
						{
							JsonObjectCollection topJSON = ( JsonObjectCollection ) new JsonTextParser( ).Parse( reader.ReadToEnd( ) );
							JsonObjectCollection dataJSON = ( JsonObjectCollection ) topJSON[ "data" ];

							string clientVersion = topJSON[ "version" ].GetValue( ).ToString( );

							//http://ddragon.leagueoflegends.com/cdn/6.24.1/img/champion/Aatrox.png

							WebClient cl = new WebClient( );


							foreach ( JsonObject i in dataJSON )
							{
								System.Threading.Thread.Sleep( 20 );

								JsonObjectCollection itemJSON = ( JsonObjectCollection ) i;
								JsonObjectCollection imageJSON = ( JsonObjectCollection ) itemJSON[ "image" ];

								WorkMessageReceiver.Invoke( "챔피언 '" + itemJSON[ "name" ].GetValue( ).ToString( ) + "' 서버에 요청 중 ..." );

								//http://ddragon.leagueoflegends.com/cdn/" + clientVersion + "/img/champion/" + imageJSON[ "full" ].GetValue( ).ToString( )

								cl.DownloadFileCompleted += ( e, d ) =>
								{
									WorkMessageReceiver.Invoke( "챔피언 '" + itemJSON[ "name" ].GetValue( ).ToString( ) + "' 서버 요청 완료." );
								};

								byte[ ] data = cl.DownloadData( new Uri( "http://ddragon.leagueoflegends.com/cdn/" + clientVersion + "/img/champion/" + imageJSON[ "full" ].GetValue( ).ToString( ) ) );

								string key = itemJSON[ "key" ].GetValue( ).ToString( );
								string name = itemJSON[ "name" ].GetValue( ).ToString( );

								WorkMessageReceiver.Invoke( "챔피언 '" + name + "' - 파일 검사 중 ..." );

								if ( savedChampionSquareHash[ name ] == null )
								{
									DownloadSpecificChampionSquare( key, name, WorkMessageReceiver );
								}
								else
								{
									if ( Utility.GetMD5Hash( data ).ToString( ).Trim( ).Equals( savedChampionSquareHash[ name ] ) )
									{
										WorkMessageReceiver.Invoke( "챔피언 '" + name + "' - 파일에 문제가 없습니다." );
									}
									else
									{
										WorkMessageReceiver.Invoke( "챔피언 '" + name + "' - 파일 문제를 발견했습니다." );

										System.Threading.Thread.Sleep( 1000 );

										DownloadSpecificChampionSquare( key, name, WorkMessageReceiver );
									}
								}

								//webChampionSquareHash[ Path.GetFileNameWithoutExtension(  ] = Utility.GetMD5Hash( data ).ToString( ).Trim( );
							}
						}
					}

					//foreach ( string key in webChampionSquareHash.Keys )
					//{
					//	WorkMessageReceiver.Invoke( "챔피언 '" + key + "' 파일 검사 중 ..." );

					//	if ( savedChampionSquareHash[ key ] == null )
					//	{
					//		DownloadSpecificChampionSquare( key, WorkMessageReceiver );

					//		continue;
					//	}

					//	if ( webChampionSquareHash[ key ].Equals( savedChampionSquareHash[ key ] ) )
					//	{
					//		WorkMessageReceiver.Invoke( "챔피언 '" + key + "' - 파일에 문제가 없습니다." );
					//	}
					//	else
					//	{
					//		WorkMessageReceiver.Invoke( "챔피언 '" + key + "' - 파일 문제를 발견했습니다." );

					//		System.Threading.Thread.Sleep( 1000 );

					//		DownloadSpecificChampionSquare( key, WorkMessageReceiver );
					//	}
					//}

					WorkMessageReceiver.Invoke( "무결성 검사 완료." );

					System.Threading.Thread.Sleep( 500 );
				}
			}
			catch ( IOException ex )
			{
				WorkMessageReceiver.Invoke( "파일 접근 오류가 발생했습니다. - " + ex.Message );
			}
			catch ( WebException ex )
			{
				if ( ex.Response == null )
				{
					WorkMessageReceiver.Invoke( "인터넷 연결을 확인하십시오." );
					return;
				}

				HttpStatusCode code = ( ( HttpWebResponse ) ex.Response ).StatusCode;

				WorkMessageReceiver.Invoke( "서버 요청 실패 [" + code.ToString( ) + "]." );
			}
		}

		private static void DownloadSpecificChampionSquare( string championKey, string championName, Action<string> WorkMessageReceiver )
		{
			string championSquareDir = GlobalVar.APP_DIR + @"\champions";

			try
			{
				WebClient cl = new WebClient( );
				cl.DownloadFileCompleted += ( e, d ) =>
				{
					WorkMessageReceiver.Invoke( "챔피언 '" + championName + "' 파일 다운로드 완료." );
				};

				//System.Windows.Forms.MessageBox.Show( "http://ddragon.leagueoflegends.com/cdn/" + "4.2.6" + "/img/champion/" + championName + ".png" );
				// 버전 수정 필요

				WorkMessageReceiver.Invoke( "챔피언 '" + championName + "' 파일 다운로드 중 ..." );

				cl.DownloadFile( new Uri( "http://ddragon.leagueoflegends.com/cdn/" + "6.24.1" + "/img/champion/" + championKey + ".png" ),
					championSquareDir + @"\" + championName + ".png" );
			}
			catch ( WebException ex )
			{
				if ( ex.Response == null )
				{
					WorkMessageReceiver.Invoke( "챔피언 '" + championName + "' 파일 다운로드 실패." );
					return;
				}

				HttpStatusCode code = ( ( HttpWebResponse ) ex.Response ).StatusCode;

				WorkMessageReceiver.Invoke( "챔피언 '" + championName + "' 파일 다운로드 실패 [" + code.ToString( ) + "]." );
			}
		}

		public static void InstallChampionSquares( )
		{
			try
			{
				string championSquareDir = GlobalVar.APP_DIR + @"\champions";
				string url = "https://global.api.pvp.net/api/lol/static-data/kr/v1.2/champion?locale=ko_KR&champData=image&api_key=9738131e-b1fb-4679-8d48-bb92f5e7e9f8";
				HttpWebRequest request = ( HttpWebRequest ) WebRequest.Create( url );
				request.Method = "GET";    // 기본값 "GET"

				using ( HttpWebResponse response = ( HttpWebResponse ) request.GetResponse( ) )
				{
					using ( Stream responseStream = response.GetResponseStream( ) )
					{
						using ( StreamReader reader = new StreamReader( responseStream, Encoding.UTF8 ) )
						{
							JsonObjectCollection topJSON = ( JsonObjectCollection ) new JsonTextParser( ).Parse( reader.ReadToEnd( ) );
							JsonObjectCollection dataJSON = ( JsonObjectCollection ) topJSON[ "data" ];

							string clientVersion = topJSON[ "version" ].GetValue( ).ToString( );

							//http://ddragon.leagueoflegends.com/cdn/4.2.6/img/champion/Aatrox.png

							WebClient cl = new WebClient( );
							cl.DownloadFileCompleted += ( e, d ) =>
							{

							};

							foreach ( JsonObject i in dataJSON )
							{
								JsonObjectCollection itemJSON = ( JsonObjectCollection ) i;
								Console.WriteLine( itemJSON[ "name" ].GetValue( ).ToString( ) );

								JsonObjectCollection imageJSON = ( JsonObjectCollection ) itemJSON[ "image" ];

								Console.WriteLine( imageJSON[ "full" ].GetValue( ).ToString( ) );


								//http://ddragon.leagueoflegends.com/cdn/" + clientVersion + "/img/champion/" + imageJSON[ "full" ].GetValue( ).ToString( )


								cl.DownloadFile( new Uri( "http://ddragon.leagueoflegends.com/cdn/" + clientVersion + "/img/champion/" + imageJSON[ "full" ].GetValue( ).ToString( ) ),
									championSquareDir + @"\" + itemJSON[ "name" ].GetValue( ).ToString( ) );
							}
						}
					}
				}
			}
			catch ( Exception ex )
			{

			}
		}
	}
}

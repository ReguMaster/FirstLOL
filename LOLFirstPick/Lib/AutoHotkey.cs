using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhkWrapper;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LOLFirstPick.Lib
{
	enum WorkerStatus
	{
		FindingChatBox,
		FindingSearchBox,
		FindingChampPosition,
		FindingPickButton,
		Success
	}

	static class AutoHotkeyWorker
	{
		public static Action ScriptEnd;
		public static Action<WorkerStatus> WorkerStatusChanged;
		private static Thread ScriptThread;

		[DllImport( "user32.dll" )]
		private static extern IntPtr FindWindow( string className, string windowName );

		[DllImport( "user32.dll" )]
		private static extern int GetWindowRect( IntPtr hwnd, out System.Drawing.Rectangle rect );

		[DllImport( "user32" )]
		public static extern IntPtr GetForegroundWindow( );

		[System.Runtime.InteropServices.StructLayout( System.Runtime.InteropServices.LayoutKind.Sequential )]
		public struct RECT
		{
			public int Left { get; set; }
			public int Top { get; set; }
			public int Right { get; set; }
			public int Bottom { get; set; }
		}

		public static bool FindLeagueofLegends( )
		{
			// http://happyguy81.tistory.com/52
			return true;

			IntPtr hwnd = FindWindow( null, "League of Legends" );


			if ( hwnd.ToInt32( ) > 0 )
			{
				return true;
			}

			return false;
		}

		public static WorkerStatus GetWorkerStatus( )
		{
			string var = AutoHotkey.GetVar( "Status" );

			if ( string.IsNullOrEmpty( var ) )
			{
				var = "0";
			}
			return ( WorkerStatus ) int.Parse( var );
		}

		public static void Start( string lineString, bool forceReady, string championName )
		{
			if ( string.IsNullOrEmpty( GlobalVar.SCRIPT ) ) return;

			string ScriptData = ( string ) GlobalVar.SCRIPT.Clone( );

			if ( lineString.Length > 0 )
			{
				StringBuilder lineStringBuilder = new StringBuilder( );

				for ( int i = 0; i < lineString.Length; i++ )
				{
					if ( (char)lineString[ i ] == 32 ) // 띄어쓰기 감지
					{
						lineStringBuilder.AppendLine( "Send {Space}" );
						continue;
					}

					lineStringBuilder.AppendLine( "Send {" + lineString[ i ] + " 1}" );
				}

				ScriptData = ScriptData.Replace( "#LineScript", lineStringBuilder.ToString( ) );
			}
			else
			{
				ScriptData = ScriptData.Replace( "#LineScript", "" );
			}

			if ( forceReady )
			{
				ScriptData = ScriptData.Replace( "#ForceReadyScript", "Send {Click %FoundX% %FoundY%}" );
			}
			else
			{
				ScriptData = ScriptData.Replace( "#ForceReadyScript", "" );
			}

			ScriptData = ScriptData.Replace( "#ChampionName", championName );

			//#LineScript
			//Send {ㅁ 1}
			//Send {ㄷ 1}
			ScriptThread = new Thread( ( ) =>
			{
				AutoHotkey.ThreadFromText( ScriptData );

				WorkerStatus status = WorkerStatus.FindingChatBox;

				WorkerStatusChanged.Invoke( status );

				/*
					WorkerStatus.FindingChatBox -> WorkerStatus.FindingSearchBox -> WorkerStatus.FindingChampPosition -> WorkerStatus.FindingPickButton

				*/

				while ( AutoHotkey.isRun( ) )
				{
					if ( status != GetWorkerStatus( ) )
					{
						WorkerStatusChanged.Invoke( GetWorkerStatus( ) );
						status = GetWorkerStatus( );
					}


					//System.IO.File.AppendAllText( "lll.txt", AutoHotkey.GetVar( "Status" ) + "\r\n" );
					System.Threading.Thread.Sleep( 100 );
				}

				ScriptEnd.Invoke( );
			} )
			{
				IsBackground = true
			};
			ScriptThread.Start( );
		}

		public static void Kill( )
		{
			if ( AutoHotkey.isRun( ) )
			{
				if ( ScriptThread != null )
				{
					ScriptThread.Abort( );
					ScriptThread = null;
				}

				AutoHotkey.Kill( );

				ScriptEnd.Invoke( );
			}

		}
	}
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AhkWrapper;
using YamlDotNet.RepresentationModel;

namespace Tester
{
	static class AssistantAgentProvider
	{
		public enum AgentStatus : byte
		{
			IDLE,
			GAME_FOUND
		}

		private static Thread CheckerThread;
		private static AgentStatus LocalStatus = AgentStatus.IDLE;

		//public static int GetWorkerStatus( )
		//{
		//	if ( int.TryParse( AutoHotkey.GetVar( "Status" ), out int result ) )
		//		return result;
		//	else
		//		return 0;
		//}

		//public static string GetWorkerStatus( )
		//{
		//	return AutoHotkey.GetVar( "Status" );
		//}

		public static AgentStatus GetStatus( )
		{
			if ( byte.TryParse( AutoHotkey.Var[ "Status" ], out byte result ) )
				return ( AgentStatus ) result;
			else
				return AgentStatus.IDLE;
		}

		public static void Start( )
		{
			LocalStatus = 0;

			Thread agentThread = new Thread( ( ) =>
			{
				AutoHotkey.ThreadFromText( File.ReadAllText( @"D:\Dropbox\Dev\C#-2\LOLFirstPick\Tester\ahkscript.red" ) );
				Console.WriteLine( "AHK agent started." );

				//while ( true )
				//{
				//	Console.WriteLine( "New Status : " + ahk.GetVar( "Status" ) );
				//
				//}
				//AutoHotkeyEngine.Instance.(  );

				while ( AutoHotkey.IsRunning( ) )
				{
					if ( !LocalStatus.Equals( GetStatus( ) ) )
					{
						LocalStatus = GetStatus( );
						Console.WriteLine( "New Status : " + LocalStatus );
						//Console.WriteLine( "New Status : " + status.ToString( ) );

						if ( LocalStatus.Equals( AgentStatus.GAME_FOUND ) ) // 게임을 찾았습니다!
						{
							Console.WriteLine( "GAME FOUND" );
							Program.GameAgree( );
							AutoHotkey.SetVar( "Status", "3" );

							Thread.Sleep( 13000 );
						}
					}

					Thread.Sleep( 100 );
				}
			} )
			{
				Name = "AssistantAgent_Checker",
				Priority = ThreadPriority.Normal,
				IsBackground = true
			};
			//ScriptThread.SetApartmentState( ApartmentState.STA );
			agentThread.Start( );

			CheckerThread = agentThread;
		}

		public static void Kill( )
		{
			if ( AutoHotkey.IsRunning( ) )
			{
				Console.WriteLine( "AHK agent KILLED." );

				if ( CheckerThread != null && CheckerThread.IsAlive ) // TODO : 확인 바람
				{
					CheckerThread.Abort( );
					CheckerThread = null;
					Console.WriteLine( "aborted" );
				}

				AutoHotkey.Terminate( );
			}
		}
	}

	class Program
	{

		/*
		[DllImport( "user32.dll" )] // 입력 제어
		static extern void mouse_event( uint dwFlags, uint dx, uint dy, int dwData, int dwExtraInfo );

		[DllImport( "user32.dll" )]
		public static extern void keybd_event( uint vk, uint scan, uint flags, uint extraInfo );

		[DllImport( "user32.dll" )]
		private static extern uint MapVirtualKey( int wCode, int wMapType );

		[DllImport( "user32.dll" )] // 커서 위치 제어
		static extern int SetCursorPos( int x, int y );

		[DllImport( "user32.dll" )]
		internal static extern bool GetWindowPlacement( IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl );

		//출처: http://11cc.tistory.com/20 [LUCKY CODE]

		[DllImport( "user32.dll" )]
		public static extern IntPtr FindWindow( string lpClassName, string lpWindowName );

		[DllImport( "user32.dll" )]
		public static extern IntPtr FindWindowEx( IntPtr hWnd1, int hWnd2, string lpsz1, string lpsz2 );

		[DllImport( "user32.dll", SetLastError = true )]
		//MoveWindow 함수를 호출한다.
		internal static extern bool MoveWindow( IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint );

		static void GetWindowPos( IntPtr hwnd, ref int ptrPhwnd, ref int ptrNhwnd, ref Point ptPoint, ref Size szSize, ref WNDSTATE intShowCmd )
		{
			WINDOWPLACEMENT wInf = new WINDOWPLACEMENT( );
			wInf.length = System.Runtime.InteropServices.Marshal.SizeOf( wInf );
			GetWindowPlacement( hwnd, ref wInf );
			szSize = new Size( wInf.rcNormalPosition.Right - ( wInf.rcNormalPosition.Left * 2 ), wInf.rcNormalPosition.Bottom - ( wInf.rcNormalPosition.Top * 2 ) );
			ptPoint = new Point( wInf.rcNormalPosition.Left, wInf.rcNormalPosition.Top );
		}*/

		//private WinAPI.LowLevelKeyboardProc _proc = hookProc;
		//const int WH_MOUSE_LL = 14; // Номер глобального LowLevel-хука на клавиатуру
		//const int WM_KEYDOWN = 0x100; // Сообщения нажатия клавиши

		private static IntPtr LeagueClientHWND;

		public static void SetHook( )
		{
			WinAPI.LowLevelKeyboardProc proc = new WinAPI.LowLevelKeyboardProc( ( int code, IntPtr wParam, IntPtr lParam ) =>
			{
				//	System.Diagnostics.Debug.WriteLine( code.ToString( ) );
				//Console.WriteLine( code.ToString( ) );

				return WinAPI.CallNextHookEx( hhook, code, ( int ) wParam, lParam );
			} );

			//IntPtr hInstance = WinAPI.LoadLibrary( "User32" );
			hhook = WinAPI.SetWindowsHookEx( 13, proc, Marshal.GetHINSTANCE( System.Reflection.Assembly.GetExecutingAssembly( ).GetModules( )[ 0 ] ), 0 );

			Console.WriteLine( "Hooked - " + hhook.ToString( ) );
		}

		public static void UnHook( )
		{
			WinAPI.UnhookWindowsHookEx( hhook );
			Console.WriteLine( "UnHooked" );
		}


		[STAThread]
		static void Main( string[ ] args )
		{
			Console.Title = "FirstLOL";

			Program.LeagueClientHWND = GetLeagueClientHandle( );
			Console.WriteLine( "League of Legends(RCLIENT) handle : " + Program.LeagueClientHWND.ToInt64( ) );

			(Point point, Size size) = WinAPI.GetWindowPos( Program.LeagueClientHWND );

			HotKeyManager.RegisterHotKey( Keys.F1, KeyModifiers.NoRepeat );
			HotKeyManager.RegisterHotKey( Keys.F2, KeyModifiers.NoRepeat );
			//HotKeyManager.RegisterHotKey( Keys.F3, KeyModifiers.NoRepeat );
			HotKeyManager.HotKeyPressed += ( object sender, HotKeyEventArgs e ) =>
			{
				if ( e.Key == Keys.F1 )
					Pick( );
				else if ( e.Key == Keys.F2 )
					GameAgree( );
				else if ( e.Key == Keys.F3 )
					AssistantAgentProvider.Kill( );
			};

			//MoveWindow( hwnd, 0, 100, 1600, 900, true );

			//string[] champs = RiotAPI.GetChampionIDList( );
			//foreach ( var i in champs )
			//	Console.WriteLine( i );

			AssistantAgentProvider.Start( );
			//LCULocalPreferences lCU = new LCULocalPreferences( );
			//Console.WriteLine( lCU.GetValue( "lol-audio/data/loginMusicEnabled", "fuck" ) );


			//Application.EnableVisualStyles( );
			//Application.SetCompatibleTextRenderingDefault( false );

			Working working = new Working( );
			working.Show( );
			WinAPI.SetWindowPos( working.Handle, -1, 0, 0, 0, 0, 10 );
			WinAPI.SetParent( working.Handle, Program.LeagueClientHWND );
			working.SetBounds( size.Width / 2 - 200 / 2, 0, 200, 30, BoundsSpecified.All );
			Application.Run( working );





			//while ( true )
			//{
			//	string cmd = Console.ReadLine( );

			//	if ( cmd == "agree" )
			//	{

			//	}
			//	else if ( cmd == "" )
			//	{
			//		Pick( );

			//		//Thread.Sleep( 100 );

			//		//WinAPI.SetCursorPos( point.X + ( size.Width / 2 ), point.Y + size.Height - 120 ); // 100*100위치에
			//		//WinAPI.MouseEvent( WinAPI.LBDOWN | WinAPI.LBUP, 0, 0, 0, 0 ); // 왼쪽 버튼 누르고 떼고

			//		//	출처: http://11cc.tistory.com/20 [LUCKY CODE]
			//	}

			//	Thread.Sleep( 100 );
			//}

			//AutoHotkeyWorker.Kill( );
		}

		static IntPtr hhook;

		public static IntPtr GetLeagueClientHandle( )
		{
			IntPtr hwnd = WinAPI.FindWindow( "RCLIENT", "League of Legends" );

			if ( hwnd.ToInt32( ) > 0 )
			{
				return hwnd;
			}

			return IntPtr.Zero;
		}

		//public struct WindowsProperty
		//{
		//	public Point pos;
		//	public Size size;
		//}

		//public static WindowsProperty GetLeagueClientWindowPosSize( IntPtr handle )
		//{
		//	WindowsProperty property = new WindowsProperty( );

		//	WinAPI.GetWindowPos( handle, ref property.pos, ref property.size );

		//	return property;
		//}

		public static IntPtr LeagueClientHandle
		{
			private set;
			get;
		}

		static void Pick( )
		{
			(Point point, Size size) = WinAPI.GetWindowPos( Program.LeagueClientHWND );

			Console.WriteLine( "0x" + Program.LeagueClientHWND.ToInt32( ) + " address, x, y : " + point.ToString( ) + " / w, h : " + size.ToString( ) );

			WinAPI.SetCursorPos( point.X + 100, point.Y + size.Height - 20 );
			WinAPI.MouseEvent( WinAPI.LBDOWN | WinAPI.LBUP, 0, 0, 0, 0 ); // 왼쪽 버튼 누르고 떼고

			Thread.Sleep( 100 );

			Console.WriteLine( "Typed line -> mid." );
			TextPaste( "ㅁㄷ", true );

			Thread.Sleep( 200 );

			WinAPI.SetCursorPos( point.X + ( size.Width / 2 ) + 150, point.Y + 175 ); // 100*100위치에
			WinAPI.MouseEvent( WinAPI.LBDOWN | WinAPI.LBUP, 0, 0, 0, 0 ); // 왼쪽 버튼 누르고 떼고

			Console.WriteLine( "Clicked champion -> zoe." );
			TextPaste( "조이" );

			Thread.Sleep( 500 );

			WinAPI.SetCursorPos( point.X + ( size.Width / 3 ) - 30, point.Y + 230 ); // 100*100위치에
			WinAPI.MouseEvent( WinAPI.LBDOWN | WinAPI.LBUP, 0, 0, 0, 0 ); // 왼쪽 버튼 누르고 떼고

			Thread.Sleep( 100 );

			//WinAPI.SetCursorPos( point.X + ( size.Width / 2 ), point.Y + size.Height - 110 ); // 100*100위치에
			//WinAPI.MouseEvent( WinAPI.LBDOWN | WinAPI.LBUP, 0, 0, 0, 0 ); // 왼쪽 버튼 누르고 떼고

			Console.WriteLine( "Finished." );
		}

		static void TextPaste( string text, bool enter = false )
		{
			object clipboardBackup = null;
			int clipboardDataType = 0;

			if ( Clipboard.ContainsText( ) )
			{
				clipboardBackup = Clipboard.GetText( );
				clipboardDataType = 0;
			}
			else if ( Clipboard.ContainsAudio( ) )
			{
				clipboardBackup = Clipboard.GetAudioStream( );
				clipboardDataType = 1;
			}
			else if ( Clipboard.ContainsFileDropList( ) )
			{
				clipboardBackup = Clipboard.GetFileDropList( );
				clipboardDataType = 2;
			}
			else if ( Clipboard.ContainsImage( ) )
			{
				clipboardBackup = Clipboard.GetImage( );
				clipboardDataType = 3;
			}
			else
			{
				clipboardDataType = 4;
			}

			try
			{
				Clipboard.SetText( text, TextDataFormat.UnicodeText );

				WinAPI.KeyEvent( ( byte ) Keys.ControlKey, 0, 0x00, 0 );
				WinAPI.KeyEvent( ( byte ) Keys.V, 0, 0x00, 0 );
				WinAPI.KeyEvent( ( byte ) Keys.ControlKey, 0, 0x02, 0 );
				WinAPI.KeyEvent( ( byte ) Keys.V, 0, 0x02, 0 );

				if ( enter )
				{
					WinAPI.KeyEvent( ( byte ) Keys.Enter, 0, 0x00, 0 );
					WinAPI.KeyEvent( ( byte ) Keys.Enter, 0, 0x02, 0 );
				}
			}
			finally
			{



				//switch ( clipboardDataType )
				//{
				//	case 0:
				//		Clipboard.SetText( ( string ) clipboardBackup );
				//		break;
				//	case 1:
				//		Clipboard.SetAudio( ( byte[ ] ) clipboardBackup );
				//		break;
				//	case 2:
				//		Clipboard.SetFileDropList( ( System.Collections.Specialized.StringCollection ) clipboardBackup );
				//		break;
				//	case 3:
				//		Clipboard.SetImage( ( Image ) clipboardBackup );
				//		break;
				//	default:
				//		break;
				//}
			}
		}

		public static void GameAgree( )
		{
			(Point point, Size size) = WinAPI.GetWindowPos( Program.LeagueClientHWND );

			Console.WriteLine( "0x" + Program.LeagueClientHWND.ToInt32( ) + " address, x, y : " + point.ToString( ) + " / w, h : " + size.ToString( ) );
			WinAPI.SetCursorPos( point.X + ( size.Width / 2 ), point.Y + size.Height - 125 ); // 100 -> 거절, 125 -> 수락
			WinAPI.MouseEvent( WinAPI.LBDOWN | WinAPI.LBUP, 0, 0, 0, 0 );

			Console.WriteLine( "Game agreed." );
		}

		//static void HotKeyManager_HotKeyPressed( object sender, HotKeyEventArgs e )
		//{
		//	WinAPI.GetWindowPos( hwnd, ref i, ref i2, ref point, ref size, ref state );

		//	Console.WriteLine( "0x" + hwnd.ToInt32( ) + " address, child 0x" + hwnd2.ToInt32( ) + " x, y : " + point.ToString( ) + " / w, h : " + size.ToString( ) + " / state : " + state.ToString( ) );

		//	WinAPI.SetCursorPos( point.X + 100, point.Y + size.Height - 20 );
		//	WinAPI.MouseEvent( WinAPI.LBDOWN | WinAPI.LBUP, 0, 0, 0, 0 ); // 왼쪽 버튼 누르고 떼고

		//	Console.WriteLine( "typed line -> mid." );
		//	TextPaste( "ㅁㄷ" );

		//	WinAPI.KeyEvent( ( byte ) Keys.Enter, 0, 0x00, 0 );
		//	WinAPI.KeyEvent( ( byte ) Keys.Enter, 0, 0x02, 0 );

		//	Thread.Sleep( 100 );

		//	WinAPI.SetCursorPos( point.X + ( size.Width / 2 ) + 150, point.Y + 175 ); // 100*100위치에
		//	WinAPI.MouseEvent( WinAPI.LBDOWN | WinAPI.LBUP, 0, 0, 0, 0 ); // 왼쪽 버튼 누르고 떼고

		//	Console.WriteLine( "typed champ -> zoe." );
		//	TextPaste( "조이" );

		//	Thread.Sleep( 300 );

		//	WinAPI.SetCursorPos( point.X + ( size.Width / 3 ) - 30, point.Y + 230 ); // 100*100위치에
		//	WinAPI.MouseEvent( WinAPI.LBDOWN | WinAPI.LBUP, 0, 0, 0, 0 ); // 왼쪽 버튼 누르고 떼고

		//	Console.WriteLine( "finished." );
		//}
	}
}

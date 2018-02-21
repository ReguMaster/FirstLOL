using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Tester
{
	public static class WinAPI
	{
		public const uint LBDOWN = 0x00000002; // 왼쪽 마우스 버튼 눌림
		public const uint LBUP = 0x00000004; // 왼쪽 마우스 버튼 떼어짐
		public const uint RBDOWN = 0x00000008; // 오른쪽 마우스 버튼 눌림
		public const uint RBUP = 0x000000010; // 오른쪽 마우스 버튼 떼어짐
		public const uint MBDOWN = 0x00000020; // 휠 버튼 눌림
		public const uint MBUP = 0x000000040; // 휠 버튼 떼어짐
		public const uint WHEEL = 0x00000800; //휠 스크롤

		public struct WINDOWPLACEMENT
		{
			public int length;
			public int flags;
			public ShowWindowCommands showCmd;
			public Point min;
			public Point max;
			public Rectangle normalPos;
		}

		public enum ShowWindowCommands : int
		{
			Hide = 0,
			Normal = 1,
			Minimized = 2,
			Maximized = 3,
		}
		
		//public enum WNDSTATE : int
		//{
		//	SW_HIDE = 0,
		//	SW_SHOWNORMAL = 1,
		//	SW_NORMAL = 1,
		//	SW_SHOWMINIMIZED = 2,
		//	SW_MAXIMIZE = 3,
		//	SW_SHOWNOACTIVATE = 4,
		//	SW_SHOW = 5,
		//	SW_MINIMIZE = 6,
		//	SW_SHOWMINNOACTIVE = 7,
		//	SW_SHOWNA = 8,
		//	SW_RESTORE = 9,
		//	SW_SHOWDEFAULT = 10,
		//	SW_MAX = 10
		//}

		[DllImport( "user32.dll", EntryPoint = "mouse_event" )] // 입력 제어
		public static extern void MouseEvent( uint dwFlags, uint dx, uint dy, int dwData, int dwExtraInfo );

		[DllImport( "user32.dll", EntryPoint = "keybd_event" )]
		public static extern void KeyEvent( uint vk, uint scan, uint flags, uint extraInfo );

		[DllImport( "user32.dll" )]
		public static extern uint MapVirtualKey( int wCode, int wMapType );

		[DllImport( "user32.dll" )] // 커서 위치 제어
		public static extern int SetCursorPos( int x, int y );

		[DllImport( "user32.dll" )]
		internal static extern bool GetWindowPlacement( IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl );

		//출처: http://11cc.tistory.com/20 [LUCKY CODE]

		[DllImport( "user32.dll" )]
		public static extern IntPtr FindWindow( string lpClassName, string lpWindowName );

		[DllImport( "user32.dll" )]
		public static extern IntPtr FindWindowEx( IntPtr hWnd1, int hWnd2, string lpsz1, string lpsz2 );

		[DllImport( "user32" )]
		public static extern int SetWindowPos( IntPtr hwnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int wFlags );

		[DllImport( "user32" )]
		public static extern int SetWindowPos( IntPtr hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags );
		//출처: http://lab.cliel.com/entry/SetWindowPos-Window종류및-크기와-표시-Level변경 [CLIEL LAB]

		public delegate IntPtr HookProc( int nCode, IntPtr wParam, IntPtr lParam );
		public delegate IntPtr LowLevelKeyboardProc( int nCode, IntPtr wParam, IntPtr lParam );

		[DllImport( "user32.dll" )]
		public static extern IntPtr SetWindowsHookEx( int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId );

		[DllImport( "user32.dll" )]
		public static extern bool UnhookWindowsHookEx( IntPtr hInstance );

		[DllImport( "user32.dll" )]
		public static extern IntPtr CallNextHookEx( IntPtr idHook, int nCode, int wParam, IntPtr lParam );

		[DllImport( "kernel32.dll" )]
		public static extern IntPtr LoadLibrary( string lpFileName );

		[DllImport( "user32.dll", SetLastError = true )]
		public static extern IntPtr SetParent( IntPtr hWndChild, IntPtr hWndNewParent );


		[DllImport( "user32.dll", SetLastError = true )]
		//MoveWindow 함수를 호출한다.
		public static extern bool MoveWindow( IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint );

		public static void GetWindowPos( IntPtr hwnd, ref Point pos, ref Size size )
		{
			WINDOWPLACEMENT wInf = new WINDOWPLACEMENT( );
			wInf.length = Marshal.SizeOf( wInf );
			GetWindowPlacement( hwnd, ref wInf );
			size = new Size( wInf.normalPos.Right - ( wInf.normalPos.Left * 2 ), wInf.normalPos.Bottom - ( wInf.normalPos.Top * 2 ) );
			pos = new Point( wInf.normalPos.Left, wInf.normalPos.Top );
		}
	}
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.Cryptography;

namespace LOLFirstPick.Lib
{
	public enum GlobalErrorResultCode
	{
		Success,
		FileNotFound,
		UnauthorizedAccessException,
		Unknown
	}

	static class Utility
	{
		public static class App
		{
			public static GlobalErrorResultCode RestartWithOption( string args, string verb = null )
			{
				try
				{
					System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo( )
					{
						UseShellExecute = true,
						FileName = Application.ExecutablePath,
						WorkingDirectory = Application.StartupPath,
						Arguments = args
					};

					if ( verb != null )
						info.Verb = verb;

					System.Diagnostics.Process.Start( info );

					return GlobalErrorResultCode.Success;
				}
				catch ( FileNotFoundException )
				{
					return GlobalErrorResultCode.FileNotFound;
				}
				catch ( Exception )
				{
					return GlobalErrorResultCode.Unknown;
				}
				finally
				{
					Application.Exit( );
				}
			}

			// http://deokss.blogspot.kr/2015/04/c.html
			public static bool IsAdministratorStartup( )
			{
				WindowsIdentity identity = WindowsIdentity.GetCurrent( );

				if ( identity != null )
				{
					return ( new WindowsPrincipal( identity ) ).IsInRole( WindowsBuiltInRole.Administrator );
				}

				return false;
			}
		}


		public static void ErrorCodeHandler( System.Windows.Forms.Form parent, GlobalErrorResultCode resultCode, Action<GlobalErrorResultCode> callBack )
		{
			switch ( resultCode )
			{
				case GlobalErrorResultCode.Success:
					callBack.Invoke( resultCode );
					break;
				case GlobalErrorResultCode.FileNotFound:
					//NotifyBox.Show( parent, "ErrorCodeHandler", "FileNotFound", NotifyBoxType.OK, NotifyBoxIcon.Error );
					callBack.Invoke( resultCode );
					break;
				case GlobalErrorResultCode.Unknown:
					//NotifyBox.Show( parent, "ErrorCodeHandler", "Unknown", NotifyBoxType.OK, NotifyBoxIcon.Error );
					callBack.Invoke( resultCode );
					break;
			}
		}

		// Lerp (Linear interpolation, 선형보간법) 
		// p 의 값이 0에 가까워질수록 ( a - b ) 에 비례하여 중간 값이 커진다 (애니메이션이 빨라진다)
		// p 의 값이 1에 가까워질수록 ( a - b ) 에 비례하여 중간 값이 작아진다 (애니메이션이 느려진다)
		// ( p 의 값이 0 ~ 1F )
		// http://stackoverflow.com/questions/33044848/c-sharp-lerping-from-position-to-position
		// http://dodnet.tistory.com/993
		public static float Lerp( float a, float b, float p )
		{
			return a * p + b * ( 1 - p );
		}

		public static int Clamp( int original, int max, int min )
		{
			if ( original > max )
				return max;

			if ( original < min )
				return min;

			return original;
		}

		public static Color LerpColor( Color a, Color b, float p )
		{
			float newR = 0, newG = 0, newB = 0, newA = 0;

			newR = a.R * p + b.R * ( 1 - p );
			newG = a.G * p + b.G * ( 1 - p );
			newB = a.B * p + b.B * ( 1 - p );
			newA = a.A * p + b.A * ( 1 - p );

			//return Color.FromArgb( (int)Math.Round( newR ), ( int ) newG, ( int ) newB );
			return Color.FromArgb( ( int ) Math.Round( newA ), ( int ) Math.Round( newR ), ( int ) Math.Round( newG ), ( int ) Math.Round( newB ) );
		}

		// http://bananamandoo.tistory.com/27
		public static void Delay( int ms )
		{
			DateTime ThisMoment = DateTime.Now;
			DateTime AfterWards = ThisMoment.Add( new TimeSpan( 0, 0, 0, 0, ms ) );

			while ( AfterWards >= ThisMoment )
			{
				Application.DoEvents( );
				ThisMoment = DateTime.Now;
			}
		}

		public static Form GetFormByName( string name )
		{
			foreach ( Form i in Application.OpenForms )
			{
				if ( i.Name == name )
					return i;
			}

			return null;
		}

		public static Main GetMainForm( )
		{
			foreach ( Form i in Application.OpenForms )
			{
				if ( i.Name == "Main" )
					return ( Main ) i;
			}

			return null;
		}

		// http://stackoverflow.com/questions/10520048/calculate-md5-checksum-for-a-file
		public static string GetMD5Hash( string fileName )
		{
			using ( MD5 md5 = MD5.Create( ) )
			{
				using ( FileStream stream = File.OpenRead( fileName ) )
				{
					return Convert.ToBase64String( md5.ComputeHash( stream ) );
				}
			}
		}

		public static string GetMD5Hash( byte[ ] fileByte )
		{
			using ( MD5 md5 = MD5.Create( ) )
			{
				using ( Stream stream = new MemoryStream( fileByte ) )
				{
					return Convert.ToBase64String( md5.ComputeHash( stream ) );
				}
			}
		}
	}

	public class GifImage
	{
		private Image gifImage;
		private FrameDimension dimension;
		private int frameCount;
		private int currentFrame = -1;
		private bool reverse;
		private int step = 1;

		public GifImage( string path )
		{
			gifImage = Image.FromFile( path );
			//initialize
			dimension = new FrameDimension( gifImage.FrameDimensionsList[ 0 ] );
			//gets the GUID
			//total frames in the animation
			frameCount = gifImage.GetFrameCount( dimension );
		}

		public bool ReverseAtEnd
		{
			//whether the gif should play backwards when it reaches the end
			get { return reverse; }
			set { reverse = value; }
		}

		public Image GetNextFrame( )
		{

			currentFrame += step;

			//if the animation reaches a boundary...
			if ( currentFrame >= frameCount || currentFrame < 1 )
			{
				if ( reverse )
				{
					step *= -1;
					//...reverse the count
					//apply it
					currentFrame += step;
				}
				else
				{
					currentFrame = 0;
					//...or start over
				}
			}
			return GetFrame( currentFrame );
		}

		public Image GetFrame( int index )
		{
			gifImage.SelectActiveFrame( dimension, index );
			//find the frame
			return ( Image ) gifImage.Clone( );
			//return a copy of it
		}
	}
}

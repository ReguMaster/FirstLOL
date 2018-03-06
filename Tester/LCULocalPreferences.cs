using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.RepresentationModel;

namespace Tester
{
	public class LCULocalPreferences : IDisposable
	{
		private bool disposed = false;
		private TextReader Reader
		{
			set;
			get;
		}

		private YamlStream Stream
		{
			set;
			get;
		}

		public LCULocalPreferences( )
		{
			// TODO : 파일 로케이션 관련 수정 필요함.
			TextReader reader = new StreamReader( @"D:\Program\Riot Games\League of Legends\Config\LCULocalPreferences.yaml" ); // TODO : 수정할 것
			YamlStream stream = new YamlStream( );
			stream.Load( reader );

			this.Reader = reader;
			this.Stream = stream;
		}

		// 재귀 메소드 /test/test/test/test loop
		protected void GetValueInternal( ref YamlNode node, string[ ] selector, int curIndex, Action<YamlNode> callback )
		{
			if ( curIndex < selector.Length )
			{
				try
				{
					node = node[ selector[ curIndex ] ];
					GetValueInternal( ref node, selector, ++curIndex, callback );
				}
				catch
				{
					callback.Invoke( null );
				}
			}
			else
				callback.Invoke( node );
		}

		public string GetValue( string node, string defaultValue = "" )
		{
			string result = string.Empty;
			string[ ] selector = node.Split( new char[ 1 ] { '/' }, StringSplitOptions.RemoveEmptyEntries );
			YamlNode root = ( YamlNode ) this.Stream.Documents[ 0 ].RootNode;

			GetValueInternal( ref root, selector, 0, ( YamlNode nodeResult ) =>
			{
				if ( nodeResult == null )
					result = defaultValue;
				else
					result = nodeResult.ToString( );
			} );

			return result;
		}

		public void Dispose( )
		{
			Dispose( true );
			GC.SuppressFinalize( this );
		}

		protected virtual void Dispose( bool disposing )
		{
			if ( !disposed )
			{
				if ( disposing )
					this.Reader.Dispose( );

				disposed = true;
			}
		}

		~LCULocalPreferences( )
		{
			Dispose( false );
		}
	}
}
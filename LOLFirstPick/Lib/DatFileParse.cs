using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LOLFirstPick.Lib
{
	static class DatFileParse
	{
		public static string DecryptFile( string fileName )
		{
			try
			{
				string randomAESKey = "FirstLOL_DAT_FILE_CRYPT";

				PasswordDeriveBytes key = new PasswordDeriveBytes( randomAESKey, Encoding.ASCII.GetBytes( randomAESKey.Length.ToString( ) ) );
				RijndaelManaged AES = new RijndaelManaged( );
				ICryptoTransform decrypt = AES.CreateDecryptor( key.GetBytes( 32 ), key.GetBytes( 16 ) );

				if ( File.Exists( fileName ) )
				{
					byte[ ] fileByte = File.ReadAllBytes( fileName );

					MemoryStream ms = new MemoryStream( fileByte );

					CryptoStream cryptoStream = new CryptoStream( ms, decrypt, CryptoStreamMode.Read );

					byte[ ] originalData = new byte[ fileByte.Length ];

					int count = cryptoStream.Read( originalData, 0, originalData.Length );

					return Encoding.UTF8.GetString( originalData );
				}
				else
				{
					return "";
				}
			}
			catch ( CryptographicException )
			{
				return "";
			}
		}
	}
}

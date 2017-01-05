using LOLFirstPick.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOLFirstPick.Interface
{
	public partial class Welcome : Form
	{
		public Welcome( )
		{
			InitializeComponent( );
		}

		private void Welcome_Load( object sender, EventArgs e )
		{
			this.CenterToScreen( );

			Thread thread = new Thread( ( ) =>
			{
				CheckForIllegalCrossThreadCalls = false;

				

				Thread.Sleep( 2000 );
				this.Close( );
			} )
			{
				IsBackground = true
			};
			thread.Start( );
		}

		private void LOADING_GIFIMAGE_DocumentCompleted( object sender, WebBrowserDocumentCompletedEventArgs e )
		{

		}
	}
}

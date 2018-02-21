using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester
{
	public partial class Working : Form
	{
		private Pen lineDrawer = new Pen( Color.White )
		{
			Width = 1
		};

		public Working( )
		{
			InitializeComponent( );

			this.SetStyle( ControlStyles.SupportsTransparentBackColor|ControlStyles.OptimizedDoubleBuffer| ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint| ControlStyles.ResizeRedraw, true );
					 //this.TransparencyKey = Color.Transparent; // I had to add this to get it to work.
			this.Invalidate( );
		}

		protected override void OnPaintBackground( PaintEventArgs e )
		{
			//int w = this.Width, h = this.Height;

			//e.Graphics.DrawLine( lineDrawer, 0, 0, w, 0 ); // 위
			//e.Graphics.DrawLine( lineDrawer, 0, 0, 0, h ); // 왼쪽
			//e.Graphics.DrawLine( lineDrawer, w - lineDrawer.Width, 0, w - lineDrawer.Width, h ); // 오른쪽
			//e.Graphics.DrawLine( lineDrawer, 0, h - lineDrawer.Width, w, h - lineDrawer.Width ); // 아래
			//empty implementation
			base.OnPaintBackground( e );
		}

		private void button1_Click( object sender, EventArgs e )
		{
			this.Close( );
		}

		private void label1_Click( object sender, EventArgs e )
		{

		}

		private void Working_Load( object sender, EventArgs e )
		{
			
		}
	}
}

using LOLFirstPick.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOLFirstPick.Interface
{
	public partial class NotifyBoxInterface : Form
	{
		private Point startPoint;
		private Pen lineDrawer = new Pen( Color.Silver )
		{
			Width = 1
		};
		public NotifyBoxResult Result;

		public NotifyBoxInterface( string title, string message, NotifyBoxType type, NotifyBoxIcon icon )
		{
			InitializeComponent( );

			TITLE_LABEL.Text = title;
			MESSAGE_LABEL.Text = message;

			switch ( icon )
			{
				case NotifyBoxIcon.Error:
					TYPE_ICON.Image = Properties.Resources.ERROR_ICON;
					System.Media.SystemSounds.Hand.Play( );
					break;
				case NotifyBoxIcon.Information:
					TYPE_ICON.Image = Properties.Resources.INFORMATION_ICON;
					System.Media.SystemSounds.Beep.Play( );
					break;
				case NotifyBoxIcon.Warning:
					TYPE_ICON.Image = Properties.Resources.WARNING_ICON;
					System.Media.SystemSounds.Exclamation.Play( );
					break;
				case NotifyBoxIcon.Question:
					TYPE_ICON.Image = Properties.Resources.QUESTION_ICON;
					System.Media.SystemSounds.Beep.Play( );
					break;
			}

			switch ( type )
			{
				case NotifyBoxType.OK:
					OK_Button.Visible = true;
					Yes_Button.Visible = false;
					NO_Button.Visible = false;

					this.FormClosing += delegate ( object sender, FormClosingEventArgs e )
					{
						if ( Result != NotifyBoxResult.OK )
						{
							Result = NotifyBoxResult.OK;
						}
					};
					break;
				case NotifyBoxType.YesNo:
					OK_Button.Visible = false;
					Yes_Button.Visible = true;
					NO_Button.Visible = true;

					this.FormClosing += delegate ( object sender, FormClosingEventArgs e )
					{
						if ( Result != NotifyBoxResult.Yes && Result != NotifyBoxResult.No )
						{
							Result = NotifyBoxResult.No;
						}
					};
					break;
			}
		}

		private void Yes_Button_Click( object sender, EventArgs e )
		{
			Result = NotifyBoxResult.Yes;
			this.Close( );
		}

		private void NO_Button_Click( object sender, EventArgs e )
		{
			Result = NotifyBoxResult.No;
			this.Close( );
		}

		private void OK_Button_Click( object sender, EventArgs e )
		{
			Result = NotifyBoxResult.OK;
			this.Close( );
		}

		private void APP_TITLE_BAR_MouseMove( object sender, MouseEventArgs e )
		{
			if ( e.Button == MouseButtons.Left )
			{
				this.Location = new Point(
					this.Left - ( startPoint.X - e.X ),
					Math.Max( this.Top - ( startPoint.Y - e.Y ), Screen.FromHandle( this.Handle ).WorkingArea.Top )
				);
			}
		}

		private void APP_TITLE_BAR_MouseDown( object sender, MouseEventArgs e )
		{
			if ( e.Button == MouseButtons.Left )
				startPoint = e.Location;
		}

		private void APP_TITLE_BAR_Paint( object sender, PaintEventArgs e )
		{
			int w = this.APP_TITLE_BAR.Width, h = this.APP_TITLE_BAR.Height;

			e.Graphics.DrawLine( lineDrawer, 0, 0, w, 0 ); // 위
			e.Graphics.DrawLine( lineDrawer, 0, 0, 0, h ); // 왼쪽
			e.Graphics.DrawLine( lineDrawer, w - lineDrawer.Width, 0, w - lineDrawer.Width, h ); // 오른쪽
			e.Graphics.DrawLine( lineDrawer, 0, h - lineDrawer.Width, w, h - lineDrawer.Width ); // 아래
		}

		private void NotifyBoxInterface_Paint( object sender, PaintEventArgs e )
		{
			int w = this.Width, h = this.Height;

			e.Graphics.DrawLine( lineDrawer, 0, 0, w, 0 ); // 위
			e.Graphics.DrawLine( lineDrawer, 0, 0, 0, h ); // 왼쪽
			e.Graphics.DrawLine( lineDrawer, w - lineDrawer.Width, 0, w - lineDrawer.Width, h ); // 오른쪽
			e.Graphics.DrawLine( lineDrawer, 0, h - lineDrawer.Width, w, h - lineDrawer.Width ); // 아래
		}
	}
}

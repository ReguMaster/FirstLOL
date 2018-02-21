using LOLFirstPick.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOLFirstPick.Interface
{
	public partial class ChampionSelection : Form
	{
		public ChampionSelection( )
		{
			InitializeComponent( );
		}

		private void CLOSE_BUTTON_Click( object sender, EventArgs e )
		{
			this.Close( );
		}

		private void ChampionSelection_Load( object sender, EventArgs e )
		{
			string[ ] files = Directory.GetFiles( @"D:\Dropbox\Dev\C#-2\LOLFirstPick\LOLFirstPick\bin\Debug\champions", "*.png" );

			foreach ( string i in files )
			{
				Button btn = new Button( );
				btn.Name = Path.GetFileNameWithoutExtension( i );
				btn.Image = Image.FromFile( i );
				btn.Size = new Size( 120, 120 );
				btn.Font = new System.Drawing.Font( "나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 129 ) ) );
				btn.Text = Path.GetFileNameWithoutExtension( i );
				btn.ForeColor = Color.White;
				//btn.Location = new Point( );
				btn.Click += ( sender2, e2 ) =>
				{
					MessageBox.Show( Path.GetFileNameWithoutExtension( i ) + " 선택 .. " );

					Main mainForm = Utility.GetMainForm( );
					//mainForm.
					GlobalVar.SelectedChampionName = Path.GetFileNameWithoutExtension( i );
					mainForm.RefreshChampionSquare( );
				};

				this.CHAMPIONS_LIST.Controls.Add( btn );
			}
		}

		private void CHAMPION_SEARCH_TEXTBOX_TextChanged( object sender, EventArgs e )
		{
			Champion_Search( this.CHAMPION_SEARCH_TEXTBOX.Text );
		}

		private void Champion_Search( string input )
		{
			if ( input == "" )
			{
				foreach ( Button btn in this.CHAMPIONS_LIST.Controls )
				{
					btn.Visible = true;
				}

				return;
			}

			foreach ( Button btn in this.CHAMPIONS_LIST.Controls )
			{
				if ( btn.Name.StartsWith( input ) )
				{
					if ( !btn.Visible )
						btn.Visible = true;
				}
				else
				{
					if ( btn.Visible )
						btn.Visible = false;
				}
			}
		}
	}
}

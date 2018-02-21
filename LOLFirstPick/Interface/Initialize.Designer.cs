namespace LOLFirstPick.Interface
{
	partial class Initialize
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose( );
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent( )
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Initialize));
			this.APP_TITLE_BAR = new System.Windows.Forms.Panel();
			this.APP_TITLE = new LOLFirstPick.Interface.CustomLabel();
			this.CLOSE_BUTTON = new LOLFirstPick.Interface.FlatImageButton();
			this.LOADING_GIFIMAGE = new System.Windows.Forms.WebBrowser();
			this.PROGRESS_MESSAGE = new System.Windows.Forms.Label();
			this.TITLE_LABEL = new System.Windows.Forms.Label();
			this.APP_TITLE_BAR.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CLOSE_BUTTON)).BeginInit();
			this.SuspendLayout();
			// 
			// APP_TITLE_BAR
			// 
			this.APP_TITLE_BAR.Controls.Add(this.APP_TITLE);
			this.APP_TITLE_BAR.Controls.Add(this.CLOSE_BUTTON);
			this.APP_TITLE_BAR.Location = new System.Drawing.Point(0, 0);
			this.APP_TITLE_BAR.Name = "APP_TITLE_BAR";
			this.APP_TITLE_BAR.Size = new System.Drawing.Size(500, 40);
			this.APP_TITLE_BAR.TabIndex = 1;
			this.APP_TITLE_BAR.Paint += new System.Windows.Forms.PaintEventHandler(this.APP_TITLE_BAR_Paint);
			this.APP_TITLE_BAR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.APP_TITLE_BAR_MouseDown);
			this.APP_TITLE_BAR.MouseMove += new System.Windows.Forms.MouseEventHandler(this.APP_TITLE_BAR_MouseMove);
			// 
			// APP_TITLE
			// 
			this.APP_TITLE.AutoSize = true;
			this.APP_TITLE.BackColor = System.Drawing.Color.Transparent;
			this.APP_TITLE.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.APP_TITLE.Location = new System.Drawing.Point(10, 13);
			this.APP_TITLE.Name = "APP_TITLE";
			this.APP_TITLE.Size = new System.Drawing.Size(54, 14);
			this.APP_TITLE.TabIndex = 2;
			this.APP_TITLE.Text = "파일 검사";
			this.APP_TITLE.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			// 
			// CLOSE_BUTTON
			// 
			this.CLOSE_BUTTON.AnimationLerpP = 0.8F;
			this.CLOSE_BUTTON.BackColor = System.Drawing.Color.Transparent;
			this.CLOSE_BUTTON.Cursor = System.Windows.Forms.Cursors.Hand;
			this.CLOSE_BUTTON.EnterStateBackgroundColor = System.Drawing.Color.Firebrick;
			this.CLOSE_BUTTON.Image = global::LOLFirstPick.Properties.Resources.close;
			this.CLOSE_BUTTON.Location = new System.Drawing.Point(460, 0);
			this.CLOSE_BUTTON.Name = "CLOSE_BUTTON";
			this.CLOSE_BUTTON.NormalStateBackgroundColor = System.Drawing.Color.IndianRed;
			this.CLOSE_BUTTON.Size = new System.Drawing.Size(40, 40);
			this.CLOSE_BUTTON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.CLOSE_BUTTON.TabIndex = 1;
			this.CLOSE_BUTTON.TabStop = false;
			this.CLOSE_BUTTON.Click += new System.EventHandler(this.CLOSE_BUTTON_Click);
			// 
			// LOADING_GIFIMAGE
			// 
			this.LOADING_GIFIMAGE.AllowNavigation = false;
			this.LOADING_GIFIMAGE.AllowWebBrowserDrop = false;
			this.LOADING_GIFIMAGE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LOADING_GIFIMAGE.IsWebBrowserContextMenuEnabled = false;
			this.LOADING_GIFIMAGE.Location = new System.Drawing.Point(25, 60);
			this.LOADING_GIFIMAGE.MinimumSize = new System.Drawing.Size(20, 20);
			this.LOADING_GIFIMAGE.Name = "LOADING_GIFIMAGE";
			this.LOADING_GIFIMAGE.ScriptErrorsSuppressed = true;
			this.LOADING_GIFIMAGE.ScrollBarsEnabled = false;
			this.LOADING_GIFIMAGE.Size = new System.Drawing.Size(50, 50);
			this.LOADING_GIFIMAGE.TabIndex = 14;
			this.LOADING_GIFIMAGE.Visible = false;
			this.LOADING_GIFIMAGE.WebBrowserShortcutsEnabled = false;
			// 
			// PROGRESS_MESSAGE
			// 
			this.PROGRESS_MESSAGE.BackColor = System.Drawing.Color.Transparent;
			this.PROGRESS_MESSAGE.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.PROGRESS_MESSAGE.Location = new System.Drawing.Point(12, 136);
			this.PROGRESS_MESSAGE.Name = "PROGRESS_MESSAGE";
			this.PROGRESS_MESSAGE.Size = new System.Drawing.Size(476, 25);
			this.PROGRESS_MESSAGE.TabIndex = 15;
			this.PROGRESS_MESSAGE.Text = "초기 설정 중 ...";
			this.PROGRESS_MESSAGE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TITLE_LABEL
			// 
			this.TITLE_LABEL.AutoSize = true;
			this.TITLE_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.TITLE_LABEL.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.TITLE_LABEL.Location = new System.Drawing.Point(100, 77);
			this.TITLE_LABEL.Name = "TITLE_LABEL";
			this.TITLE_LABEL.Size = new System.Drawing.Size(363, 17);
			this.TITLE_LABEL.TabIndex = 16;
			this.TITLE_LABEL.Text = "퍼스트 롤 실행을 위한 필수 파일을 검사하고 있습니다 ...";
			this.TITLE_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Initialize
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(500, 170);
			this.Controls.Add(this.TITLE_LABEL);
			this.Controls.Add(this.PROGRESS_MESSAGE);
			this.Controls.Add(this.LOADING_GIFIMAGE);
			this.Controls.Add(this.APP_TITLE_BAR);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Initialize";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "퍼스트 롤 - 파일 검사";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Initialize_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Initialize_Paint);
			this.APP_TITLE_BAR.ResumeLayout(false);
			this.APP_TITLE_BAR.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CLOSE_BUTTON)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel APP_TITLE_BAR;
		private CustomLabel APP_TITLE;
		private FlatImageButton CLOSE_BUTTON;
		private System.Windows.Forms.WebBrowser LOADING_GIFIMAGE;
		private System.Windows.Forms.Label PROGRESS_MESSAGE;
		private System.Windows.Forms.Label TITLE_LABEL;
	}
}
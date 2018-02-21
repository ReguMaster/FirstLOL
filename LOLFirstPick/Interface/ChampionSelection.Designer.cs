namespace LOLFirstPick.Interface
{
	partial class ChampionSelection
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChampionSelection));
			this.APP_TITLE_BAR = new System.Windows.Forms.Panel();
			this.APP_TITLE = new LOLFirstPick.Interface.CustomLabel();
			this.CLOSE_BUTTON = new LOLFirstPick.Interface.FlatImageButton();
			this.customLabel1 = new LOLFirstPick.Interface.CustomLabel();
			this.CHAMPIONS_LIST = new System.Windows.Forms.FlowLayoutPanel();
			this.CHAMPION_SEARCH_TEXTBOX = new System.Windows.Forms.TextBox();
			this.CHAMPION_SEARCH_TITLE = new System.Windows.Forms.Label();
			this.APP_TITLE_BAR.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CLOSE_BUTTON)).BeginInit();
			this.SuspendLayout();
			// 
			// APP_TITLE_BAR
			// 
			this.APP_TITLE_BAR.BackColor = System.Drawing.Color.Transparent;
			this.APP_TITLE_BAR.Controls.Add(this.customLabel1);
			this.APP_TITLE_BAR.Controls.Add(this.APP_TITLE);
			this.APP_TITLE_BAR.Controls.Add(this.CLOSE_BUTTON);
			this.APP_TITLE_BAR.Location = new System.Drawing.Point(0, 0);
			this.APP_TITLE_BAR.Name = "APP_TITLE_BAR";
			this.APP_TITLE_BAR.Size = new System.Drawing.Size(420, 40);
			this.APP_TITLE_BAR.TabIndex = 1;
			// 
			// APP_TITLE
			// 
			this.APP_TITLE.AutoSize = true;
			this.APP_TITLE.BackColor = System.Drawing.Color.Transparent;
			this.APP_TITLE.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.APP_TITLE.Location = new System.Drawing.Point(11, 13);
			this.APP_TITLE.Name = "APP_TITLE";
			this.APP_TITLE.Size = new System.Drawing.Size(0, 14);
			this.APP_TITLE.TabIndex = 2;
			this.APP_TITLE.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			// 
			// CLOSE_BUTTON
			// 
			this.CLOSE_BUTTON.AnimationLerpP = 0.8F;
			this.CLOSE_BUTTON.BackColor = System.Drawing.Color.Transparent;
			this.CLOSE_BUTTON.Cursor = System.Windows.Forms.Cursors.Hand;
			this.CLOSE_BUTTON.EnterStateBackgroundColor = System.Drawing.Color.Firebrick;
			this.CLOSE_BUTTON.Image = global::LOLFirstPick.Properties.Resources.close;
			this.CLOSE_BUTTON.Location = new System.Drawing.Point(380, 0);
			this.CLOSE_BUTTON.Name = "CLOSE_BUTTON";
			this.CLOSE_BUTTON.NormalStateBackgroundColor = System.Drawing.Color.IndianRed;
			this.CLOSE_BUTTON.Size = new System.Drawing.Size(40, 40);
			this.CLOSE_BUTTON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.CLOSE_BUTTON.TabIndex = 1;
			this.CLOSE_BUTTON.TabStop = false;
			this.CLOSE_BUTTON.Click += new System.EventHandler(this.CLOSE_BUTTON_Click);
			// 
			// customLabel1
			// 
			this.customLabel1.AutoSize = true;
			this.customLabel1.BackColor = System.Drawing.Color.Transparent;
			this.customLabel1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.customLabel1.Location = new System.Drawing.Point(10, 13);
			this.customLabel1.Name = "customLabel1";
			this.customLabel1.Size = new System.Drawing.Size(65, 14);
			this.customLabel1.TabIndex = 3;
			this.customLabel1.Text = "챔피언 변경";
			this.customLabel1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			// 
			// CHAMPIONS_LIST
			// 
			this.CHAMPIONS_LIST.AutoScroll = true;
			this.CHAMPIONS_LIST.BackColor = System.Drawing.Color.Transparent;
			this.CHAMPIONS_LIST.Location = new System.Drawing.Point(13, 77);
			this.CHAMPIONS_LIST.Name = "CHAMPIONS_LIST";
			this.CHAMPIONS_LIST.Size = new System.Drawing.Size(395, 359);
			this.CHAMPIONS_LIST.TabIndex = 0;
			// 
			// CHAMPION_SEARCH_TEXTBOX
			// 
			this.CHAMPION_SEARCH_TEXTBOX.BackColor = System.Drawing.Color.White;
			this.CHAMPION_SEARCH_TEXTBOX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CHAMPION_SEARCH_TEXTBOX.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.CHAMPION_SEARCH_TEXTBOX.Location = new System.Drawing.Point(51, 46);
			this.CHAMPION_SEARCH_TEXTBOX.Name = "CHAMPION_SEARCH_TEXTBOX";
			this.CHAMPION_SEARCH_TEXTBOX.Size = new System.Drawing.Size(357, 25);
			this.CHAMPION_SEARCH_TEXTBOX.TabIndex = 2;
			this.CHAMPION_SEARCH_TEXTBOX.TextChanged += new System.EventHandler(this.CHAMPION_SEARCH_TEXTBOX_TextChanged);
			// 
			// CHAMPION_SEARCH_TITLE
			// 
			this.CHAMPION_SEARCH_TITLE.AutoSize = true;
			this.CHAMPION_SEARCH_TITLE.BackColor = System.Drawing.Color.Transparent;
			this.CHAMPION_SEARCH_TITLE.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.CHAMPION_SEARCH_TITLE.Location = new System.Drawing.Point(14, 51);
			this.CHAMPION_SEARCH_TITLE.Name = "CHAMPION_SEARCH_TITLE";
			this.CHAMPION_SEARCH_TITLE.Size = new System.Drawing.Size(31, 15);
			this.CHAMPION_SEARCH_TITLE.TabIndex = 3;
			this.CHAMPION_SEARCH_TITLE.Text = "검색";
			// 
			// ChampionSelection
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(420, 448);
			this.Controls.Add(this.CHAMPION_SEARCH_TITLE);
			this.Controls.Add(this.CHAMPION_SEARCH_TEXTBOX);
			this.Controls.Add(this.CHAMPIONS_LIST);
			this.Controls.Add(this.APP_TITLE_BAR);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ChampionSelection";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ChampionSelection";
			this.Load += new System.EventHandler(this.ChampionSelection_Load);
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
		private CustomLabel customLabel1;
		private System.Windows.Forms.FlowLayoutPanel CHAMPIONS_LIST;
		private System.Windows.Forms.TextBox CHAMPION_SEARCH_TEXTBOX;
		private System.Windows.Forms.Label CHAMPION_SEARCH_TITLE;
	}
}
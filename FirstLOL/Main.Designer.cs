namespace LOLFirstPick
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.APP_TITLE_BAR = new System.Windows.Forms.Panel();
			this.CHAMP_TITLE_LABEL = new System.Windows.Forms.Label();
			this.FORCE_READY_CHECKBOX = new System.Windows.Forms.CheckBox();
			this.LINE_CHAT_TEXTBOX = new System.Windows.Forms.TextBox();
			this.LINE_TITLE_LABEL = new System.Windows.Forms.Label();
			this.TITLE_LABEL = new System.Windows.Forms.Label();
			this.LOADING_GIFIMAGE = new System.Windows.Forms.WebBrowser();
			this.WORKER_STATUS_LABEL = new System.Windows.Forms.Label();
			this.CHAMP_IMAGE = new System.Windows.Forms.PictureBox();
			this.flatButton1 = new LOLFirstPick.Interface.FlatButton();
			this.START_BUTTON = new LOLFirstPick.Interface.FlatButton();
			this.APP_TITLE = new LOLFirstPick.Interface.CustomLabel();
			this.CLOSE_BUTTON = new LOLFirstPick.Interface.FlatImageButton();
			this.APP_TITLE_BAR.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CHAMP_IMAGE)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CLOSE_BUTTON)).BeginInit();
			this.SuspendLayout();
			// 
			// APP_TITLE_BAR
			// 
			this.APP_TITLE_BAR.BackColor = System.Drawing.Color.Transparent;
			this.APP_TITLE_BAR.Controls.Add(this.APP_TITLE);
			this.APP_TITLE_BAR.Controls.Add(this.CLOSE_BUTTON);
			this.APP_TITLE_BAR.Location = new System.Drawing.Point(0, 0);
			this.APP_TITLE_BAR.Name = "APP_TITLE_BAR";
			this.APP_TITLE_BAR.Size = new System.Drawing.Size(500, 40);
			this.APP_TITLE_BAR.TabIndex = 0;
			this.APP_TITLE_BAR.Paint += new System.Windows.Forms.PaintEventHandler(this.APP_TITLE_BAR_Paint);
			this.APP_TITLE_BAR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.APP_TITLE_BAR_MouseDown);
			this.APP_TITLE_BAR.MouseMove += new System.Windows.Forms.MouseEventHandler(this.APP_TITLE_BAR_MouseMove);
			// 
			// CHAMP_TITLE_LABEL
			// 
			this.CHAMP_TITLE_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.CHAMP_TITLE_LABEL.Font = new System.Drawing.Font("나눔바른고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.CHAMP_TITLE_LABEL.Location = new System.Drawing.Point(11, 205);
			this.CHAMP_TITLE_LABEL.Name = "CHAMP_TITLE_LABEL";
			this.CHAMP_TITLE_LABEL.Size = new System.Drawing.Size(120, 35);
			this.CHAMP_TITLE_LABEL.TabIndex = 2;
			this.CHAMP_TITLE_LABEL.Text = "제드";
			this.CHAMP_TITLE_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FORCE_READY_CHECKBOX
			// 
			this.FORCE_READY_CHECKBOX.AutoSize = true;
			this.FORCE_READY_CHECKBOX.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.FORCE_READY_CHECKBOX.Location = new System.Drawing.Point(410, 166);
			this.FORCE_READY_CHECKBOX.Name = "FORCE_READY_CHECKBOX";
			this.FORCE_READY_CHECKBOX.Size = new System.Drawing.Size(78, 19);
			this.FORCE_READY_CHECKBOX.TabIndex = 6;
			this.FORCE_READY_CHECKBOX.Text = "꼴픽 하기";
			this.FORCE_READY_CHECKBOX.UseVisualStyleBackColor = true;
			this.FORCE_READY_CHECKBOX.CheckedChanged += new System.EventHandler(this.FORCE_READY_CHECKBOX_CheckedChanged);
			// 
			// LINE_CHAT_TEXTBOX
			// 
			this.LINE_CHAT_TEXTBOX.BackColor = System.Drawing.Color.White;
			this.LINE_CHAT_TEXTBOX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LINE_CHAT_TEXTBOX.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.LINE_CHAT_TEXTBOX.Location = new System.Drawing.Point(388, 139);
			this.LINE_CHAT_TEXTBOX.Name = "LINE_CHAT_TEXTBOX";
			this.LINE_CHAT_TEXTBOX.Size = new System.Drawing.Size(100, 21);
			this.LINE_CHAT_TEXTBOX.TabIndex = 10;
			// 
			// LINE_TITLE_LABEL
			// 
			this.LINE_TITLE_LABEL.AutoSize = true;
			this.LINE_TITLE_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.LINE_TITLE_LABEL.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.LINE_TITLE_LABEL.Location = new System.Drawing.Point(318, 142);
			this.LINE_TITLE_LABEL.Name = "LINE_TITLE_LABEL";
			this.LINE_TITLE_LABEL.Size = new System.Drawing.Size(67, 15);
			this.LINE_TITLE_LABEL.TabIndex = 11;
			this.LINE_TITLE_LABEL.Text = "선픽 채팅 :";
			this.LINE_TITLE_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TITLE_LABEL
			// 
			this.TITLE_LABEL.AutoSize = true;
			this.TITLE_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.TITLE_LABEL.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.TITLE_LABEL.Location = new System.Drawing.Point(11, 52);
			this.TITLE_LABEL.Name = "TITLE_LABEL";
			this.TITLE_LABEL.Size = new System.Drawing.Size(82, 17);
			this.TITLE_LABEL.TabIndex = 12;
			this.TITLE_LABEL.Text = "선픽 챔피언";
			this.TITLE_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LOADING_GIFIMAGE
			// 
			this.LOADING_GIFIMAGE.AllowNavigation = false;
			this.LOADING_GIFIMAGE.AllowWebBrowserDrop = false;
			this.LOADING_GIFIMAGE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LOADING_GIFIMAGE.IsWebBrowserContextMenuEnabled = false;
			this.LOADING_GIFIMAGE.Location = new System.Drawing.Point(13, 245);
			this.LOADING_GIFIMAGE.MinimumSize = new System.Drawing.Size(20, 20);
			this.LOADING_GIFIMAGE.Name = "LOADING_GIFIMAGE";
			this.LOADING_GIFIMAGE.ScriptErrorsSuppressed = true;
			this.LOADING_GIFIMAGE.ScrollBarsEnabled = false;
			this.LOADING_GIFIMAGE.Size = new System.Drawing.Size(40, 40);
			this.LOADING_GIFIMAGE.TabIndex = 13;
			this.LOADING_GIFIMAGE.Visible = false;
			this.LOADING_GIFIMAGE.WebBrowserShortcutsEnabled = false;
			// 
			// WORKER_STATUS_LABEL
			// 
			this.WORKER_STATUS_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.WORKER_STATUS_LABEL.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.WORKER_STATUS_LABEL.Location = new System.Drawing.Point(66, 257);
			this.WORKER_STATUS_LABEL.Name = "WORKER_STATUS_LABEL";
			this.WORKER_STATUS_LABEL.Size = new System.Drawing.Size(266, 20);
			this.WORKER_STATUS_LABEL.TabIndex = 14;
			this.WORKER_STATUS_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CHAMP_IMAGE
			// 
			this.CHAMP_IMAGE.Image = global::LOLFirstPick.Properties.Resources.zed;
			this.CHAMP_IMAGE.Location = new System.Drawing.Point(11, 80);
			this.CHAMP_IMAGE.Name = "CHAMP_IMAGE";
			this.CHAMP_IMAGE.Size = new System.Drawing.Size(120, 120);
			this.CHAMP_IMAGE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.CHAMP_IMAGE.TabIndex = 1;
			this.CHAMP_IMAGE.TabStop = false;
			// 
			// flatButton1
			// 
			this.flatButton1.AnimationLerpP = 0.8F;
			this.flatButton1.BackColor = System.Drawing.Color.Transparent;
			this.flatButton1.ButtonText = "챔피언 변경";
			this.flatButton1.ButtonTextColor = System.Drawing.Color.Black;
			this.flatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.flatButton1.EnterStateBackgroundColor = System.Drawing.Color.Gainsboro;
			this.flatButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.flatButton1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.flatButton1.Location = new System.Drawing.Point(338, 191);
			this.flatButton1.Name = "flatButton1";
			this.flatButton1.NormalStateBackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.flatButton1.Size = new System.Drawing.Size(150, 41);
			this.flatButton1.TabIndex = 15;
			this.flatButton1.Text = "챔피언 변경";
			this.flatButton1.UseVisualStyleBackColor = false;
			// 
			// START_BUTTON
			// 
			this.START_BUTTON.AnimationLerpP = 0.8F;
			this.START_BUTTON.BackColor = System.Drawing.Color.Transparent;
			this.START_BUTTON.ButtonText = "선픽 시작하기";
			this.START_BUTTON.ButtonTextColor = System.Drawing.Color.Black;
			this.START_BUTTON.Cursor = System.Windows.Forms.Cursors.Hand;
			this.START_BUTTON.EnterStateBackgroundColor = System.Drawing.Color.Khaki;
			this.START_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.START_BUTTON.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.START_BUTTON.Location = new System.Drawing.Point(338, 238);
			this.START_BUTTON.Name = "START_BUTTON";
			this.START_BUTTON.NormalStateBackgroundColor = System.Drawing.Color.PaleGoldenrod;
			this.START_BUTTON.Size = new System.Drawing.Size(150, 50);
			this.START_BUTTON.TabIndex = 3;
			this.START_BUTTON.Text = "선픽 시작하기";
			this.START_BUTTON.UseVisualStyleBackColor = false;
			this.START_BUTTON.Click += new System.EventHandler(this.START_BUTTON_Click);
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
			this.CLOSE_BUTTON.Location = new System.Drawing.Point(460, 0);
			this.CLOSE_BUTTON.Name = "CLOSE_BUTTON";
			this.CLOSE_BUTTON.NormalStateBackgroundColor = System.Drawing.Color.IndianRed;
			this.CLOSE_BUTTON.Size = new System.Drawing.Size(40, 40);
			this.CLOSE_BUTTON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.CLOSE_BUTTON.TabIndex = 1;
			this.CLOSE_BUTTON.TabStop = false;
			this.CLOSE_BUTTON.Click += new System.EventHandler(this.CLOSE_BUTTON_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(500, 300);
			this.Controls.Add(this.flatButton1);
			this.Controls.Add(this.WORKER_STATUS_LABEL);
			this.Controls.Add(this.LOADING_GIFIMAGE);
			this.Controls.Add(this.TITLE_LABEL);
			this.Controls.Add(this.LINE_TITLE_LABEL);
			this.Controls.Add(this.LINE_CHAT_TEXTBOX);
			this.Controls.Add(this.FORCE_READY_CHECKBOX);
			this.Controls.Add(this.START_BUTTON);
			this.Controls.Add(this.CHAMP_TITLE_LABEL);
			this.Controls.Add(this.CHAMP_IMAGE);
			this.Controls.Add(this.APP_TITLE_BAR);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Main";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "퍼스트 롤";
			this.Load += new System.EventHandler(this.Main_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_Paint);
			this.APP_TITLE_BAR.ResumeLayout(false);
			this.APP_TITLE_BAR.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CHAMP_IMAGE)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CLOSE_BUTTON)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Panel APP_TITLE_BAR;
		private Interface.FlatImageButton CLOSE_BUTTON;
		private Interface.CustomLabel APP_TITLE;
		private System.Windows.Forms.PictureBox CHAMP_IMAGE;
		private System.Windows.Forms.Label CHAMP_TITLE_LABEL;
		private Interface.FlatButton START_BUTTON;
		private System.Windows.Forms.CheckBox FORCE_READY_CHECKBOX;
		private System.Windows.Forms.TextBox LINE_CHAT_TEXTBOX;
		private System.Windows.Forms.Label LINE_TITLE_LABEL;
		private System.Windows.Forms.Label TITLE_LABEL;
		private System.Windows.Forms.WebBrowser LOADING_GIFIMAGE;
		private System.Windows.Forms.Label WORKER_STATUS_LABEL;
		private Interface.FlatButton flatButton1;
	}
}


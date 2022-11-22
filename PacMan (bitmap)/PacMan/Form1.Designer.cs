namespace PacMan
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PacImagelist = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.blockImageList = new System.Windows.Forms.ImageList(this.components);
            this.ghostImageList = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.mapImage = new System.Windows.Forms.ImageList(this.components);
            this.BoardPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PacImagelist
            // 
            this.PacImagelist.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("PacImagelist.ImageStream")));
            this.PacImagelist.TransparentColor = System.Drawing.Color.Transparent;
            this.PacImagelist.Images.SetKeyName(0, "Pacman 1 0.png");
            this.PacImagelist.Images.SetKeyName(1, "Pacman 1 1.png");
            this.PacImagelist.Images.SetKeyName(2, "Pacman 1 2.png");
            this.PacImagelist.Images.SetKeyName(3, "Pacman 1 3.png");
            this.PacImagelist.Images.SetKeyName(4, "Pacman 2 0.png");
            this.PacImagelist.Images.SetKeyName(5, "Pacman 2 1.png");
            this.PacImagelist.Images.SetKeyName(6, "Pacman 2 2.png");
            this.PacImagelist.Images.SetKeyName(7, "Pacman 2 3.png");
            this.PacImagelist.Images.SetKeyName(8, "Pacman 3 0.png");
            this.PacImagelist.Images.SetKeyName(9, "Pacman 3 1.png");
            this.PacImagelist.Images.SetKeyName(10, "Pacman 3 2.png");
            this.PacImagelist.Images.SetKeyName(11, "Pacman 3 3.png");
            this.PacImagelist.Images.SetKeyName(12, "Pacman 4 0.png");
            this.PacImagelist.Images.SetKeyName(13, "Pacman 4 1.png");
            this.PacImagelist.Images.SetKeyName(14, "Pacman 4 2.png");
            this.PacImagelist.Images.SetKeyName(15, "Pacman 4 3.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label1.Font = new System.Drawing.Font("굴림", 14F);
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(506, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // blockImageList
            // 
            this.blockImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("blockImageList.ImageStream")));
            this.blockImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.blockImageList.Images.SetKeyName(0, "Block 1.png");
            this.blockImageList.Images.SetKeyName(1, "Block 2.png");
            this.blockImageList.Images.SetKeyName(2, "Item1.png");
            // 
            // ghostImageList
            // 
            this.ghostImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ghostImageList.ImageStream")));
            this.ghostImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ghostImageList.Images.SetKeyName(0, "eyes.png");
            this.ghostImageList.Images.SetKeyName(1, "Ghost 0 1.png");
            this.ghostImageList.Images.SetKeyName(2, "Ghost 0 2.png");
            this.ghostImageList.Images.SetKeyName(3, "Ghost 0 3.png");
            this.ghostImageList.Images.SetKeyName(4, "Ghost 0 4.png");
            this.ghostImageList.Images.SetKeyName(5, "Ghost 1 1.png");
            this.ghostImageList.Images.SetKeyName(6, "Ghost 1 2.png");
            this.ghostImageList.Images.SetKeyName(7, "Ghost 1 3.png");
            this.ghostImageList.Images.SetKeyName(8, "Ghost 1 4.png");
            this.ghostImageList.Images.SetKeyName(9, "Ghost 2 1.png");
            this.ghostImageList.Images.SetKeyName(10, "Ghost 2 2.png");
            this.ghostImageList.Images.SetKeyName(11, "Ghost 2 3.png");
            this.ghostImageList.Images.SetKeyName(12, "Ghost 2 4.png");
            this.ghostImageList.Images.SetKeyName(13, "Ghost 3 1.png");
            this.ghostImageList.Images.SetKeyName(14, "Ghost 3 2.png");
            this.ghostImageList.Images.SetKeyName(15, "Ghost 3 3.png");
            this.ghostImageList.Images.SetKeyName(16, "Ghost 3 4.png");
            this.ghostImageList.Images.SetKeyName(17, "Ghost 4.png");
            this.ghostImageList.Images.SetKeyName(18, "Ghost 5.png");
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("굴림", 14F);
            this.button1.Location = new System.Drawing.Point(510, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 50);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("굴림", 14F);
            this.button2.Location = new System.Drawing.Point(510, 112);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 50);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // mapImage
            // 
            this.mapImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mapImage.ImageStream")));
            this.mapImage.TransparentColor = System.Drawing.Color.Transparent;
            this.mapImage.Images.SetKeyName(0, "background.png");
            this.mapImage.Images.SetKeyName(1, "background.png");
            // 
            // BoardPanel
            // 
            this.BoardPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BoardPanel.BackgroundImage = global::PacMan.Properties.Resources.background;
            this.BoardPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BoardPanel.Location = new System.Drawing.Point(0, 0);
            this.BoardPanel.Name = "BoardPanel";
            this.BoardPanel.Size = new System.Drawing.Size(500, 555);
            this.BoardPanel.TabIndex = 0;
            this.BoardPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BoardPanel_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 557);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BoardPanel);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList PacImagelist;
        private System.Windows.Forms.ImageList blockImageList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList ghostImageList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ImageList mapImage;
        public System.Windows.Forms.Panel BoardPanel;
    }
}


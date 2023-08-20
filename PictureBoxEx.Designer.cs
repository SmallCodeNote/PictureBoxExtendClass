namespace PanelPictureBoxSet
{
    partial class PictureBoxEx
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.PictureBoxEx_Panel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_LoadFile = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button_Reset = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label_MouseInfo = new System.Windows.Forms.Label();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.button_Center = new System.Windows.Forms.Button();
            this.PictureBoxEx_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxEx_Panel
            // 
            this.PictureBoxEx_Panel.Controls.Add(this.pictureBox1);
            this.PictureBoxEx_Panel.Location = new System.Drawing.Point(1, 0);
            this.PictureBoxEx_Panel.Name = "PictureBoxEx_Panel";
            this.PictureBoxEx_Panel.Size = new System.Drawing.Size(481, 471);
            this.PictureBoxEx_Panel.TabIndex = 0;
            this.PictureBoxEx_Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxEx_Panel_MouseDown);
            this.PictureBoxEx_Panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBoxEx_Panel_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxEx_Panel_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.PictureBoxEx_Panel_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.PictureBoxEx_Panel_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxEx_Panel_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBoxEx_Panel_MouseUp);
            // 
            // button_LoadFile
            // 
            this.button_LoadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_LoadFile.Location = new System.Drawing.Point(482, 476);
            this.button_LoadFile.Name = "button_LoadFile";
            this.button_LoadFile.Size = new System.Drawing.Size(25, 25);
            this.button_LoadFile.TabIndex = 1;
            this.button_LoadFile.Text = "...";
            this.button_LoadFile.UseVisualStyleBackColor = true;
            this.button_LoadFile.Click += new System.EventHandler(this.button_LoadFile_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(2, 512);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Minimum = 10;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(480, 69);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickFrequency = 50;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 100;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // button_Reset
            // 
            this.button_Reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Reset.Location = new System.Drawing.Point(482, 546);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(25, 25);
            this.button_Reset.TabIndex = 3;
            this.button_Reset.Text = "R";
            this.button_Reset.UseVisualStyleBackColor = true;
            this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(396, 550);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(80, 25);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label_MouseInfo
            // 
            this.label_MouseInfo.AutoSize = true;
            this.label_MouseInfo.Location = new System.Drawing.Point(3, 558);
            this.label_MouseInfo.Name = "label_MouseInfo";
            this.label_MouseInfo.Size = new System.Drawing.Size(20, 18);
            this.label_MouseInfo.TabIndex = 5;
            this.label_MouseInfo.Text = "...";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(482, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(30, 471);
            this.vScrollBar1.TabIndex = 6;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(2, 474);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(466, 30);
            this.hScrollBar1.TabIndex = 7;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // button_Center
            // 
            this.button_Center.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Center.Location = new System.Drawing.Point(482, 512);
            this.button_Center.Name = "button_Center";
            this.button_Center.Size = new System.Drawing.Size(25, 25);
            this.button_Center.TabIndex = 8;
            this.button_Center.Text = "C";
            this.button_Center.UseVisualStyleBackColor = true;
            this.button_Center.Click += new System.EventHandler(this.button_Center_Click);
            // 
            // PictureBoxEx
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.button_Center);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.label_MouseInfo);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button_Reset);
            this.Controls.Add(this.button_LoadFile);
            this.Controls.Add(this.PictureBoxEx_Panel);
            this.Controls.Add(this.trackBar1);
            this.Name = "PictureBoxEx";
            this.Size = new System.Drawing.Size(512, 582);
            this.SizeChanged += new System.EventHandler(this.PictureBoxEx_SizeChanged);
            this.PictureBoxEx_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PictureBoxEx_Panel;
        private System.Windows.Forms.Button button_LoadFile;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_Reset;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label_MouseInfo;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Button button_Center;
    }
}

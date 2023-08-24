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
            this.panel_PictureBox = new System.Windows.Forms.Panel();
            this.pictureBox_View = new System.Windows.Forms.PictureBox();
            this.button_LoadFile = new System.Windows.Forms.Button();
            this.trackBar_ExpaningFactor = new System.Windows.Forms.TrackBar();
            this.button_Reset = new System.Windows.Forms.Button();
            this.numericUpDown_ExpaningFactor = new System.Windows.Forms.NumericUpDown();
            this.label_MouseInfo = new System.Windows.Forms.Label();
            this.vScrollBar_Panel = new System.Windows.Forms.VScrollBar();
            this.hScrollBar_Panel = new System.Windows.Forms.HScrollBar();
            this.button_Center = new System.Windows.Forms.Button();
            this.panel_PictureBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_ExpaningFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ExpaningFactor)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_PictureBox
            // 
            this.panel_PictureBox.Controls.Add(this.pictureBox_View);
            this.panel_PictureBox.Location = new System.Drawing.Point(1, 0);
            this.panel_PictureBox.Name = "panel_PictureBox";
            this.panel_PictureBox.Size = new System.Drawing.Size(481, 471);
            this.panel_PictureBox.TabIndex = 0;
            this.panel_PictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxEx_Panel_MouseDown);
            this.panel_PictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBoxEx_Panel_MouseUp);
            // 
            // pictureBox_View
            // 
            this.pictureBox_View.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_View.Name = "pictureBox_View";
            this.pictureBox_View.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_View.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_View.TabIndex = 0;
            this.pictureBox_View.TabStop = false;
            this.pictureBox_View.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxEx_Panel_MouseDown);
            this.pictureBox_View.MouseEnter += new System.EventHandler(this.PictureBoxEx_Panel_MouseEnter);
            this.pictureBox_View.MouseLeave += new System.EventHandler(this.PictureBoxEx_Panel_MouseLeave);
            this.pictureBox_View.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxEx_Panel_MouseMove);
            this.pictureBox_View.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBoxEx_Panel_MouseUp);
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
            // trackBar_ExpaningFactor
            // 
            this.trackBar_ExpaningFactor.Location = new System.Drawing.Point(2, 512);
            this.trackBar_ExpaningFactor.Maximum = 1000;
            this.trackBar_ExpaningFactor.Minimum = 10;
            this.trackBar_ExpaningFactor.Name = "trackBar_ExpaningFactor";
            this.trackBar_ExpaningFactor.Size = new System.Drawing.Size(480, 69);
            this.trackBar_ExpaningFactor.TabIndex = 2;
            this.trackBar_ExpaningFactor.TickFrequency = 50;
            this.trackBar_ExpaningFactor.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_ExpaningFactor.Value = 100;
            this.trackBar_ExpaningFactor.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
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
            // numericUpDown_ExpaningFactor
            // 
            this.numericUpDown_ExpaningFactor.Location = new System.Drawing.Point(396, 550);
            this.numericUpDown_ExpaningFactor.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_ExpaningFactor.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_ExpaningFactor.Name = "numericUpDown_ExpaningFactor";
            this.numericUpDown_ExpaningFactor.Size = new System.Drawing.Size(80, 25);
            this.numericUpDown_ExpaningFactor.TabIndex = 4;
            this.numericUpDown_ExpaningFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_ExpaningFactor.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_ExpaningFactor.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
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
            // vScrollBar_Panel
            // 
            this.vScrollBar_Panel.Location = new System.Drawing.Point(482, 0);
            this.vScrollBar_Panel.Name = "vScrollBar_Panel";
            this.vScrollBar_Panel.Size = new System.Drawing.Size(30, 471);
            this.vScrollBar_Panel.TabIndex = 6;
            this.vScrollBar_Panel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // hScrollBar_Panel
            // 
            this.hScrollBar_Panel.Location = new System.Drawing.Point(2, 474);
            this.hScrollBar_Panel.Name = "hScrollBar_Panel";
            this.hScrollBar_Panel.Size = new System.Drawing.Size(466, 30);
            this.hScrollBar_Panel.TabIndex = 7;
            this.hScrollBar_Panel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
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
            this.Controls.Add(this.hScrollBar_Panel);
            this.Controls.Add(this.vScrollBar_Panel);
            this.Controls.Add(this.label_MouseInfo);
            this.Controls.Add(this.numericUpDown_ExpaningFactor);
            this.Controls.Add(this.button_Reset);
            this.Controls.Add(this.button_LoadFile);
            this.Controls.Add(this.panel_PictureBox);
            this.Controls.Add(this.trackBar_ExpaningFactor);
            this.Name = "PictureBoxEx";
            this.Size = new System.Drawing.Size(512, 582);
            this.SizeChanged += new System.EventHandler(this.PictureBoxEx_SizeChanged);
            this.panel_PictureBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_ExpaningFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ExpaningFactor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_PictureBox;
        private System.Windows.Forms.Button button_LoadFile;
        private System.Windows.Forms.TrackBar trackBar_ExpaningFactor;
        private System.Windows.Forms.PictureBox pictureBox_View;
        private System.Windows.Forms.Button button_Reset;
        private System.Windows.Forms.NumericUpDown numericUpDown_ExpaningFactor;
        private System.Windows.Forms.Label label_MouseInfo;
        private System.Windows.Forms.VScrollBar vScrollBar_Panel;
        private System.Windows.Forms.HScrollBar hScrollBar_Panel;
        private System.Windows.Forms.Button button_Center;
    }
}

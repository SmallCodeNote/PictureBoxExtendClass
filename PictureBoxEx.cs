using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanelPictureBoxSet
{
    public partial class PictureBoxEx : UserControl
    {

        Point MouseLocation_MouseDown;
        Point MouseLocation_Now;
        bool MouseLeftDown = false;
        bool MouseRightDown = false;
        bool MouseMiddleDown = false;
        bool MouseOnImage = false;

        /// <summary>
        /// image expanding focus point on image coordinate
        /// </summary>
        Point imageFocusPoint;

        /// <summary>
        /// image expanding focus point on panel coordinate
        /// </summary>
        Point panelFocusPoint;


        public PictureBoxEx()
        {
            InitializeComponent();

            this.trackBar1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.MouseWheelEvent);
            this.pictureBox1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.MouseWheelEvent);
            imageFocusPoint = new Point(0, 0);
            panelFocusPoint = new Point(0, 0);

        }

        /// <summary>
        /// Control margin
        /// </summary>
        private int m = 0;

        /// <summary>
        /// Control Layout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlLayout(int ctrWidth, int ctrHeight)
        {
            //PictureBoxEx_Panel
            this.PictureBoxEx_Panel.Width
                = ctrWidth - m
                - this.vScrollBar1.Width - m;

            this.PictureBoxEx_Panel.Height
                = ctrHeight - m
                - this.trackBar1.Height - m
                - this.hScrollBar1.Height - m;

            //hScrollBar
            this.hScrollBar1.Width = this.PictureBoxEx_Panel.Width;
            this.hScrollBar1.Left = 0;
            this.hScrollBar1.Top = this.PictureBoxEx_Panel.Height + m;
            this.hScrollBar1.Enabled = false;

            //vScrollBar
            this.vScrollBar1.Height = this.PictureBoxEx_Panel.Height;
            this.vScrollBar1.Left = this.PictureBoxEx_Panel.Width + m;
            this.vScrollBar1.Top = 0;
            this.vScrollBar1.Enabled = false;

            //button_LoadFile
            this.button_LoadFile.Left = ctrWidth - m - this.button_LoadFile.Width;
            this.button_LoadFile.Top = ctrHeight - m - button_Reset.Height - m - button_Center.Height - m - this.button_LoadFile.Height;

            this.button_Center.Left = ctrWidth - m - this.button_Center.Width;
            this.button_Center.Top = ctrHeight - m - button_Reset.Height - m - button_Center.Height;

            this.button_Reset.Left = ctrWidth - m - this.button_Reset.Width;
            this.button_Reset.Top = ctrHeight - m - button_Reset.Height;

            //TrackBar
            this.trackBar1.Width = this.PictureBoxEx_Panel.Width;
            this.trackBar1.Left = 0;
            this.trackBar1.Top = this.PictureBoxEx_Panel.Height + m + hScrollBar1.Height;

            //NumericUpDown
            this.numericUpDown1.Left = ctrWidth - m - this.button_Reset.Width - m * 2 - this.numericUpDown1.Width;
            this.numericUpDown1.Top = ctrHeight - m - this.numericUpDown1.Height;

            //Label
            this.label_MouseInfo.Left = 0;
            this.label_MouseInfo.Top = ctrHeight - m - this.label_MouseInfo.Height;
            
        }

        private void expandPictureBox(Point imageFocusPoint, Point panelFocusPoint)
        {

            if (this.pictureBox1.Image != null)
            {
                int Factor = this.trackBar1.Value;

                this.pictureBox1.Width = (this.pictureBox1.Image.Width * Factor) / 100;
                this.pictureBox1.Height = (this.pictureBox1.Image.Height * Factor) / 100;

                this.pictureBox1.Left = -(imageFocusPoint.X * Factor) / 100 + panelFocusPoint.X;
                this.pictureBox1.Top = -(imageFocusPoint.Y * Factor) / 100 + panelFocusPoint.Y;

            }

            updateScrollBarParam();
            getMouseReport();

        }

        private void updateScrollBarParam()
        {
            if (this.pictureBox1.Image.Width > this.PictureBoxEx_Panel.Width)
            {
                this.hScrollBar1.Enabled = true;
                this.hScrollBar1.Maximum = this.pictureBox1.Image.Width;
                this.hScrollBar1.LargeChange = this.PictureBoxEx_Panel.Width;
            }

            if (this.pictureBox1.Image.Height > this.PictureBoxEx_Panel.Height)
            {
                this.vScrollBar1.Enabled = true;
                this.vScrollBar1.Maximum = this.pictureBox1.Image.Height;
                this.vScrollBar1.LargeChange = this.PictureBoxEx_Panel.Height;
            }

        }

        private bool updateScrollBarPosition()
        {
            try
            {
                this.hScrollBar1.Value = -pictureBox1.Location.X;
                this.vScrollBar1.Value = -pictureBox1.Location.Y;
            }
            catch { return false; }

            return true;
        }


        public void setPictureBox(PictureBox p, string imageFilePath)
        {
            if (p.Image != null) p.Image.Dispose();

            Bitmap bitmap = new Bitmap(imageFilePath);
            p.Image = bitmap;
            p.Width = (bitmap.Width * this.trackBar1.Value) /100;
            p.Height = (bitmap.Height * this.trackBar1.Value) / 100;

        }


        private int viewScaleStep_MouseWheel = 10;

        private void MouseWheelEvent(object sender, MouseEventArgs e)
        {
            if (sender == trackBar1) {
                setPanelFocusPointOnCenter();
                setImageFocusPointFromViewCenter();
            }

            if (e.Delta > 0)
            {
                this.trackBar1.Value = this.trackBar1.Value < this.trackBar1.Maximum- viewScaleStep_MouseWheel ? this.trackBar1.Value + viewScaleStep_MouseWheel : this.trackBar1.Maximum;
            }
            else
            {
                this.trackBar1.Value = this.trackBar1.Value > this.trackBar1.Minimum+ viewScaleStep_MouseWheel ? this.trackBar1.Value - viewScaleStep_MouseWheel : this.trackBar1.Minimum;
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="X">pictureBox coordinate</param>
        /// <param name="Y">pictureBox coordinate</param>
        private void setImageFocusPoint(int X, int Y)
        {
            int Factor = this.trackBar1.Value;

            imageFocusPoint.X = (X * 100) / Factor;
            imageFocusPoint.Y = (Y * 100) / Factor;

            getMouseReport();
        }

        private void setImageFocusPointFromViewCenter()
        {
            if (this.pictureBox1.Image != null)
            {
                int Factor = this.trackBar1.Value;
                imageFocusPoint.X = ((-this.pictureBox1.Left + this.PictureBoxEx_Panel.Width / 2) * 100) / Factor;
                imageFocusPoint.Y = ((-this.pictureBox1.Top + this.PictureBoxEx_Panel.Height / 2) * 100) / Factor;
            }

            getMouseReport();

        }

        private void setImageFocusPointFromImageCenter()
        {
            if (this.pictureBox1.Image != null)
            {
                imageFocusPoint.X = this.pictureBox1.Image.Width / 2;
                imageFocusPoint.Y = this.pictureBox1.Image.Height / 2;
            }
            getMouseReport();
        }

        private void setPanelFocusPointFromImagePoint(int X, int Y)
        {
            if (this.pictureBox1.Image != null)
            {
                panelFocusPoint.X = X + this.pictureBox1.Location.X;
                panelFocusPoint.Y = Y + this.pictureBox1.Location.Y;
            }

            getMouseReport();
        }


        private void setPanelFocusPointOnCenter()
        {
            panelFocusPoint.X = this.PictureBoxEx_Panel.Width / 2;
            panelFocusPoint.Y = this.PictureBoxEx_Panel.Height / 2;
            getMouseReport();
        }


        private string getMouseReport()
        {
            string report = imageFocusPoint.ToString() + " " +
                //MouseLocation_Now.ToString() + " " +
                panelFocusPoint.ToString() + " " +
                (MouseLeftDown ? 1 : 0).ToString() + " " +
                (MouseRightDown ? 1 : 0).ToString() + " " +
                (MouseMiddleDown ? 1 : 0).ToString() + " " +
                (MouseOnImage ? 1 : 0).ToString()
                ;

            this.label_MouseInfo.Text = report;
            return report;

        }

        private void button_LoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "png|*.png|jpg|*.jpg";

            if (ofd.ShowDialog() != DialogResult.OK) return;

            setPictureBox(this.pictureBox1, ofd.FileName);
            this.pictureBox1.Top = 0;
            this.pictureBox1.Left = 0;

            updateScrollBarParam();
            updateScrollBarPosition();

            setImageFocusPointFromImageCenter();
            setPanelFocusPointOnCenter();

            getMouseReport();
        }


        private void button_Reset_Click(object sender, EventArgs e)
        {
            this.trackBar1.Value = 100;
            this.pictureBox1.Top = 0;
            this.pictureBox1.Left = 0;

            setImageFocusPointFromImageCenter();
            setPanelFocusPointOnCenter();

            updateScrollBarPosition();

            getMouseReport();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.numericUpDown1.Value = ((TrackBar)sender).Value;

            expandPictureBox(imageFocusPoint, panelFocusPoint);
            updateScrollBarParam();

            getMouseReport();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.trackBar1.Value = (int)((NumericUpDown)sender).Value;
        }



        private void PictureBoxEx_Panel_MouseDown(object sender, MouseEventArgs e)
        {
            MouseLocation_MouseDown = e.Location;
            if (e.Button == MouseButtons.Left) MouseLeftDown = true;
            if (e.Button == MouseButtons.Middle) MouseMiddleDown = true;
            if (e.Button == MouseButtons.Right) MouseRightDown = true;

            getMouseReport();
        }

        private void PictureBoxEx_Panel_MouseUp(object sender, MouseEventArgs e)
        {
            MouseLocation_MouseDown = e.Location;
            if (e.Button == MouseButtons.Left) MouseLeftDown = false;
            if (e.Button == MouseButtons.Middle) MouseMiddleDown = false;
            if (e.Button == MouseButtons.Right) MouseRightDown = false;

            getMouseReport();

        }

        private void PictureBoxEx_Panel_MouseEnter(object sender, EventArgs e)
        {
            MouseOnImage = true;
            getMouseReport();
        }

        private void PictureBoxEx_Panel_MouseLeave(object sender, EventArgs e)
        {
            MouseOnImage = false;
            setPanelFocusPointOnCenter();
            setImageFocusPointFromViewCenter();
           
            getMouseReport();
        }

        private void PictureBoxEx_Panel_MouseMove(object sender, MouseEventArgs e)
        {
            MouseLocation_Now = e.Location;
            
            if (MouseOnImage) setPanelFocusPointFromImagePoint(e.X, e.Y);
            if (MouseOnImage) setImageFocusPoint(e.X, e.Y);

            if (MouseMiddleDown)
            {
                Point pb = this.pictureBox1.Location;
                int newLeft = pb.X + MouseLocation_Now.X - MouseLocation_MouseDown.X;
                int newTop = pb.Y + MouseLocation_Now.Y - MouseLocation_MouseDown.Y;

                //if (-newTop >= vScrollBar1.Minimum && -newTop <= vScrollBar1.Maximum - this.PictureBoxEx_Panel.Height)
                {
                    this.pictureBox1.Top = newTop;
                }
                //if (-newLeft >= hScrollBar1.Minimum && -newLeft <= hScrollBar1.Maximum - this.PictureBoxEx_Panel.Width)
                {
                    this.pictureBox1.Left = newLeft;
                }

                updateScrollBarPosition();

            }

            getMouseReport();

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.pictureBox1.Top = -this.vScrollBar1.Value;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.pictureBox1.Left = -this.hScrollBar1.Value;
        }

        private void button_Center_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Left = - this.pictureBox1.Width / 2 + this.PictureBoxEx_Panel.Width/2;
            this.pictureBox1.Top = -this.pictureBox1.Height/2 + this.PictureBoxEx_Panel.Height / 2;

            updateScrollBarPosition();

            setPanelFocusPointOnCenter();
            setImageFocusPointFromImageCenter();
            
            getMouseReport();
        }


        private void PictureBoxEx_SizeChanged(object sender, EventArgs e)
        {
            int ctrWidth = ((PictureBoxEx)sender).Width;
            int ctrHeight = ((PictureBoxEx)sender).Height;

            ControlLayout(ctrWidth, ctrHeight);
        }

    }
}

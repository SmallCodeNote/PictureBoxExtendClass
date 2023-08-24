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

            this.trackBar_ExpaningFactor.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.MouseWheelEvent);
            this.pictureBox_View.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.MouseWheelEvent);
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
            this.panel_PictureBox.Width
                = ctrWidth - m
                - this.vScrollBar_Panel.Width - m;

            this.panel_PictureBox.Height
                = ctrHeight - m
                - this.trackBar_ExpaningFactor.Height - m
                - this.hScrollBar_Panel.Height - m;

            //hScrollBar
            this.hScrollBar_Panel.Width = this.panel_PictureBox.Width;
            this.hScrollBar_Panel.Left = 0;
            this.hScrollBar_Panel.Top = this.panel_PictureBox.Height + m;
            this.hScrollBar_Panel.Enabled = false;

            //vScrollBar
            this.vScrollBar_Panel.Height = this.panel_PictureBox.Height;
            this.vScrollBar_Panel.Left = this.panel_PictureBox.Width + m;
            this.vScrollBar_Panel.Top = 0;
            this.vScrollBar_Panel.Enabled = false;

            //button_LoadFile
            this.button_LoadFile.Left = ctrWidth - m - this.button_LoadFile.Width;
            this.button_LoadFile.Top = ctrHeight - m - button_Reset.Height - m - button_Center.Height - m - this.button_LoadFile.Height;

            this.button_Center.Left = ctrWidth - m - this.button_Center.Width;
            this.button_Center.Top = ctrHeight - m - button_Reset.Height - m - button_Center.Height;

            this.button_Reset.Left = ctrWidth - m - this.button_Reset.Width;
            this.button_Reset.Top = ctrHeight - m - button_Reset.Height;

            //TrackBar
            this.trackBar_ExpaningFactor.Width = this.panel_PictureBox.Width;
            this.trackBar_ExpaningFactor.Left = 0;
            this.trackBar_ExpaningFactor.Top = this.panel_PictureBox.Height + m + hScrollBar_Panel.Height;

            //NumericUpDown
            this.numericUpDown_ExpaningFactor.Left = ctrWidth - m - this.button_Reset.Width - m * 2 - this.numericUpDown_ExpaningFactor.Width;
            this.numericUpDown_ExpaningFactor.Top = ctrHeight - m - this.numericUpDown_ExpaningFactor.Height;

            //Label
            this.label_MouseInfo.Left = 0;
            this.label_MouseInfo.Top = ctrHeight - m - this.label_MouseInfo.Height;
            
        }

        private void expandPictureBox(Point imageFocusPoint, Point panelFocusPoint)
        {

            if (this.pictureBox_View.Image != null)
            {
                int Factor = this.trackBar_ExpaningFactor.Value;

                this.pictureBox_View.Width = (this.pictureBox_View.Image.Width * Factor) / 100;
                this.pictureBox_View.Height = (this.pictureBox_View.Image.Height * Factor) / 100;

                this.pictureBox_View.Left = -(imageFocusPoint.X * Factor) / 100 + panelFocusPoint.X;
                this.pictureBox_View.Top = -(imageFocusPoint.Y * Factor) / 100 + panelFocusPoint.Y;

            }

            updateScrollBarParam();
            getMouseReport();

        }

        private void updateScrollBarParam()
        {
            if (this.pictureBox_View.Image.Width > this.panel_PictureBox.Width)
            {
                this.hScrollBar_Panel.Enabled = true;
                this.hScrollBar_Panel.Maximum = this.pictureBox_View.Image.Width;
                this.hScrollBar_Panel.LargeChange = this.panel_PictureBox.Width;
            }

            if (this.pictureBox_View.Image.Height > this.panel_PictureBox.Height)
            {
                this.vScrollBar_Panel.Enabled = true;
                this.vScrollBar_Panel.Maximum = this.pictureBox_View.Image.Height;
                this.vScrollBar_Panel.LargeChange = this.panel_PictureBox.Height;
            }

        }

        private bool updateScrollBarPosition()
        {
            try
            {
                this.hScrollBar_Panel.Value = -pictureBox_View.Location.X;
                this.vScrollBar_Panel.Value = -pictureBox_View.Location.Y;
            }
            catch { return false; }

            return true;
        }


        public void setPictureBox(PictureBox p, string imageFilePath)
        {
            if (p.Image != null) p.Image.Dispose();

            Bitmap bitmap = new Bitmap(imageFilePath);
            p.Image = bitmap;
            p.Width = (bitmap.Width * this.trackBar_ExpaningFactor.Value) /100;
            p.Height = (bitmap.Height * this.trackBar_ExpaningFactor.Value) / 100;

        }


        private int viewScaleStep_MouseWheel = 10;

        private void MouseWheelEvent(object sender, MouseEventArgs e)
        {
            if (sender == trackBar_ExpaningFactor) {
                setPanelFocusPointOnCenter();
                setImageFocusPointFromViewCenter();
            }

            if (e.Delta > 0)
            {
                this.trackBar_ExpaningFactor.Value = this.trackBar_ExpaningFactor.Value < this.trackBar_ExpaningFactor.Maximum- viewScaleStep_MouseWheel ? this.trackBar_ExpaningFactor.Value + viewScaleStep_MouseWheel : this.trackBar_ExpaningFactor.Maximum;
            }
            else
            {
                this.trackBar_ExpaningFactor.Value = this.trackBar_ExpaningFactor.Value > this.trackBar_ExpaningFactor.Minimum+ viewScaleStep_MouseWheel ? this.trackBar_ExpaningFactor.Value - viewScaleStep_MouseWheel : this.trackBar_ExpaningFactor.Minimum;
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="X">pictureBox coordinate</param>
        /// <param name="Y">pictureBox coordinate</param>
        private void setImageFocusPoint(int X, int Y)
        {
            int Factor = this.trackBar_ExpaningFactor.Value;

            imageFocusPoint.X = (X * 100) / Factor;
            imageFocusPoint.Y = (Y * 100) / Factor;

            getMouseReport();
        }

        private void setImageFocusPointFromViewCenter()
        {
            if (this.pictureBox_View.Image != null)
            {
                int Factor = this.trackBar_ExpaningFactor.Value;
                imageFocusPoint.X = ((-this.pictureBox_View.Left + this.panel_PictureBox.Width / 2) * 100) / Factor;
                imageFocusPoint.Y = ((-this.pictureBox_View.Top + this.panel_PictureBox.Height / 2) * 100) / Factor;
            }

            getMouseReport();

        }

        private void setImageFocusPointFromImageCenter()
        {
            if (this.pictureBox_View.Image != null)
            {
                imageFocusPoint.X = this.pictureBox_View.Image.Width / 2;
                imageFocusPoint.Y = this.pictureBox_View.Image.Height / 2;
            }
            getMouseReport();
        }

        private void setPanelFocusPointFromImagePoint(int X, int Y)
        {
            if (this.pictureBox_View.Image != null)
            {
                panelFocusPoint.X = X + this.pictureBox_View.Location.X;
                panelFocusPoint.Y = Y + this.pictureBox_View.Location.Y;
            }

            getMouseReport();
        }


        private void setPanelFocusPointOnCenter()
        {
            panelFocusPoint.X = this.panel_PictureBox.Width / 2;
            panelFocusPoint.Y = this.panel_PictureBox.Height / 2;
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

            setPictureBox(this.pictureBox_View, ofd.FileName);
            this.pictureBox_View.Top = 0;
            this.pictureBox_View.Left = 0;

            updateScrollBarParam();
            updateScrollBarPosition();

            setImageFocusPointFromImageCenter();
            setPanelFocusPointOnCenter();

            getMouseReport();
        }


        private void button_Reset_Click(object sender, EventArgs e)
        {
            this.trackBar_ExpaningFactor.Value = 100;
            this.pictureBox_View.Top = 0;
            this.pictureBox_View.Left = 0;

            setImageFocusPointFromImageCenter();
            setPanelFocusPointOnCenter();

            updateScrollBarPosition();

            getMouseReport();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.numericUpDown_ExpaningFactor.Value = ((TrackBar)sender).Value;

            expandPictureBox(imageFocusPoint, panelFocusPoint);
            updateScrollBarParam();

            getMouseReport();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.trackBar_ExpaningFactor.Value = (int)((NumericUpDown)sender).Value;
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
                Point pb = this.pictureBox_View.Location;
                int newLeft = pb.X + MouseLocation_Now.X - MouseLocation_MouseDown.X;
                int newTop = pb.Y + MouseLocation_Now.Y - MouseLocation_MouseDown.Y;

                //if (-newTop >= vScrollBar1.Minimum && -newTop <= vScrollBar1.Maximum - this.PictureBoxEx_Panel.Height)
                {
                    this.pictureBox_View.Top = newTop;
                }
                //if (-newLeft >= hScrollBar1.Minimum && -newLeft <= hScrollBar1.Maximum - this.PictureBoxEx_Panel.Width)
                {
                    this.pictureBox_View.Left = newLeft;
                }

                updateScrollBarPosition();

            }

            getMouseReport();

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.pictureBox_View.Top = -this.vScrollBar_Panel.Value;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.pictureBox_View.Left = -this.hScrollBar_Panel.Value;
        }

        private void button_Center_Click(object sender, EventArgs e)
        {
            this.pictureBox_View.Left = - this.pictureBox_View.Width / 2 + this.panel_PictureBox.Width/2;
            this.pictureBox_View.Top = -this.pictureBox_View.Height/2 + this.panel_PictureBox.Height / 2;

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

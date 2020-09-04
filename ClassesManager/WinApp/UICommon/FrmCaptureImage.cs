using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge;
using System.Drawing.Imaging;
using ClassManager.WinApp.UICommon;

namespace ClassManager.WinApp
{
    public partial class FrmCaptureImage : FrmParentForm
    {
        public System.Drawing.Image capturedImage;
        const string sCaption = "Capture Image";
        public FrmCaptureImage()
        {
            InitializeComponent();
        }
        

        private void btnCapture_Click(object sender, EventArgs e)
        {
            capturedImage = (Bitmap)pictureBox1.Image.Clone();
            this.Close();
        }

        Webcam webcam;
        private void FrmCaptureImage_Load(object sender, EventArgs e)
        {
            try
            {
                //this.WindowState = FormWindowState.Maximized;

                webcam = new Webcam();
                webcam.InitializeWebCam(ref pictureBox1);
                webcam.Start();
                
            }
            catch (Exception ex)
            {
                ClassManager.Common.Log.LogError(ex, "Capture photo");
            }
        }

        private void FrmCaptureImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (webcam != null)
                {
                    webcam.Stop();
                    webcam = null;
                }
            }
            catch (Exception ex)
            {
                Common.Log.LogDBError(ex, "Capture image");
            }
            
        }
    }
}

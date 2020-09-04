using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Web;
using System.IO;
using System.Drawing.Drawing2D;
/// <summary>
/// Summary description for Utility
/// </summary>
/// 
namespace ClassManager.Common
{
    public class GraphicsUtility
    {
        public GraphicsUtility()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static bool resizeAndStoreImage(String filePath, int newWidth, int newHeight, Stream imageStream)
        {
            Image srcImage = Image.FromStream(imageStream);

            Bitmap newImage = new Bitmap(newWidth, newHeight);
            Graphics gr = Graphics.FromImage(newImage);

            gr.SmoothingMode = SmoothingMode.HighQuality;
            gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
            gr.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));

            newImage.Save(filePath);

            return true;
        }


        public static Image resizeImage(Image srcImage, int newWidth, int newHeight)
        {
            try
            {
                Bitmap newImage = new Bitmap(newWidth, newHeight);
                newImage.SetResolution(srcImage.HorizontalResolution, srcImage.VerticalResolution);

                Graphics gr = Graphics.FromImage(newImage);

                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));

                return newImage;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                
            }


            
        }
    }
}
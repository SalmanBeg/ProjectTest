using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace HRMS.Common.Helpers
{
    public static class BitmapUtils
    {

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Bitmap.FromStream(ms);

            return returnImage;
        }

        public static byte[] ResizeImageInByteArray(byte[] byteArrayIn, int iMaxHeight, int iMaxWidth)
        {
            Image img = byteArrayToImage(byteArrayIn);
            ResizeImage(ref img, iMaxHeight, iMaxWidth);
            return imageToByteArray(img);
        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        /// <summary>
        /// A bitmap gets resized.
        /// </summary>
        /// <param name="bmSource"></param>
        /// <param name="iMaxHeight"></param>
        /// <param name="iMaxWidth"></param>
        /// <remarks></remarks>
        public static void ResizeImage(ref Image bmSource, int iMaxHeight, int iMaxWidth)
        {
            //try
            //{
            decimal k = default(decimal);
            int iWidth = 0;
            int iHeight = 0;
            //bool bWidth = false;

            iHeight = bmSource.Height;
            iWidth = bmSource.Width;
            //make size fit the max width first
            if (iWidth > iMaxWidth)
            {
                k = (decimal)((decimal)iHeight / (decimal)iWidth);
                iWidth = iMaxWidth;
                iHeight = (int)(k * iWidth);
            }

            //if the height is still too tall, adjust again 
            if (iHeight > iMaxHeight & iMaxHeight > 0)
            {
                k = (decimal)((decimal)iWidth / (decimal)iHeight);
                iHeight = iMaxHeight;
                iWidth = (int)(k * iHeight);
            }

            Bitmap bm = new Bitmap(iWidth, iHeight);
            Graphics g = Graphics.FromImage(bm);
            g.DrawImage(bmSource, 0, 0, iWidth, iHeight);

            bmSource = bm;
        }


        /// <summary>
        /// Wrapper function for Resizing.
        /// </summary>
        /// <param name="bm"></param>
        /// <param name="sTargetPath"></param>
        /// <param name="iMaxHeight"></param>
        /// <param name="iMaxWidth"></param>
        /// <remarks></remarks>
        public static void ResizeAndSaveImage(Image bm, string sTargetPath, int iMaxHeight, int iMaxWidth)
        {
            HRMS.Common.Helpers.BitmapUtils.ResizeAndSaveImage(bm, sTargetPath, iMaxHeight, iMaxWidth, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        /// <summary>
        /// Wrapper function for Resizing.
        /// </summary>
        /// <param name="bm"></param>
        /// <param name="sTargetPath"></param>
        /// <param name="iMaxHeight"></param>
        /// <param name="iMaxWidth"></param>
        /// <param name="imgFormat"></param>
        /// <remarks></remarks>
        public static void ResizeAndSaveImage(Image bm, string sTargetPath, int iMaxHeight, int iMaxWidth, System.Drawing.Imaging.ImageFormat imgFormat)
        {
            if ((imgFormat == null)) imgFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
            HRMS.Common.Helpers.BitmapUtils.ResizeImage(ref bm, iMaxHeight, iMaxWidth);
            bm.Save(sTargetPath, imgFormat);
            bm.Dispose();
            bm = null;
        }

        /// <summary>
        /// Wrapper function for Resizing.
        /// </summary>
        /// <param name="sSourcePath"></param>
        /// <param name="sTargetPath"></param>
        /// <param name="iMaxHeight"></param>
        /// <param name="iMaxWidth"></param>
        /// <remarks></remarks>
        public static void ResizeAndSaveImage(string sSourcePath, string sTargetPath, int iMaxHeight, int iMaxWidth)
        {
            HRMS.Common.Helpers.BitmapUtils.ResizeAndSaveImage(sSourcePath, sTargetPath, iMaxHeight, iMaxWidth, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        /// <summary>
        /// Wrapper function for Resizing.
        /// </summary>
        /// <param name="sSourcePath"></param>
        /// <param name="sTargetPath"></param>
        /// <param name="iMaxHeight"></param>
        /// <param name="iMaxWidth"></param>
        /// <param name="imgFormat"></param>
        /// <remarks></remarks>
        public static void ResizeAndSaveImage(string sSourcePath, string sTargetPath, int iMaxHeight, int iMaxWidth, System.Drawing.Imaging.ImageFormat imgFormat)
        {
            if ((imgFormat == null)) imgFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
            Image bm = new Bitmap(sSourcePath);
            HRMS.Common.Helpers.BitmapUtils.ResizeImage(ref bm, iMaxHeight, iMaxWidth);
            bm.Save(sTargetPath, imgFormat);
            bm.Dispose();
            bm = null;
        }

    }
}
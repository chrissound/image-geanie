using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace Image_Geanie_v0._4
{
    class ImageCompare
    {
        public bool error = false;
        Bitmap img1;
        Bitmap img2;
        Bitmap imgHistogram = new Bitmap(768, 105);
        int[] imageMatchValue = new int[768];
        public int lowestMatch = 768;

        public ImageCompare(string img1src, string img2src)
        {
            if (File.Exists(img1src) && File.Exists(img2src))
            {
                 img1 = new Bitmap(img1src);
                 img2 = new Bitmap(img2src);

                if (img1.Size != img2.Size)
                {
                    error = true;
                }

            }
            else
            {
                error = true;
            }
        }

        public double compareImages()
        {
            int total = img1.Height * img1.Width * (3 * 256);
            int count = 0;

            for (int x = 0; x < img1.Width; x++)
            {
                for (int y = 0; y < img1.Height; y++)
                {
                    int pixelMatch = 0;
                    pixelMatch += 256 - Math.Abs(img1.GetPixel(x, y).R - img2.GetPixel(x, y).R);
                    pixelMatch += 256 - Math.Abs(img1.GetPixel(x, y).G - img2.GetPixel(x, y).G);
                    pixelMatch += 256 - Math.Abs(img1.GetPixel(x, y).B - img2.GetPixel(x, y).B);

                    count += pixelMatch;
                    imageMatchValue[pixelMatch - 1]++;

                    if (pixelMatch < lowestMatch)
                    { lowestMatch = pixelMatch; }
                }
            }

            double match = Convert.ToDouble(count) / total;
            return match;
        }

        public Bitmap getBitmapHistogram()
        {
            float maxCount = 0F;
            for (int i = 0; i < 768; i ++)
            {
                if (imageMatchValue[i] > maxCount)
                { maxCount = imageMatchValue[i]; }
            }

            for (int i = 768 / 2; i <= 768; i ++)
            {
               int height = Convert.ToInt16((imageMatchValue[i + (768 / 2)] / maxCount) * 100);
               imgHistogram.SetPixel(i, height + 4, Color.Red);
                imgHistogram.SetPixel(i + 1, height + 4, Color.Red);
            }

            for (int i = 0; i <= 767; i += 10)
            {
                imgHistogram.SetPixel(i, 104, Color.Blue);
            }
            for (int i = 0; i <= 767; i += 50)
            {
                imgHistogram.SetPixel(i, 103, Color.CornflowerBlue);
                imgHistogram.SetPixel(i, 102, Color.CornflowerBlue);
                imgHistogram.SetPixel(i, 101, Color.CornflowerBlue);
            }
            for (int i = 0; i <= 767; i += 50)
            {
                imgHistogram.SetPixel(i, 0, Color.Black);
                imgHistogram.SetPixel(i, 1, Color.Black);
                imgHistogram.SetPixel(i, 2, Color.Black);
                imgHistogram.SetPixel(i, 3, Color.Black);
                imgHistogram.SetPixel(i, 4, Color.Black);
            }
            
            return imgHistogram;
        }
    }
}

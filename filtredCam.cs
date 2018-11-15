using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiFaceRec
{
    public partial class filtredCam : Form
    {
        public filtredCam()
        {
            InitializeComponent();
        }

        public int brightness = 0, contrast = 6, gaussianKernelSize = 0, sigmaGaussian = 2, threasoldEqualize = 0, smoothGaussian = 0, smoothMedian = 0,
            MaxthreasoldBinarisation = 1, MinthreasoldBinarisation = 1, MaxthreasoldCanny = 160, MinthreasoldCanny = 80;

        private static byte ToByte(int Val) { if (Val > 255) Val = 255; else if (Val < 0) Val = 0; return (byte)Val; }


        public static unsafe Image<Bgr, Byte> brightnessImage(Image<Bgr, Byte> img, int Value)
        {
            Image<Bgr, Byte> res = img.Copy();
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {

                    res.SetValue(new Bgr(img[i, j].Blue + Value, img[i, j].Green + Value, img[i, j].Red + Value));
                }
            }
            return res;
        }

        public static unsafe Image<Bgr, Byte> contrastImage(Image<Bgr, Byte> img, int Value)
        {
            byte[] pixelBuffer = new byte[img.Width * img.Height];
            double contrastLevel = Math.Pow((100.0 + Value) / 100.0, 2);
            double blue = 0;
            double green = 0;
            double red = 0;
            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                blue = ((((pixelBuffer[k] / 255.0) - 0.5) *
                            contrastLevel) + 0.5) * 255.0;


                green = ((((pixelBuffer[k + 1] / 255.0) - 0.5) *
                            contrastLevel) + 0.5) * 255.0;


                red = ((((pixelBuffer[k + 2] / 255.0) - 0.5) *
                            contrastLevel) + 0.5) * 255.0;


                if (blue > 255)
                { blue = 255; }
                else if (blue < 0)
                { blue = 0; }


                if (green > 255)
                { green = 255; }
                else if (green < 0)
                { green = 0; }


                if (red > 255)
                { red = 255; }
                else if (red < 0)
                { red = 0; }


                pixelBuffer[k] = (byte)blue;
                pixelBuffer[k + 1] = (byte)green;
                pixelBuffer[k + 2] = (byte)red;
            }

            Image<Bgr, Byte> res = img.Clone();
            res.Bytes = pixelBuffer;
            return res;
        }


        #region NormalizeImage
        public static Bitmap NormalizeImage(Bitmap srcImage, double blackPointPercent = 0.02, double whitePointPercent = 0.01)
        {
            BitmapData srcData = srcImage.LockBits(new Rectangle(0, 0, srcImage.Width, srcImage.Height), ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);
            Bitmap destImage = new Bitmap(srcImage.Width, srcImage.Height);
            BitmapData destData = destImage.LockBits(new Rectangle(0, 0, destImage.Width, destImage.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            int stride = srcData.Stride;
            IntPtr srcScan0 = srcData.Scan0;
            IntPtr destScan0 = destData.Scan0;
            var freq = new int[256];

            unsafe
            {
                byte* src = (byte*)srcScan0;
                for (int y = 0; y < srcImage.Height; ++y)
                {
                    for (int x = 0; x < srcImage.Width; ++x)
                    {
                        ++freq[src[y * stride + x * 4]];
                    }
                }

                int numPixels = srcImage.Width * srcImage.Height;
                int minI = 0;
                var blackPixels = numPixels * blackPointPercent;
                int accum = 0;

                while (minI < 255)
                {
                    accum += freq[minI];
                    if (accum > blackPixels) break;
                    ++minI;
                }

                int maxI = 255;
                var whitePixels = numPixels * whitePointPercent;
                accum = 0;

                while (maxI > 0)
                {
                    accum += freq[maxI];
                    if (accum > whitePixels) break;
                    --maxI;
                }
                double spread = 255d / (maxI - minI);
                byte* dst = (byte*)destScan0;
                for (int y = 0; y < srcImage.Height; ++y)
                {
                    for (int x = 0; x < srcImage.Width; ++x)
                    {
                        int i = y * stride + x * 4;

                        byte val = (byte)Clamp(Math.Round((src[i] - minI) * spread), 0, 255);
                        dst[i] = val;
                        dst[i + 1] = val;
                        dst[i + 2] = val;
                        dst[i + 3] = 255;
                    }
                }
            }

            srcImage.UnlockBits(srcData);
            destImage.UnlockBits(destData);

            return destImage;
        }

        static double Clamp(double val, double min, double max)
        {
            return Math.Min(Math.Max(val, min), max);
        }
        #endregion


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            contrastImage(new Image<Bgr, byte>(400, 500), trackBar2.Value);
            brightnessImage(new Image<Bgr, byte>(400, 500), trackBar2.Value);
            NormalizeImage(new Bitmap(400, 500));
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label3.Text = "Сигма = " + trackBar3.Value.ToString();
            sigmaGaussian = trackBar3.Value;
        }

        private void checkRetinexSSR_CheckedChanged(object sender, EventArgs e)
        {
            if (checkRetinexHSV.Checked || checkRetinexColors.Checked) {
                checkRetinexHSV.Checked = false;
                checkRetinexColors.Checked = false;
            }
        }

        private void checkRetinexHSV_CheckedChanged(object sender, EventArgs e)
        {
            if (checkRetinexSSR.Checked || checkRetinexColors.Checked)
            {
                checkRetinexSSR.Checked = false;
                checkRetinexColors.Checked = false;
            }
        }

        private void checkRetinexColors_CheckedChanged(object sender, EventArgs e)
        {
            if (checkRetinexSSR.Checked || checkRetinexHSV.Checked)
            {
                checkRetinexSSR.Checked = false;
                checkRetinexHSV.Checked = false;
            }
        }

        private void trackBar10_Scroll(object sender, EventArgs e)
        {
            label10.Text = "Min порог = " + trackBar10.Value.ToString();
            MinthreasoldCanny = trackBar10.Value;
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            label9.Text = "Max порог = " + trackBar9.Value.ToString();
            MaxthreasoldCanny = trackBar9.Value;
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            label8.Text = "Min Порог = " + trackBar8.Value.ToString();
            MinthreasoldBinarisation = trackBar8.Value;
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            label7.Text = "Max Порог = " + trackBar7.Value.ToString();
            MaxthreasoldBinarisation = trackBar7.Value;
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            label6.Text = "Сигма = " + trackBar6.Value.ToString();
            smoothMedian = trackBar6.Value;
        }

        private void trackBar5_Scroll_1(object sender, EventArgs e)
        {
            label5.Text = "Сигма = " + trackBar5.Value.ToString();
            smoothGaussian = trackBar5.Value;
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            //label5.Text = "Порог = " + trackBar5.Value.ToString();
            //threasoldEqualize = trackBar5.Value;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Яркость = " + trackBar1.Value.ToString();
            brightness = trackBar1.Value;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label4.Text = "Гауссиан = " + trackBar4.Value.ToString();
            gaussianKernelSize = trackBar4.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Контраст = " + trackBar2.Value.ToString();
            contrast = trackBar2.Value;
        }
    }
}

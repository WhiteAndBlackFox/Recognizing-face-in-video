using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace MultiFaceRec
{
    public partial class FrmPrincipal : Form
    {
        //Declararation of all variables, vectors and haarcascades
        Image<Bgr, Byte> currentFrame, backup;
        Capture grabber;
        HaarCascade face;
        HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels= new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        string name, names = null;
        filtredCam fc;

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void опцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fc.Show();
        }

        private void нейроннаяСетьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BD bd = new BD();
            bd.Show();
        }

        public FrmPrincipal()
        {
            InitializeComponent();
            //Load haarcascades for face detection
            face = new HaarCascade(Application.StartupPath + "/haarcascade_frontalface_default.xml");
            //eye = new HaarCascade("haarcascade_eye.xml");
            try
            {
                //Load of previus trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels+1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }
            
            }
            catch(Exception e)
            {
                //MessageBox.Show(e.ToString());
                MessageBox.Show("Не найдена база с лицами!!", "Загрузка базы лиц", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            fc = new filtredCam();

            grabber = new Capture(0);
            grabber.QueryFrame();
            Application.Idle += new EventHandler(FrameGrabber);
            if (grabber != null)
                button1.Enabled = false;
        }


        private void button2_Click(object sender, System.EventArgs e)
        {
            try
            {
                //Trained face counter
                ContTrain = ContTrain + 1;

                //Get a gray frame from capture device
                gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                face,
                1.2,
                10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(20, 20));

                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }

                //resize face detected image for force to compare the same size with the 
                //test image with cubic interpolation type method
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                trainingImages.Add(TrainedFace);
                labels.Add(textBox1.Text);

                //Show face added in gray scale
                imageBox1.Image = TrainedFace;

                //Write the number of triained faces in a file text for further load
                File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

                //Write the labels of triained faces in a file text for further load
                for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                {
                    trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                    File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                }

                MessageBox.Show(textBox1.Text + " лицо найдено и добавлено", "Обучено!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Лицо небыло найдено!", "Не обучено", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        

        void FrameGrabber(object sender, EventArgs e)
        {
            try
            {
                label3.Text = "0";
                //label4.Text = "";
                NamePersons.Add("");


                //Get the current frame form capture device
                currentFrame = grabber.QueryFrame().Resize(imageBoxFrameGrabber.Width, imageBoxFrameGrabber.Height, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //currentFrame =  brightnessImage(currentFrame, fc.brightness);

                currentFrame += fc.brightness;
                currentFrame = currentFrame.Mul(fc.contrast / 4);

                //currentFrame.SmoothMedian(5);

                if (fc.checkqual.Checked)
                    currentFrame._EqualizeHist();

                if (fc.checkRetinexSSR.Checked || fc.checkRetinexHSV.Checked || fc.checkRetinexColors.Checked)
                {
                    if (fc.checkRetinexSSR.Checked)
                        currentFrame = SingleScaleRetinex(currentFrame, fc.gaussianKernelSize, fc.sigmaGaussian, (int)fc.numericUpDown1.Value, 1);
                    if (fc.checkRetinexHSV.Checked)
                        currentFrame = SingleScaleRetinex(currentFrame, fc.gaussianKernelSize, fc.sigmaGaussian, (int)fc.numericUpDown1.Value, 2);
                    if (fc.checkRetinexColors.Checked)
                        currentFrame = SingleScaleRetinex(currentFrame, fc.gaussianKernelSize, fc.sigmaGaussian, (int)fc.numericUpDown1.Value, 3);
                }

                if (fc.checkGaussian.Checked)
                    currentFrame._SmoothGaussian(5);

                if (fc.checkMedian.Checked)
                    currentFrame.SmoothMedian(5);

                if (fc.checkBinariz.Checked)
                {
                    gray = currentFrame.Convert<Gray, Byte>();
                    gray._ThresholdBinary(new Gray(fc.MinthreasoldBinarisation), new Gray(fc.MaxthreasoldBinarisation));
                    CvInvoke.cvCvtColor(gray, currentFrame, COLOR_CONVERSION.CV_GRAY2BGR);
                    //currentFrame._ThresholdBinaryInv(new Bgr(fc.MinthreasoldBinarisation, fc.MinthreasoldBinarisation, fc.MinthreasoldBinarisation), new Bgr(fc.MaxthreasoldBinarisation, fc.MaxthreasoldBinarisation, fc.MaxthreasoldBinarisation));
                }

                if (fc.checkCanny.Checked)
                {
                    gray = currentFrame.Convert<Gray, Byte>();
                    //gray.Canny(new Gray(80), new Gray(160));
                    CvInvoke.cvCvtColor(gray.Canny(new Gray(fc.MinthreasoldCanny), new Gray(fc.MaxthreasoldCanny)), currentFrame, COLOR_CONVERSION.CV_GRAY2BGR);
                }

                if (fc.checkSobel.Checked)
                {
                    gray = currentFrame.Convert<Gray, Byte>();
                    //gray.Canny(new Gray(80), new Gray(160));
                    CvInvoke.cvCvtColor(gray.Canny(new Gray(fc.MinthreasoldCanny), new Gray(fc.MaxthreasoldCanny)), currentFrame, COLOR_CONVERSION.CV_GRAY2BGR); //.Add(gray.Sobel(1, 0, 3)).AbsDiff(new Gray(0.0))
                }



                //Convert it to Grayscale
                gray = currentFrame.Convert<Gray, Byte>();

                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                      face,
                      1.2,
                      10,
                      Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                      new Size(20, 20));

                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    t = t + 1;
                    result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    //draw the face detected in the 0th (gray) channel with blue color
                    currentFrame.Draw(f.rect, new Bgr(Color.DarkGray), 2);


                    if (trainingImages.ToArray().Length != 0)
                    {
                        //TermCriteria for face recognition with numbers of trained images like maxIteration
                        MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                        //Eigen face recognizer
                        EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                           trainingImages.ToArray(),
                           labels.ToArray(),
                           3000,
                           ref termCrit);

                        name = recognizer.Recognize(result);

                        //Draw the label for each face detected and recognized
                        currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));

                    }

                    NamePersons[t - 1] = name;
                    NamePersons.Add("");


                    //Set the number of faces detected on the scene
                    label3.Text = facesDetected[0].Length.ToString();

                }
                t = 0;

                //Names concatenation of persons recognized
                for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
                {
                    names = names + NamePersons[nnn] + ", ";
                }
                //Show the faces procesed and recognized
                imageBoxFrameGrabber.Image = currentFrame;

                label4.Text = names;
                
                if (names == "") { names = "Noknow"; }

                //textLogs.Clear();
                if (names != "")
                {
                    //DateTime date1 = new DateTime();
                    string s = DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss");

                    textLogs.AppendText(s + " Имя:" + names + "\n");
                }
                names = "";
                //Clear the list(vector) of names
                NamePersons.Clear();
            } 
            catch (Exception ex){
                Console.WriteLine(ex.Message);
            }
        }

        #region Multi Scale Retinex

        public static Image<Bgr, byte> SingleScaleRetinex(Image<Bgr, byte> img, int gaussianKernelSize, double sigma = 20, int nscales = 3, int mode = 3)
        {
            var radius = gaussianKernelSize / 2;
            var kernelSize = 2 * radius + 1;

            var ycc = img.Convert<Ycc, byte>();
                        
            var sum = 0f;
            var gaussKernel = new float[kernelSize * kernelSize];
            for (int i = -radius, k = 0; i <= radius; i++, k++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    var val = (float)Math.Exp(-(i * i + j * j) / (sigma * sigma));
                    gaussKernel[k] = val;
                    sum += val;
                }
            }
            for (int i = 0; i < gaussKernel.Length; i++)
                gaussKernel[i] /= sum;

            
            var gray = new Image<Gray, byte>(ycc.Size);
            CvInvoke.cvSetImageCOI(ycc, 1);
            CvInvoke.cvCopy(ycc, gray, IntPtr.Zero);

            
            var width = img.Width;
            var height = img.Height;

            var bmp = gray.Bitmap;
            var bitmapData = bmp.LockBits(new Rectangle(Point.Empty, gray.Size), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);

            unsafe
            {
                for (var y = 0; y < height; y++)
                {
                    var row = (byte*)bitmapData.Scan0 + y * bitmapData.Stride;
                    for (var x = 0; x < width; x++)
                    {
                        var color = row + x;

                        float val = 0;

                        for (var ns = 0; ns < nscales; ns++)
                        {
                            for (int i = -radius, k = 0; i <= radius; i++, k++)
                            {
                                var ii = y + i;
                                if (ii < 0) ii = 0; if (ii >= height) ii = height - 1;

                                var row2 = (byte*)bitmapData.Scan0 + ii * bitmapData.Stride;
                                for (int j = -radius; j <= radius; j++)
                                {
                                    var jj = x + j;
                                    if (jj < 0) jj = 0; if (jj >= width) jj = width - 1;
                                    
                                    switch (mode)
                                    {
                                        case 1: { val += *(row2 + jj) * gaussKernel[k]; break; }
                                        case 2: {
                                                val += 2.0f + (float)Math.Pow(10, *(row2 + jj) * Math.Log(sigma - 2.0f)/gaussKernel[k] / Math.Log10(10));
                                                break; }
                                        case 3: {
                                                val += (float)sigma - (float)Math.Pow(10, *(row2 + jj) * Math.Log(sigma - 2.0f) / gaussKernel[k] / Math.Log10(10));
                                                break; }
                                    }
                                    
                                }
                            }
                        }

                        var newColor = 127.5 + 255 * Math.Log(*color / val);
                        if (newColor > 255)
                            newColor = 255;
                        else if (newColor < 0)
                            newColor = 0;
                        *color = (byte)newColor;
                    }
                }
            }
            bmp.UnlockBits(bitmapData);

            CvInvoke.cvCopy(gray, ycc, IntPtr.Zero);
            CvInvoke.cvSetImageCOI(ycc, 0);

            return ycc.Convert<Bgr, byte>();

        }

        #endregion
        
    }
}
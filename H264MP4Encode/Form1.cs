using NSH264Encoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H264MP4Encode
{
    public partial class Form1 : Form
    {
        public int testnumber = 0;
        public String uri = @"rtsp://127.0.0.1:8554/live.sdp";


        RunFFplay FFplay = new RunFFplay();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FFplay.main(uri);

            Thread thread1 = new Thread(ThreadWork.DoWork);
            thread1.Start();

            int width = 640;
            int height = 480;
            int fps = 30;
            H264Encoder enc = new H264Encoder();
            //enc.SetupEncode(@"E:\TEMP\encoded.mp4", width, height, fps);
            enc.SetupEncode(uri, width, height, fps);
            // "rtsp://127.0.0.1:8554/live.sdp";

            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Red);
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.FitBlackBox;
            float font_x = 480.0F;
            float font_y = 450.0F;
            string drawString;

            Bitmap image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            g.FillRectangle(Brushes.Black, 0, 0, width, height);
            Brush[] brushList = new Brush[] { Brushes.Green, Brushes.Red, Brushes.Yellow, Brushes.Pink, Brushes.LimeGreen };
            Random rnd = new Random();


            for (int j = 0; j < 100; j++)
            {
                for (int i = 0; i < 100; i++)
                {
                    int rndTmp = rnd.Next(1, 3);

                    g.FillRectangle(brushList[i % 5], (i % width) * 2, (i % height) * 0.5f, i % 30, i % 30);
                    g.FillRectangle(brushList[i % 5], (i % width) * 2, (i % height) * 2, i % 30, i % 30);
                    g.FillRectangle(brushList[i % 5], (i % width) * 0.5f, (i % height) * 2, i % 30, i % 30);

                    drawString = String.Format("i:{0},T:{1}", i, testnumber);
                    g.FillRectangle(Brushes.Black, font_x, font_y, width, height);
                    g.DrawString(drawString, drawFont, drawBrush, font_x, font_y, drawFormat);

                    g.Save();

                    Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
                    BitmapData bmpData = image.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                    // Get the address of the first line.
                    IntPtr ptr = bmpData.Scan0;

                    // Declare an array to hold the bytes of the bitmap.
                    int bytes = Math.Abs(bmpData.Stride) * image.Height;
                    byte[] rgbValues = new byte[bytes];

                    // Copy the RGB values into the array.
                    System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

                    enc.WriteFrame(rgbValues);
                    testnumber++;

                    System.Threading.Thread.Sleep(10);

                    // Unlock the bits.
                    image.UnlockBits(bmpData);
                }

                g.FillRectangle(Brushes.Black, 0, 0, width, height);
            }


            g.FillRectangle(Brushes.White, 0, 0, width, height);

            enc.CloseEncode();
            //FFplay.kill();
            //MessageBox.Show("Test encode done.");
        }

        private void btInc_Click(object sender, EventArgs e)
        {
            testnumber++;
        }

        private void btDec_Click(object sender, EventArgs e)
        {
            if (testnumber > 0)
            {
                testnumber--;
            }
        }

        internal class ThreadWork
        {
            public static void DoWork()
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("Working thread...");
                    Thread.Sleep(100);
                }
            }
        }

        internal class RunFFplay
        {
            Process process;

            public void kill()
            {
                process.Close();
            }

            public void main(String pUri)
            {
                string temp_arg = "-rtsp_flags listen -i " + pUri;
                try
                {
                    process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "ffplay.exe",
                            Arguments = temp_arg,
                            UseShellExecute = false,
                            RedirectStandardOutput = false,
                            CreateNoWindow = false
                        }
                    };

                    process.Start();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}

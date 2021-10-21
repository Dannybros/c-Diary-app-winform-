using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diary
{
    public static class addImageRTF
    {
        [Flags]
        enum EmfToWmfBitsFlags
        {
            EmfToWmfBitsFlagsDefault = 0x00000000,
            EmfToWmfBitsFlagsEmbedEmf = 0x00000001,
            EmfToWmfBitsFlagsIncludePlaceable = 0x00000002,
            EmfToWmfBitsFlagsNoXORClip = 0x00000004
        }

        const int MM_ISOTROPIC = 7;
        const int MM_ANISOTROPIC = 8;

        [DllImport("gdiplus.dll")]
        private static extern uint GdipEmfToWmfBits(IntPtr _hEmf, uint _bufferSize,
            byte[] _buffer, int _mappingMode, EmfToWmfBitsFlags _flags);
        [DllImport("gdi32.dll")]
        private static extern IntPtr SetMetaFileBitsEx(uint _bufferSize,
            byte[] _buffer);
        [DllImport("gdi32.dll")]
        private static extern IntPtr CopyMetaFile(IntPtr hWmf,
            string filename);
        [DllImport("gdi32.dll")]
        private static extern bool DeleteMetaFile(IntPtr hWmf);
        [DllImport("gdi32.dll")]
        private static extern bool DeleteEnhMetaFile(IntPtr hEmf);

        public static string ImageString(Bitmap image, int rtb)
        {
            Metafile metafile = null;
            float dpiX; float dpiY;

            using (Graphics g = Graphics.FromImage(image))
            {
                IntPtr hDC = g.GetHdc();
                metafile = new Metafile(hDC, EmfType.EmfOnly);
                g.ReleaseHdc(hDC);
            }

            using (Graphics g = Graphics.FromImage(metafile))
            {
                g.DrawImage(image, 0, 0);
                dpiX = g.DpiX;
                dpiY = g.DpiY;
            }

            IntPtr _hEmf = metafile.GetHenhmetafile();
            uint _bufferSize = GdipEmfToWmfBits(_hEmf, 0, null, MM_ANISOTROPIC,
            EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);
            byte[] _buffer = new byte[_bufferSize];
            GdipEmfToWmfBits(_hEmf, _bufferSize, _buffer, MM_ANISOTROPIC,
                                        EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);
            IntPtr hmf = SetMetaFileBitsEx(_bufferSize, _buffer);
            string tempfile = Path.GetTempFileName();
            CopyMetaFile(hmf, tempfile);
            DeleteMetaFile(hmf);
            DeleteEnhMetaFile(_hEmf);

            var stream = new MemoryStream();
            byte[] data = File.ReadAllBytes(tempfile);
            //File.Delete (tempfile);
            int count = data.Length;
            stream.Write(data, 0, count);

            float bmSizeWidth, bmSizeHeight;
            float ratio =(float) image.Width / (float) image.Height;

            if( image.Width >= rtb)
            {
                 bmSizeWidth = rtb - 60;
                 bmSizeHeight = bmSizeWidth /ratio;
               // MessageBox.Show(ratio.ToString() +"+" +bmSizeWidth.ToString()+ "+" + bmSizeHeight.ToString());
              
            }
            else
            {
                bmSizeWidth = image.Width;
                bmSizeHeight = image.Height;
            }

            string proto = @"{\rtf1{\pict\wmetafile8\picw" + (int)(((float)image.Width / dpiX) * 2540)
                              + @"\pich" + (int)(((float)image.Height / dpiY) * 2540)
                              + @"\picwgoal" + (int)(((float)bmSizeWidth / dpiX) * 1440) //image.Width
                              + @"\pichgoal" + (int)(((float)bmSizeHeight / dpiY) * 1440) //image.Height
                              + " "
                  + BitConverter.ToString(stream.ToArray()).Replace("-", "")
                              + "}}";
            return proto;
        }

        public static int addValue(int x, int y)
        {
            return x + y;
        }




        /// 
        /// 
        /// 
        ///     Another method for adding image to richtextbox forcibly
        /// 
        /// 
        [DllImport("user32.dll", EntryPoint = "OpenClipboard")]
        public static extern Boolean OpenClipboard(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "EmptyClipboard")]
        public static extern Boolean EmptyClipboard();

        [DllImport("user32.dll", EntryPoint = "SetClipboardData")]
        public static extern IntPtr SetClipboardData(int uFormat, IntPtr hwnd);

        [DllImport("user32.dll", EntryPoint = "CloseClipboard")]
        public static extern Boolean CloseClipboard();

        [DllImport("gdi32.dll", EntryPoint = "CopyEnhMetaFileA")]
        public static extern IntPtr CopyEnhMetaFile(IntPtr hemfSrc, IntPtr hNull);

        [DllImport("gdi32.dll", EntryPoint = "DeleteEnhMetaFile")]
        public static extern Boolean DeleteEnhMetaFiles(IntPtr hemfSrc); // DeleteEnhMetaFile(IntPtr hemfSrc);

        //
        private static bool PutEnhMetafileOnClipboard(IntPtr hWnd, Metafile mf)
        {
            bool bResult = new bool();
            bResult = false;
            IntPtr hEMF, hEMF2;
            hEMF = mf.GetHenhmetafile(); // invalidates mf
            if (!hEMF.Equals(new IntPtr(0)))
            {
                hEMF2 = CopyEnhMetaFile(hEMF, new IntPtr(0));

                if (!hEMF2.Equals(new IntPtr(0)))
                {
                    if (OpenClipboard(hWnd))
                    {
                        if (EmptyClipboard())
                        {
                            IntPtr hRes;
                            hRes = SetClipboardData(14, hEMF2);    // 14 == CF_ENHMETAFILE
                            bResult = hRes.Equals(hEMF2);
                            CloseClipboard();
                        }
                    }
                }
                // DeleteEnhMetaFile(hEMF);
                DeleteEnhMetaFiles(hEMF);
            }
            return bResult;
        }

        //Add images to RichtextBox without losing quality and ratio
        public static void AddImageToRtb(Image bm, RIchTextBox rtbMain, Control control)
        {
            rtbMain.AppendText(Environment.NewLine);
            rtbMain.AppendText(Environment.NewLine);
            // Create a bitmap of the image you want to draw to the metafile
            //Bitmap bm = new Bitmap(imgPathName);
            int bmWidth = bm.Width;
            int bmHeight = bm.Height;
            int newWidth;
            /// Testing...
            int ratio = bmWidth / bmHeight;

            if (bmWidth >= rtbMain.Width)
            {
                //newWidth = rIchTextBox1.Width-300;
                newWidth = rtbMain.Width - 50;
            }
            else
            {
                //newWidth = rIchTextBox1.Width/3;
                newWidth = bmWidth;
            }
            int newHeight = newWidth * ratio;

            float nPercentW = ((float)newWidth / (float)bmWidth);
            float nPercentH = ((float)newHeight / (float)bmHeight);
            float nPercent;

            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
            }
            else
            {
                nPercent = nPercentW;
            }

            int destWidth = (int)(bmWidth * nPercent);
            int destHeight = (int)(bmHeight * nPercent);


            // Create a graphics object of the Form and get its hdc handle
            Graphics me_grx = control.CreateGraphics();
            IntPtr me_hdc = me_grx.GetHdc();


            // Create a new metafile the same size as the image and create a graphics object for it
            Metafile emf = new Metafile("Tmp.emf", me_hdc, new Rectangle(0, 0, destWidth, destHeight), MetafileFrameUnit.Pixel);
            Graphics emf_gr = Graphics.FromImage(emf);

            // Draw the bitmap image onto the new metafile
            //emf_gr.DrawImage(bm, 0,0);
            emf_gr.DrawImage(bm, new Rectangle(0, 0, destWidth, destHeight), new Rectangle(0, 0, bmWidth, bmHeight), GraphicsUnit.Pixel);

            // Dispose the bitmap and the metafile graphics object
            emf_gr.Dispose();
            bm.Dispose();

            // Copy the new metafile to the clipboard
            PutEnhMetafileOnClipboard(control.Handle, emf);

            // Paste the new metafile in the RichTextBox
            rtbMain.Paste();

            // Dispose the rest of the objects we created
            me_grx.ReleaseHdc(me_hdc);
            me_grx.Dispose();
            emf.Dispose();
        }
    }
}

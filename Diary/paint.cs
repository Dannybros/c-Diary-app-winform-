using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Imaging;

namespace Diary
{
    public partial class paint : Form
    {
        wiritingDiary2 wd = (wiritingDiary2)Application.OpenForms["wiritingDiary2"];
       
        private Cursor testcursor = new Cursor(Application.StartupPath + @"\Pencil.cur");

        string path = Application.StartupPath + "\\paint.jpg";

        int index;
        int x, y, sX, sY, cX, cY;
        Bitmap bm;
        Point px, py;
        public Pen p = new Pen(Color.Black,5);
        public Pen erase = new Pen(Color.White, 32);
        public Graphics g;
        public bool painting = false;

        List<string> fonts = new List<string>();


        //Dlls for recreating colors of image to make it clear
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

        public static extern Boolean DeleteEnhMetaFile(IntPtr hemfSrc);
        
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
                DeleteEnhMetaFile(hEMF);
            }
            return bResult;
        }

        public paint()
        {
            InitializeComponent();

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            bm = new Bitmap(panelPaint.Width, panelPaint.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            panelPaint.Image = bm;
            p.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
            erase.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
        }

        // change panel to bitmap and save to diary
        private async void btnSave_Click(object sender, EventArgs e)
        {
            //Bitmap bitmap = DrawContronlToBitmap(panelPaint);
            Bitmap bitmap = bm.Clone(new Rectangle(0, 0, panelPaint.Width, panelPaint.Height), bm.PixelFormat);

            bitmap.Save(path, ImageFormat.Jpeg);
            

            Image pic = Image.FromFile(path);

            await wd.addPictures((Bitmap)pic);
            g.Clear(Color.White);
            panelPaint.Image = bm;
            index = 0;


            //panelPaint.Invalidate();
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            panelPaint.Image = bm;
            index = 0;
        }


        // Start new drawing functions

        private void panelPaint_MouseClick(object sender, MouseEventArgs e)
        {
           
            if (index == 7)
            {
                Point point = set_point(panelPaint, e.Location);
                Fill(bm, point.X, point.Y, btnColor.BackColor);
            }
        }
        
        private void panelPaint_MouseDown(object sender, MouseEventArgs e)
        {
            painting = true;
            py = e.Location;

            cX = e.X;
            cY = e.Y;
        }

        private void panelPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (painting)
            {
                if (index == 1)
                {
                    px = e.Location;
                    g.DrawLine(p, px, py);
                    py = px;
                }
                if (index == 2)
                {
                    px = e.Location;
                    g.DrawLine(erase, px, py);
                    py = px;
                }

            }
            panelPaint.Refresh();

            x = e.X;
            y = e.Y;
            sX = e.X - cX;
            sY = e.Y - cY;
        }

        private void panelPaint_MouseUp(object sender, MouseEventArgs e)
        {
            painting = false;

            sX = x - cX;
            sY = y - cY;
            
            if (index == 3)
            {
                g.DrawEllipse(p, cX, cY, sX, sY);
            }
            if (index == 4)
            {
                g.DrawRectangle(p, cX, cY, sX, sY);
            }
            if (index == 5)
            {
                g.DrawLine(p, cX, cY, x, y);
            }
        }

        private void panelPaint_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (painting)
            {
                if (index == 3)
                {
                    g.DrawEllipse(p, cX, cY, sX, sY);
                }
                if (index == 4)
                {
                    g.DrawRectangle(p, cX, cY, sX, sY);
                }
                if (index == 5)
                {
                    g.DrawLine(p, cX, cY, x, y);
                }
            }
        }

        //Allocate index numbers 
        private void btnPen_Click(object sender, EventArgs e)
        {
            index = 1;
            btnPen.BackColor = Color.FromArgb(44, 198, 108);
            btnEraser.BackColor = Color.Transparent;
            btnFil.BackColor = Color.Transparent;
            btnCircle.BackColor = Color.Transparent;
            btnRectangle.BackColor = Color.Transparent;
            btnLine.BackColor = Color.Transparent;
        }

        private void btnEraser_Click(object sender, EventArgs e)
        {
            index = 2;
            btnPen.BackColor = Color.Transparent;
            btnEraser.BackColor = Color.FromArgb(44, 198, 108);
            btnFil.BackColor = Color.Transparent;
            btnCircle.BackColor = Color.Transparent;
            btnRectangle.BackColor = Color.Transparent;
            btnLine.BackColor = Color.Transparent;
        }
        
        private void btnCircle_Click(object sender, EventArgs e)
        {
            index = 3;
            btnPen.BackColor = Color.Transparent;
            btnEraser.BackColor = Color.Transparent;
            btnFil.BackColor = Color.Transparent;
            btnCircle.BackColor = Color.FromArgb(44, 198, 108);
            btnRectangle.BackColor = Color.Transparent;
            btnLine.BackColor = Color.Transparent;
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            index = 4;
            btnPen.BackColor = Color.Transparent;
            btnEraser.BackColor = Color.Transparent;
            btnFil.BackColor = Color.Transparent;
            btnCircle.BackColor = Color.Transparent;
            btnRectangle.BackColor = Color.FromArgb(44, 198, 108);
            btnLine.BackColor = Color.Transparent;
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            index = 5;
            btnPen.BackColor = Color.Transparent;
            btnEraser.BackColor = Color.Transparent;
            btnFil.BackColor = Color.Transparent;
            btnCircle.BackColor = Color.Transparent;
            btnRectangle.BackColor = Color.Transparent;
            btnLine.BackColor = Color.FromArgb(44, 198, 108);
        }

        private void btnFil_Click(object sender, EventArgs e)
        {
            index = 7;
            btnPen.BackColor = Color.Transparent;
            btnEraser.BackColor = Color.Transparent;
            btnFil.BackColor = Color.FromArgb(44, 198, 108);
            btnCircle.BackColor = Color.Transparent;
            btnRectangle.BackColor = Color.Transparent;
            btnLine.BackColor = Color.Transparent;
        }

        private void panelPaint_MouseEnter(object sender, EventArgs e)
        {
            if(index == 2)
            {
                this.Cursor = new Cursor(Application.StartupPath + "\\eraser.cur");
            }
            else if(index ==7)
            {
                this.Cursor = new Cursor(Application.StartupPath + "\\toxicbucket.cur");
            }
            else if (index ==1)
            {
                this.Cursor = testcursor;
            }
            else if(index==3 && index ==4 && index == 5)
            {
                this.Cursor = Cursors.Cross;
            }
            else
            {
                this.Cursor = this.DefaultCursor;
            }
        }

        private void panelPaint_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = this.DefaultCursor;
        }

        private void color_picker_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = set_point(color_picker, e.Location);
            btnColor.BackColor = ((Bitmap)color_picker.Image).GetPixel(point.X, point.Y);
            p.Color = btnColor.BackColor;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                cd.ShowHelp = true;
                cd.FullOpen = true;
                cd.SolidColorOnly = false;
                p.Color = cd.Color;
                btnColor.BackColor = cd.Color;
            }
        }

        private static Bitmap DrawContronlToBitmap(Control control)
        {
            Bitmap bitmap = new Bitmap(control.Width - 5, control.Height - 5);
            Graphics gh = Graphics.FromImage(bitmap);
            Rectangle rec = control.RectangleToScreen(control.ClientRectangle);
            gh.CopyFromScreen(rec.Location, Point.Empty, control.Size);
            return bitmap;
        }

        static Point set_point(PictureBox pb, Point pt)
        {
            float pX = 1f * pb.Image.Width / pb.Width;
            float py = 1f * pb.Image.Height / pb.Height;

            return new Point((int)(pt.X * pX), (int)(pt.Y * py));
        }
        
        private void validate(Bitmap bmp, Stack<Point> sp, int x, int y, Color old_color, Color new_color)
        {
            Color cx = bmp.GetPixel(x, y);
            if (cx == old_color)
            {
                sp.Push(new Point(x, y));
                bmp.SetPixel(x, y, new_color);
            }
        }

        public void Fill(Bitmap bmp, int x, int y, Color new_clr)
        {
            Color old_color = bmp.GetPixel(x, y);
            Stack<Point> pixel = new Stack<Point>();
            pixel.Push(new Point(x, y));
            bmp.SetPixel(x, y, new_clr);
            if (old_color == new_clr) return;

            while (pixel.Count > 0)
            {
                Point pt = (Point)pixel.Pop();
                if(pt.X>0 && pt.Y>0 && pt.X<bmp.Width-1 && pt.Y < bmp.Height - 1)
                {
                    validate(bmp, pixel, pt.X-1, pt.Y, old_color, new_clr);
                    validate(bmp, pixel, pt.X, pt.Y-1, old_color, new_clr);
                    validate(bmp, pixel, pt.X + 1, pt.Y, old_color, new_clr);
                    validate(bmp, pixel, pt.X, pt.Y+1, old_color, new_clr);
                }
            }

        }
    }
}

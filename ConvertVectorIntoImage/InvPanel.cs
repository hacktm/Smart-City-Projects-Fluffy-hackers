using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ConvertVectorIntoImage
{
    public partial class InvPanel : Form
    {
        Bitmap _drawing;
        private List<Point> _listOfPoints;
        public List<Point> ListOfPoints
        {
            set
            {
                _listOfPoints = value;
                DrawPoints(value);
                Invalidate();
                SaveImage();
            }
        }

        public InvPanel()
        {
            InitializeComponent();
            InitUiLayout();
        }

        private void InitUiLayout()
        {
            WindowState = FormWindowState.Maximized;
            Visible = false;
            _drawing = new Bitmap(panelToDraw.Width, panelToDraw.Height, panelToDraw.CreateGraphics());
            Graphics.FromImage(_drawing).Clear(Color.White);
            panelToDraw.Paint += PanelPaint;
        }
        private void DrawPoints(List<Point> pointToDraw)
        {
            Graphics panel = Graphics.FromImage(_drawing);
            for (int i = 0; i < pointToDraw.Count - 1; i++)
            {

                _drawing.SetPixel(pointToDraw[i].X/3, pointToDraw[i].Y/3, Color.Black);
                
                //var pen = new Pen(Color.Black, 14) { EndCap = LineCap.Round, StartCap = LineCap.Round };
                //panel.DrawLine(pen, pointToDraw[i].X/3, pointToDraw[i].Y/3, pointToDraw[i + 1].X/3,
                //    pointToDraw[i + 1].Y/3 );
            }
            panelToDraw.CreateGraphics().DrawImage(_drawing, new Point(0, 0));
        }
        private void SaveImage()
        {
            using (var bitmap = new Bitmap(panelToDraw.ClientSize.Width,
                                  panelToDraw.ClientSize.Height))
            {
                panelToDraw.DrawToBitmap(bitmap, panelToDraw.ClientRectangle);
                bitmap.Save("E:\\test.bmp", ImageFormat.Bmp);
            }
        }
        private void PanelPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(_drawing, new Point(0, 0));
        }

        private void InvPanelLoad(object sender, System.EventArgs e)
        {
            //_drawing = new Bitmap(panelToDraw.Width, panelToDraw.Height, panelToDraw.CreateGraphics());
            //  Graphics.FromImage(_drawing).Clear(Color.White);
        }

    }
}

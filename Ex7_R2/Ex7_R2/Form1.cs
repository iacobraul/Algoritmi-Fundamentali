using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Ex7_R2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            PointF center = new PointF(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
            int radius = 120;
            Draw(g, center, radius);

        }
        public void Draw(Graphics g, PointF center, int radius) 
        {
            PointF[] points = new PointF[6];
            points[0] = new PointF(center.X, center.Y - radius);
            points[3] = new PointF(center.X, center.Y + radius);
            points[1] = new PointF(center.X + (int)Math.Sqrt(Math.Pow(radius,2)-Math.Pow(radius/2,2)), center.Y - radius/2);
            points[2] = new PointF(center.X + (int)Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(radius / 2, 2)), center.Y + radius / 2);
            points[4] = new PointF(center.X - (int)Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(radius / 2, 2)), center.Y + radius / 2);
            points[5] = new PointF(center.X - (int)Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(radius / 2, 2)), center.Y - radius / 2);

            if(radius < 10)
            {
                Pen p = new Pen(Color.Black, 3);
                g.DrawPolygon(p, points);
            }
            else
            {
                foreach (PointF point in points)
                {
                    Draw(g, point, radius / 3);
                }
            }
        }
        public float Dist(PointF A, PointF B)
        {
            return (float)Math.Sqrt( Math.Pow(A.X+B.X,2) - Math.Pow(A.Y+B.Y,2) );
        }
    }
}

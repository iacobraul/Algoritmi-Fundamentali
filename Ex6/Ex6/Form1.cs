using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace Ex6
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
            g.SmoothingMode = SmoothingMode.AntiAlias;
            TextReader load = new StreamReader(@"../../data.in");
            int n = int.Parse(load.ReadLine());
            PointF[] points = new PointF[n];

            int i = 0;
            string buffer;
            while ((buffer = load.ReadLine()) != null)
            {
                string[] parts = buffer.Split(' ');
                float x = float.Parse(parts[0]);
                float y = float.Parse(parts[1]);
                points[i] = new PointF(x, y);
                i++;
            }
            Draw(g, points, 10);
            load.Close();

        }
        public static void Draw(Graphics g, PointF[] points, int offset)
        {
            if (Dist(points[0], points[points.Length - 1]) > 5)
            {
                g.DrawPolygon(Pens.Black, points);

                PointF[] newPoints = new PointF[points.Length];
                for (int i = 0; i < points.Length - 1; i++)
                {
                    newPoints[i] = new PointF((points[i].X + offset * points[i + 1].X) / (1 + offset), (points[i].Y + offset * points[i + 1].Y) / (1 + offset));
                }
                newPoints[points.Length - 1] = new PointF((points[points.Length - 1].X + offset * points[0].X) / (1 + offset), (points[points.Length - 1].Y + offset * points[0].Y) / (1 + offset));
                Draw(g, newPoints, offset);
            }
            else return;
        }
        public static double Dist(PointF a, PointF b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }
    }
}

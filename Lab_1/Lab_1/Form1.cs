using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class Form1 : Form
    {
        public static Random rnd = new Random();
        Graphics grp;
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
        }

        void Drept(Color draw, int x, int y, int dx, int dy)
        {
            grp.DrawLine(new Pen(draw), x, y, x + dx, y);
            grp.DrawLine(new Pen(draw), x + dx, y, x + dx, y + dy);
            grp.DrawLine(new Pen(draw), x + dx, y + dy, x, y + dy);
            grp.DrawLine(new Pen(draw), x, y + dy, x, y);
        }

        void Triunghi(Color draw, int x, int y, int dx, int height)
        {
            grp.DrawLine(new Pen(draw), x, y, x + dx / 2, y - height);
            grp.DrawLine(new Pen(draw), x + dx / 2, y - height, x + dx, y);
            grp.DrawLine(new Pen(draw), x, y, x + dx, y);
        }
        void Usa(int x, int y, int dx, int dy)
        {
            Drept(Color.Brown, 400, 300, 100, 200);
            grp.DrawEllipse(new Pen(Color.Brown), 425, 310, 50, 50);
            grp.DrawLine(new Pen(Color.Brown), 450, 310, 450, 360);
            grp.DrawLine(new Pen(Color.Brown), 425, 335, 475, 335);
            grp.DrawEllipse(new Pen(Color.Gold), 460, 400, 25, 25);
        }

        void Gard(Color draw, Color fill, int x, int y, int dx, int dy, int number)
        {
            for (int i = 0; i < number; i++)
            {
                DreptFilled(draw, fill, x+ i*dx, y, dx, dy);
                Triunghi(draw, x+ i*dx, y, dx, dy);
            }
        }

        void DreptFilled( Color draw, Color fill, int x, int y, int dx, int dy)
        {
            PointF[] T = new PointF[4];
            T[0] = new PointF(x, y);
            T[1] = new PointF(x + dx, y);
            T[2] = new PointF(x + dx, y + dy);
            T[3] = new PointF(x, y + dy);

            grp.FillPolygon(new SolidBrush(fill), T);
            grp.DrawPolygon(new Pen(draw), T);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            Drept(Color.Black,200, 200, 400, 300);
            Drept(Color.Black, 250, 250, 50, 100);
            Drept(Color.Black, 300, 250, 50, 100);

            for (int i = 0; i < 100; i++)
            {
                Drept(Color.Gray, 200 + rnd.Next(350), 400 + rnd.Next(50), rnd.Next(20, 50), rnd.Next(20, 50));
            }
            
            Drept(Color.Blue, 550, 250, 50, 200);
            Triunghi(Color.Red, 200, 200, 400, 100);
            grp.DrawEllipse(new Pen(Color.Purple), 362, 115, 75, 75);

            Usa(400, 300, 100, 200);
            DreptFilled(Color.AliceBlue, Color.Purple, 300, 350, 50, 50);
            Gard(Color.Brown,Color.Brown, 600, 400, 50, 100, 5);

            pictureBox1.Image = bmp;
        }
    }
}

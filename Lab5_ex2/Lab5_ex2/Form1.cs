using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_ex2
{
    
    public partial class Form1 : Form
    {   
        Graphics grp;
        Bitmap bmp;
        T demo;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            demo = new T(1000, pictureBox1.Width, pictureBox1.Height);
            demo.Draw(grp);
            demo.Greddy(grp);
            pictureBox1.Image = bmp;
        }
    }

    public class MyPointF
    {
        public float X, Y;
        public bool selected;
        public MyPointF(float x, float y, bool selected)
        {
            X = x;
            Y = y;
            this.selected = selected;
        }

        public void Draw(Graphics handler)
        {
            handler.DrawEllipse(Pens.Black, X - 2, Y - 2, 4, 4);
        }
        public float Distanta(MyPointF d)
        {
            return (float)Math.Sqrt((this.X - d.X) * (this.X - d.X) + (this.Y - d.Y) * (this.Y - d.Y));
        }
    }

    public class T 
    {
        public static Random random = new Random();
        public MyPointF[] points;
        public T(int n, int resx, int resy) 
        {
            points = new MyPointF[n];
            for(int i = 0; i < n; i++)
            {
                points[i] = new MyPointF(random.Next(resx), random.Next(resy), false);
            }
        }
        public void Draw(Graphics handler)
        {
            for(int i = 0; i < points.Length; i++)
            {
                points[i].Draw(handler);
            }
        }
        public void Greddy(Graphics handler)
        {
            int indexstart = 0;

            for (int j = 0; j < points.Length - 1; j++)
            {
                points[indexstart].selected = true;
                float max = 10000;
                int index = 0;
                for (int i = 1; i < points.Length; i++)
                {
                    if (points[i].selected == false)
                    {
                        if (points[indexstart].Distanta(points[i]) < max)
                        {
                            max = points[indexstart].Distanta(points[i]);
                            index = i;
                        }
                    }
                }
                handler.DrawLine(Pens.Red, points[indexstart].X, points[indexstart].Y, points[index].X, points[index].Y);
                points[index].selected = true;
                indexstart = index;
            }
        }
    }
   
}

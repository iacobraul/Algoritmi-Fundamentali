using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GO
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Bitmap bitmap;
        Map demo;
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap (pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage (bitmap);
            demo = new Map(@"../../demo.txt");
            demo.DFS();
            demo.Draw(graphics);
            
            label1.Text = demo.t1.ToString() + " " + demo.t2.ToString();
            pictureBox1.Image = bitmap;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Upscaling
namespace Lab6_ex3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap sursa;
        Bitmap destinatie;

        Color Combine(Color A, Color B)
        {
            int r = (A.R + B.R) / 2;
            int g = (A.G + B.G) / 2;
            int b = (A.B + B.B) / 2;
            return Color.FromArgb(r, g, b);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sursa = new Bitmap(Image.FromFile(@"../../Resources/Profile_-_Stitch.png"));
            destinatie = new Bitmap(sursa.Width * 2 - 1, sursa.Height * 2 -1);

            for(int i = 0; i < sursa.Width; i++)
            {
                for(int j = 0; j < sursa.Height; j++)
                {
                    Color tmp = sursa.GetPixel(i, j);
                    destinatie.SetPixel(i * 2, j * 2, tmp);
                }
            }

            for(int i = 0; i < destinatie.Width; i+=2)
            {
                for(int j = 1; j < destinatie.Height; j+=2)
                {
                    Color A = destinatie.GetPixel(i, j - 1);
                    Color B = destinatie.GetPixel(i, j + 1);
                    Color C = Combine(A, B);
                    destinatie.SetPixel(i, j, C);
                }
            }

            for(int i = 1; i < destinatie.Width; i+=2)
            {
                for (int j = 0; j < destinatie.Height; j++)
                {
                    Color A = destinatie.GetPixel(i - 1, j);
                    Color B = destinatie.GetPixel(i + 1, j);
                    Color C = Combine(A, B);
                    destinatie.SetPixel(i, j, C);
                }
            }

            pictureBox1.Image = sursa;
            pictureBox2.Image = destinatie;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curs2
{
    public partial class Form1 : Form
    {
        public static Random rnd = new Random();
        public int cr = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 2200; i++)
            {
                cr--;

                Card a = new Card();
                Card b = new Card();
                Card c = new Card();
                Card d = new Card();
                Card x = new Card();

                int id = 0;
                if (a.value == b.value) id++;
                if (a.value == c.value) id++; 
                if (a.value == d.value) id++;
                if (a.value == x.value) id++;

                if (b.value == c.value) id++;
                if (b.value == d.value) id++;
                if (b.value == x.value) id++;

                if (c.value == d.value) id++;
                if (c.value == x.value) id++;

                if (d.value == x.value) id++;

                switch (id)
                {
                    case 0: label1.Text = "nimic"; break;
                    case 1: label1.Text = "1 pereche"; cr++; break;
                    case 2: label1.Text = "2 si 2"; cr++; break;
                    case 3: label1.Text = "3"; cr++; break;
                    case 4: label1.Text = "3 si 2"; cr += 5; break;
                    case 6: label1.Text = "4"; cr += 10; break;
                    case 10: label1.Text = "5"; cr += 100; break;
                }

                label1.Text = a.Filename();
                label2.Text = a + " " + b + " " + c + " " + d + " " + x;
                label3.Text = cr.ToString();
            }
        }
    }

    public class Card
    {
        public string Filename()
        {
            return color.ToString("00") + value.ToString("00") + "png";
        }
        public int value;
        public int color;
        public static Random rnd = new Random();
        public Card()
        {
            value = rnd.Next(2, 15);
            color = rnd.Next(0, 4);
        }
    }
}

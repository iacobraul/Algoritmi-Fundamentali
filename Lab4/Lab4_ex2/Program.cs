using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
// sa se afiseze lungimea celui mai lung sir de numere prime consecutive dintr-un fisier text, numerele fiind separate prin spatii
namespace Lab4_ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextReader load = new StreamReader(@"..\..\data.in");
            TextWriter save = new StreamWriter(@"..\..\data.out");
            int max = 0, nr = 0;
            string buffer;
            while ((buffer = load.ReadLine()) != null)
            {
                string[] local = buffer.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in local)
                {
                    int x = int.Parse(s);
                    if (Prim(x)) nr++;
                    else
                    {
                        if (nr > max) { max = nr; nr = 0; }
                    }
                }
            }
            save.Write(nr);
            save.Close();
        }

        public static bool Prim(int x)
        {
            if (x < 2) return false;
            if (x == 2) return true;
            if (x % 2 == 0) return false;
            for (int i = 3; i * i <= x; i+=2)
                if (x % i == 0) return false;
            return true;
        }
    }
}

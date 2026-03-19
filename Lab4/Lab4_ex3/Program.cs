using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// sa se afiseze lungimea celui mai lung sir de numere consecutive cu paritatea egala dintr-un fisier text
namespace Lab4_ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextReader load = new StreamReader(@"..\..\data.in");
            TextWriter save = new StreamWriter(@"..\..\data.out");
            int a = -1, b, nr = 1, max = 1;
            string buffer;
            while ((buffer = load.ReadLine()) != null)
            {
                string[] local = buffer.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in local)
                {
                    if(a == -1) { a = int.Parse(s); continue; }
                    b = int.Parse(s);

                    if (a % 2 == b % 2) nr++;
                    else
                    {
                      if (nr > max) max = nr;  
                      nr = 1;
                    }
                    a = b;
                } 
            }
            if(nr > max) max = nr;
            save.Write(max);
            save.Close();
        }
    }
}

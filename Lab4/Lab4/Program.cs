using System;
using System.IO;

namespace Lab4
{
    internal class Program
    {   // aifseaza cele mai mari 3 numere dintr-un sir de numere intregi, citite dintr-un fisier text,
        // si le scrie intr-un alt fisier text.
        static void Main(string[] args)
        {
            TextReader load = new StreamReader(@"..\..\data.in");
            TextWriter save = new StreamWriter(@"..\..\data.out");
            string buffer;
            while ((buffer = load.ReadLine()) != null)
            {
                string[] local = buffer.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            }
            int a = int.Parse(load.ReadLine());
            int b = int.Parse(load.ReadLine());
            int c = int.Parse(load.ReadLine());
            if (a > b)
            {
                int t = a; a = b; b = t;
            }
            if (b > c)
            {
                int t = b; b = c; c = t;
            }
            if (a > b)
            {
                int t = a; a = b; b = t;
            }
            string line;
            while ((line = load.ReadLine()) != null)
            {
                int x = int.Parse(line);
                if (x >= c)
                {
                    a = b; b = c; c = x;
                }
                else if (x >= b)
                {
                    a = b; b = x;
                }
                else if (x >= a)
                {
                    a = x;
                }
            }
            
            save.Write(a + " " + b + " " + c);
            save.Close();
        }
    }
}

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
            int a = -1, b = -1, c = -1;
            string buffer;
            while ((buffer = load.ReadLine()) != null)
            {
                string[] local = buffer.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in local)
                {
                    int x = int.Parse(s);
                    if(a == -1)
                    {
                        a = x; continue;
                    }
                    if (b == -1)
                    {
                        b = x; continue;
                    }
                    if (c == -1)
                    {
                        c = x; continue;
                    }

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
            }
        save.Write(a + " " + b + " " + c);
        save.Close();
        }
        
    }
}

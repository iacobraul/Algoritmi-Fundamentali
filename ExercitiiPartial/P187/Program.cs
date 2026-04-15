using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//P187 Să se scrie un program care citeşte cel mult 1.000.000 de numere naturale din intervalul închis [0,9] şi determină cel mai mare număr prim citit şi numărul său de apariții.
namespace P187
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextReader load = new StreamReader(@"../../data.in");
            StreamWriter save = new StreamWriter(@"../../data.out");
            string buffer;
            int[] v = new int[10];
            int max = 0, count = 0;
            while ((buffer = load.ReadLine()) != null)
            {
                string[] local = buffer.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach(string s in local)
                {
                    v[int.Parse(s)]++;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                if (v[i] > 0 && IsPrime(i))
                {
                    if (i >= max)
                    {
                        max = i;
                        count = v[i];
                    }
                }
            }

            save.Write($"{max} {count}");

            
            
            bool IsPrime(int n)
            {
                if (n < 2) return false;
                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0) return false;
                }
                return true;
            }
            
            load.Close();
            save.Close();
        } 
    }
}

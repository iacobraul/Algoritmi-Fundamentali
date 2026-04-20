using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1952
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = (int)Math.Pow(2, n) - 1;
            int[,] v = new int[m, m];

            Generare(v, 0, 0 ,m, n);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(v[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void Generare(int[,] v, int l, int c, int m, int n)
        {
            if (n <= 0 || m <= 0) return;

            int mijloc = m / 2;
            int lmijloc = l + mijloc;
            int cmijloc = c + mijloc;

            v[lmijloc, cmijloc] = n;
            
            Generare(v, l, c, mijloc, n - 1);
            Generare(v, l, cmijloc + 1, mijloc, n - 1);
            Generare(v, lmijloc + 1, c, mijloc, n - 1);
            Generare(v, lmijloc + 1, cmijloc + 1, mijloc, n - 1);
        }
    }
}

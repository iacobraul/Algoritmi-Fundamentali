using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace P845
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = (int)Math.Pow(2, n);
            int k = m;
            int[,] v = new int[m, m];
            Generare(v, 0, 0, m);

            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    Console.Write(v[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void Generare(int[,] v, int l, int c, int m)
        {
            if (m <= 1) return;

            for (int i = l; i < l + m / 2; i++)
            {
                for (int j = c; j < c + m / 2; j++)
                {
                    v[i, j] = 1;
                }
            }
            Generare(v, l, c + m / 2, m / 2);
            Generare(v, l + m / 2, c, m / 2);
            Generare(v, l + m / 2, c + m / 2, m / 2);
        }
    }
}

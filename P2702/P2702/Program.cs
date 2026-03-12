using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2702
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n];
            int[] sosete = new int[101];

            string[] s = Console.ReadLine().Split(' ');

            for (int i = 0; i < n; i++)
            {
                v[i] = int.Parse(s[i]);
                sosete[v[i]]++;
            }

            int perechi = 0;
            for(int i = 1; i <= 100; i++)
            {
                perechi += sosete[i] / 2;
            }

            Console.WriteLine(perechi);
        }
    }
}

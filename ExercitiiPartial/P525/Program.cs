using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//Se dau n numere naturale. Determinaţi cele mai mari două numere cu trei cifre care nu apar printre numerele date.
namespace P525
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[1000];
            int count = 2, a = 0, b = 0;
            string[] input = Console.ReadLine().Split(' ');
            for(int i = 0; i < n; i++)
            {
                int x = int.Parse(input[i]);
                if (x >= 100 && x <= 999)
                    v[x]++;
            }

            for(int i = 999; i >= 100; i--)
            {
                if (v[i] == 0 && count != 0 )
                {
                    if(a == 0)
                    {
                        a = i;
                    }
                    else
                    {
                        b = i;
                    }
                    count--;
                    if (count == 0) break;
                }
            }
            Console.WriteLine(b + " " + a);
        }
    }
}

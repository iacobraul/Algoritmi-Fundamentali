using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] s = new int[n];
            bool[] b = new bool[n];
            PD(0, n, s, b);
        }
        static void PD(int k, int n, int[] s, bool[] b)
        {
            if (k >= n)
            {
                bool ok = true;
                for (int i = 0; i < n - 1; i++)
                {
                    for(int j = i + 1; j < n; j++)
                    {
                        if (Math.Abs(i - j) == Math.Abs(s[i] - s[j]))
                        {
                            ok = false;
                        }
                    }
                }
                if (ok) 
                {
                    for(int i = 0; i < n; i++) Console.Write(i + " ");
                    Console.WriteLine();

                    for(int i = 0; i < n ; i++)
                        Console.Write(s[i]+ " ");
                    Console.WriteLine();

                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i < n; i++) 
                {
                    if (!b[i])
                    {
                        b[i] = true;
                        s[k] = i;
                        PD(k + 1, n, s, b);
                        b[i] = false;
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P525
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            n = int.Parse(Console.ReadLine());
            
            bool[] v = new bool[1000];
            string[] s = Console.ReadLine().Split(' ');

            for(int i = 0; i < n; i++)
            {
                int t = int.Parse(s[i]);
                if(t >= 100 && t < 1000) v[t] = true;
            }

            int a = -1, b = -1;
            for(int i = 999; i >= 100; i--)
            {
                if (!v[i])
                {
                    if(a == -1)
                    {
                        a = i;
                    }
                    else if(b == -1)
                    {
                        b = i;
                        break;
                    }
                }
            }

            int temp = a;
            a = b; b = temp;
            if (b == -1) Console.WriteLine("NU EXISTA");
            else Console.WriteLine(a + " " + b);
        }
    }
}

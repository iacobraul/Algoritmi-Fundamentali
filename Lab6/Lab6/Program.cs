using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Hosting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//picaturi
namespace Lab6
{
    internal class Program
    {
        static int[] v = {2, 5, 3, 0, 4, 0, 1, 2, 7};
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int apa = 0;
            for (int j = 0; j < 10000; j++)
            {
                int x = rnd.Next(v.Length);
                bool fl = false, fr = false;

                for (int i = x - 1; i >= 0; i--)
                {
                    if (v[i] > v[x])
                    {
                        fl = true;
                        break;
                    }
                }
                for (int i = x + 1; i < v.Length; i++)
                {
                    if (v[i] > v[x])
                    {
                        fr = true;
                        break;
                    }
                }

                if (fl && fr)
                {
                    v[x]++;
                    apa++;
                }
            }
            Console.WriteLine(apa);
            Console.ReadKey();
        }
    }
}

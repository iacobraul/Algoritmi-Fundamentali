using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P3738
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextReader load = new StreamReader(@"../../nyk.in");
            TextWriter save = new StreamWriter(@"../../nyk.out");
            //string buffer;
            int n = int.Parse(load.ReadLine());
            int maxCmmdc = 0, hCladire = 0, pCladire = 0, strada = 0;
            for(int i = 0; i < n; i++)
            {
                string[] line = load.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                int m = int.Parse(line[0]);
                int hmax = 0, pmax = 0;
                int[] v = new int[m+1];
                for(int j = 1; j <= m; j++)
                {
                    v[j] = int.Parse(line[j]);
                }
                int x = 0;
                for(int j = 1; j <= m; j++)
                {
                    x = cmmdc(x, v[j]);
                    if(nrPrim(v[j]) && v[j] >= hmax)
                    {
                        hmax = v[j];
                        pmax = j;
                    }
                }
                if(x >= maxCmmdc)
                {
                    maxCmmdc = x;
                    hCladire = hmax;
                    pCladire = pmax;
                    strada = i + 1;
                }
            }

            save.WriteLine($"{strada} {pCladire}");
            save.Write($"{hCladire}");

            load.Close();
            save.Close();

            int cmmdc(int a, int b)
            {
                while (b != 0) 
                {
                   int r = a % b;
                   a = b;
                   b = r;
                }
                return a;
            }
            bool nrPrim(int a)
            {
                if (a < 2) return false;
                for (int i = 2; i <= Math.Sqrt(a); i++)
                {
                    if (a % i == 0) return false;
                }
                return true;
            }
        }
    }
}

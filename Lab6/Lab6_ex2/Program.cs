using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Patrat magic
namespace Lab6_ex2
{
    internal class Program
    {
        static Random rnd = new Random();
        
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] a = new int[n, n];
            int k = 1;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    a[i, j] = k++;
                }
            }
            do
            {
                int l1 = rnd.Next(n), l2 = rnd.Next(n), c1 = rnd.Next(n), c2 = rnd.Next(n);
                (a[l1, c1], a[l2, c2]) = (a[l2, c2], a[l1, c1]);
            } while (!valid());

            for (int i = 0; i < n; i++) 
            {
                for(int j = 0; j < n; j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }

            bool valid()
            {
                int s = 0; int s1 = 0;
                for (int i = 0; i < n; i++)
                {
                    s += a[0, i];
                }
                for(int i = 1; i < n; i++)
                {
                    s1 = 0;
                    for(int j = 0; j < n; j++)
                    {
                        s1 += a[i, j];
                    }
                    if(s != s1)
                    {
                        return false;
                    }
                    
                }
                for(int i = 0; i < n; i++)
                {
                    s1 = 0;
                    for (int j = 0; j < n; j++)
                    {
                        s1 += a[j, i];
                    }
                    if (s != s1)
                    {
                        return false;
                    }
                }
                s1 = 0;
                for(int i = 0; i < n; i++)
                {
                    s1 += a[i, i];
                }
                if(s != s1) return false;
                
                s1 = 0;
                for(int i = 0; i < n; i++)
                {
                    s1 += a[i, n - 1 - i];
                }
                if(s != s1) return false;
                return true;
            }

        }
    }
}

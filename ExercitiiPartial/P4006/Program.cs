using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4006
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(input[0]);
            int a = int.Parse(input[1]);
            int b = int.Parse(input[2]);

            for(int y = 0; y * b <= n; y++)
            {
                int x = (n - y * b);
                if(x % a == 0)
                {
                    for(int i = 0; i < x / a; i++)
                    {
                        Console.Write($"{a} ");
                    }
                    for(int i = 0; i < y; i++)
                    {
                        Console.Write($"{b} ");
                    }
                    break;  
                }
            }
        }
    }
}

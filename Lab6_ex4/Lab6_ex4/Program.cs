using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            int a, b;
            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');
            a = int.Parse(numbers[0]);
            b = int.Parse(numbers[1]);
            int[] v1 = new int[numbers[0].Length];
            int[] v2 = new int[numbers[1].Length];
            int[] v3 = new int[numbers[2].Length];

            for(int i = 0; i < numbers[0].Length; i++)
            {
                v1[i] = a % 10;
                a /= 10;
            }
            for(int i = 0; i < numbers[1].Length; i++)
            {
                v2[i] = b % 10;
                b /= 10;
            }

            int adunare(int a, int b)
            {


            }
            //for(int i = 0; i < v1.Length; i++)
            //{
            //    Console.Write(v1[i] + " ");
            //}
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Turnurile din Hanoi
namespace Lab12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char A = 'A', B = 'B', C = 'C', D = 'D';

            Console.WriteLine("3 Tije");
            Hanoi3(n, A, B, C);

            Console.WriteLine("\n4 Tije");
            Hanoi4(n, A, B, C, D);
        }
        static void Hanoi3(int n, char A, char B, char C)
        {
            if (n == 1)
            {
                Console.WriteLine($"{A} -> {C}");
            }
            else
            {
                Hanoi3(n - 1, A, C, B);
                Hanoi3(1, A, B, C);
                Hanoi3(n - 1, B, A, C);
            }
        }
        static void Hanoi4(int n, char A, char B, char C, char D) 
        {
            if (n == 1)
            {
                Console.WriteLine($"{A} -> {C}");
            }
            else if(n == 2)
            {
                Console.WriteLine($"{A} -> {C}");
                Console.WriteLine($"{A} -> {D}");
                Console.WriteLine($"{C} -> {D}");
            }
            else
            {
                Hanoi4(n - 2, A, C, D, B);
                Hanoi4(1, A, B, D, C);
                Hanoi4(1, A, B, C, D);
                Hanoi4(1, C, A, B, D);
                Hanoi4(n - 2, B, A, C, D);
            }
        }
    }
}

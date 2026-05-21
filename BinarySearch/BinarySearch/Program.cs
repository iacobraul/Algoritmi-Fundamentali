using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] v = {31, 2, 9, 1, 3, 1, 5, 7, 8, 8, 12 };
            int x = int.Parse(Console.ReadLine());
            bool found = BinarySearch(v, 0, v.Length - 1, x);
            
            if(found)
                Console.WriteLine($"Element gasit");
            else
                Console.WriteLine("Element nu a fost gasit");

            int position = -1;
            position = BinarySearchPosition(v, 0, v.Length - 1, x);
            if(position != -1)
                Console.WriteLine($"{x} se afla pe pozitia {position}");
            else
                Console.WriteLine("Element nu a fost gasit");
        }
        static bool BinarySearch(int[] v, int st, int dr, int x)
        {
            if(st <= dr)
            {
                int m = (st + dr) / 2;
                if (v[m] == x)
                    return true;
                else
                {
                    if (x < v[m]) return BinarySearch(v, st, m - 1, x);
                    else return BinarySearch(v, m + 1, dr, x);
                }
            }
            return false;
        }
        static int BinarySearchPosition(int[] v, int st, int dr, int x)
        {
            if(st <= dr)
            {
                int m = (st + dr) / 2;
                if (v[m] == x)
                    return m;
                else
                {
                    if (x < v[m]) return BinarySearchPosition(v, st, m - 1, x);
                    else return BinarySearchPosition(v, m + 1, dr, x);
                }
            }
            return -1;
        }
    }
}

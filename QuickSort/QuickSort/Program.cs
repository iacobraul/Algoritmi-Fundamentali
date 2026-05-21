using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] v = { 8, 29, 7, 0, 5, 4, 4, 33, 21, 7 };
            QuickSort(v, 0, v.Length - 1);
            for (int i = 0; i < v.Length; i++) 
            {
                Console.Write(v[i] + " ");
            }
        }
        static void QuickSort(int[] v, int start, int end)
        {
            if(start < end)
            {
                int p = Partition(v, start, end);
                QuickSort(v, start, p - 1);
                QuickSort(v, p + 1, end);
            }
        }
        static int Partition(int[] v, int start, int end)
        {
            int pivot = v[end];
            int i = start - 1;
            for (int j = start; j < end; j++)
            {
                if (v[j] <= pivot)
                {
                    i++;
                    (v[i], v[j]) = (v[j], v[i]);
                }
            }
            (v[i + 1], v[end]) = (v[end],  v[i + 1]);
            return i + 1;
        }
    }
}

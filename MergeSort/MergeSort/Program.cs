using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//MergeSort
namespace MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] v = { 38, 27, 43, 3, 9, 82, 101, 99, 10 };
            MergeSort(v, 0, v.Length - 1);
            for(int i = 0; i < v.Length; i++)
            {
                Console.Write(v[i] + " ");
            }
        }
        static void MergeSort(int[] v, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(v, left, mid);
                MergeSort(v, mid + 1, right);
                Merge(v, left, mid, right);
            }
        }
        static void Merge(int[] v, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] v1 = new int[n1];
            int[] v2 = new int[n2];
            for (int i = 0; i < n1; i++)
                v1[i] = v[left + i];
            for (int j = 0; j < n2; j++)
                v2[j] = v[mid + 1 + j];
            int k = left, k1 = 0, k2 = 0;
            while (k1 < n1 && k2 < n2)
            {
                if (v1[k1] <= v2[k2])
                {
                    v[k] = v1[k1];
                    k1++; k++;
                }
                else
                {
                    v[k] = v2[k2];
                    k2++; k++;
                }
            }
            while (k1 < n1)
            {
                v[k] = v1[k1];
                k1++;
                k++;
            }
            while (k2 < n2)
            {
                v[k] = v2[k2];
                k2++;
                k++;
            }
        }
    }
}

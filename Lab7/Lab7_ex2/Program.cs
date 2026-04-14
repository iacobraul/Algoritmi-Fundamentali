using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextReader load = new StreamReader(@"../../data.in");
            string[] size = load.ReadLine().Split(' ');
            int n = int.Parse(size[0]);
            int m = int.Parse(size[1]);
            int[,] A = new int[n, m];

            for(int i = 0; i < n; i++)
            {
                string[] local = load.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                for(int j = 0; j < m; j++)
                {
                    A[i, j] = int.Parse(local[j]);
                }
            }
            load.Close();

            int[,] B = new int[n, m];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    List<int> data = new List<int>();

                    if (i - 1 >= 0 && j - 1 >= 0)   data.Add(A[i - 1, j - 1]);
                    if (i - 1 >= 0)                 data.Add(A[i - 1, j]);
                    if (i - 1 >= 0 && j + 1 < m)    data.Add(A[i - 1, j + 1]);
                    if (j - 1 >= 0)                 data.Add(A[i, j - 1]);
                    if (j + 1 < m)                  data.Add(A[i, j + 1]);
                    if (i + 1 < n && j - 1 >= 0)    data.Add(A[i + 1, j - 1]);
                    if (i + 1 < n)                  data.Add(A[i + 1, j]);
                    if (i + 1 < n && j + 1 < m)     data.Add(A[i + 1, j + 1]);
                    data.Add(A[i, j]);

                    data.Sort();
                    B[i, j] = data[(data.Count - 1) / 2];
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(B[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

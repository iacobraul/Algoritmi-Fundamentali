using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Problema teritoriilor
namespace Lab13
{
    internal class Program
    {   
        static void Main(string[] args)
        {
            StreamReader load = new StreamReader(@"../../data.in");
            string[] tokens = load.ReadLine().Split(' ');
            int n = int.Parse(tokens[0]);
            int m = int.Parse(tokens[1]);
            int nr = 0, t1 = 0, t2 = 0;
            int[,] a = new int[n, m];
            bool[,] visited = new bool[n, m];
            bool found1 = false, found2 = false;
            for(int i = 0; i < n; i++)
            {
                string[] data = load.ReadLine().Split(' ');
                for(int j = 0; j < m; j++)
                {
                    a[i,j] = int.Parse(data[j]);
                }
            }
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    a[i, j] = 0;
                    visited[i, j] = false;
                }
            }

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    nr = 0;
                    found1 = false;
                    found2 = false;
                    DFS(i,j, visited, a, n, m, nr, found1, found2);
                    if (found1 && !found2) t1 += nr;
                    if (found2 && !found1) t2 += nr;
                }
            }
            Console.WriteLine(t1 + ' ' + t2);
        }
        public static void DFS(int i, int j, bool[,] visited, int[,] a, int n, int m, int nr, bool found1, bool found2)
        {
            if(i >= 0 && j >= 0 && i < n && j < m && !visited[i,j])
            {
                if(a[i, j] == 0)
                {
                    visited[i, j] = true;
                    nr++;
                    DFS(i + 1, j, visited, a, n, m, nr, found1, found2);
                    DFS(i - 1, j, visited, a, n, m, nr, found1, found2);
                    DFS(i, j + 1, visited, a, n, m, nr, found1, found2);
                    DFS(i, j - 1, visited, a, n, m, nr, found1, found2);
                }
                else
                {
                    if (a[i, j] == 1) found1 = true;
                    else if (a[i,j] == 2) found2 = true;
                }
            }
        }
    }
}

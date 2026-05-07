using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Lab10
{
    internal class Program
    {
        public static int nr, t, max = 0;
        public static int[,] A;
        public static bool[,] B;
        static void Main(string[] args)
        {
            TextReader load = new StreamReader(@"../../data.in");
            List<string> lines = new List<string>();
            string buffer;
            while ((buffer = load.ReadLine()) != null) 
            {
                lines.Add(buffer);
            }
            int n = lines.Count;
            int m = lines[0].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Length;
            A = new int[n, m];
            B = new bool[n, m];
            for(int i = 0; i < n; i++)
            {   
                string[] data = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < m; j++) 
                {
                    A[i,j] = int.Parse(data[j]);
                }
            }
            for (int i = 0; i < n; i++)
            { 
                for(int j = 0; j < m; j++)
                {
                    if (!B[i, j])
                    {
                        nr = 0;
                        t = A[i, j];
                        PA(i, j);
                        if (nr > max) max = nr;
                    }
                }
            }
            Console.WriteLine("Max: " + max);
            load.Close();
        }
        public static void PA(int i, int j)
        {
            if(i >= 0 && j >= 0 && i<A.GetLength(0) && j < A.GetLength(1) && !B[i,j] && A[i,j] == t)
            {
                nr++;
                B[i, j] = true;
                PA(i - 1, j);
                PA(i, j + 1);
                PA(i + 1, j);
                PA(i, j - 1);
            }
        }
    }
}

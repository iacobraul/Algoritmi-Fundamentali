using System;
using System.IO;

namespace Lab7_ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextReader load = new StreamReader(@"../../data.in");
            string[] size = load.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(size[0]);
            int m = int.Parse(size[1]);

            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                string[] line = load.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < m; j++)
                    a[i, j] = int.Parse(line[j]);
            }

            bool modificat;
            int etapa = 0;

            do
            {
                modificat = false;
                int[,] b = (int[,])a.Clone();

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (a[i, j] == 1)
                        {
                            int count = NumarVeciniZero(a, i, j, n, m);
                            if (count >= 2)
                            {
                                b[i, j] = 0;
                                modificat = true;
                            }
                        }
                    }
                }

                if (modificat)
                {
                    a = b;
                    etapa++;
                    Console.WriteLine($"Etapa {etapa}:");
                    AfisareMatrice(a, n, m);
                }

            } while (modificat);
        }

        static int NumarVeciniZero(int[,] mat, int r, int c, int n, int m)
        {
            int count = 0;
            int[] dr = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dc = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < 8; i++)
            {
                int nouR = r + dr[i];
                int nouC = c + dc[i];

                if (nouR >= 0 && nouR < n && nouC >= 0 && nouC < m)
                {
                    if (mat[nouR, nouC] == 0) count++;
                }
            }
            return count;
        }

        static void AfisareMatrice(int[,] mat, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(mat[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
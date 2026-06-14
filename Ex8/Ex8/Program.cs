using System;
using System.IO;

namespace Ex8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Citire date din fisier
            TextReader load = new StreamReader(@"../../data.in");
            string buffer = load.ReadLine();
            string[] data = buffer.Split(' ');

            int n = int.Parse(data[0]);
            int m = int.Parse(data[1]);
            int k = int.Parse(data[2]);

            int[,] matrix = new int[n, m];
            bool[,] visited = new bool[n, m];
            int[] score = new int[k + 1];

            int i = 0;
            while ((buffer = load.ReadLine()) != null && i < n)
            {
                string[] line = buffer.Split(' ');
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = int.Parse(line[j]);
                }
                i++;
            }
            load.Close();

            for (i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0 && !visited[i, j])
                    {
                        bool[] found = new bool[k + 1];
                        int nrCelule = 0;

                        DFS(i, j, matrix, visited, found, ref nrCelule);

                        int jucatorUnic = 0;
                        int numarJucatoriGasiti = 0;

                        for (int x = 1; x <= k; x++)
                        {
                            if (found[x])
                            {
                                numarJucatoriGasiti++;
                                jucatorUnic = x;
                            }
                        }

                        if (numarJucatoriGasiti == 1)
                        {
                            score[jucatorUnic] += nrCelule;
                        }
                    }
                }
            }

            for (i = 1; i <= k; i++)
            {
                Console.WriteLine($"Jucatorul {i}: {score[i]} puncte");
            }
        }

        public static void DFS(int i, int j, int[,] matrix, bool[,] visited, bool[] found, ref int nrCelule)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (i < 0 || i >= n || j < 0 || j >= m || visited[i, j])
            {
                return;
            }
            if (matrix[i, j] != 0)
            {
                found[matrix[i, j]] = true;
                return;
            }

            visited[i, j] = true;
            nrCelule++;

            DFS(i - 1, j, matrix, visited, found, ref nrCelule); // Sus
            DFS(i + 1, j, matrix, visited, found, ref nrCelule); // Jos
            DFS(i, j - 1, matrix, visited, found, ref nrCelule); // Stanga
            DFS(i, j + 1, matrix, visited, found, ref nrCelule); // Dreapta
        }
    }
}
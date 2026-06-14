using System;
using System.IO;

namespace Ex8_R2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextReader load = new StreamReader(@"../../data.in");
            int n = int.Parse(load.ReadLine());
            string buffer;

            bool[,,] cub = new bool[n, n, n];
            bool[,,] visited = new bool[n, n, n];
            int i = 0, d = 0, max = 0;

            while ((buffer = load.ReadLine()) != null)
            {
                string[] data = buffer.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n; j++)
                {
                    cub[i, j, d] = (data[j] == "1");
                }
                i++;
                if (i == n)
                {
                    i = 0;
                    d++;
                }
            }
            load.Close();

            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    for (int z = 0; z < n; z++)
                    {
                        if (cub[x, y, z] && !visited[x, y, z])
                        {
                            int cnt = 0;
                            DFS(x, y, z, n, cub, visited, ref cnt);
                            if (cnt > max) max = cnt;
                        }
                    }
                }
            }

            Console.WriteLine($"Cea mai mare aglomerare de 'true' are: {max} elemente.");
        }

        public static void DFS(int x, int y, int z, int n, bool[,,] cub, bool[,,] visited, ref int cnt)
        {
            if (x < 0 || y < 0 || z < 0 || x >= n || y >= n || z >= n) return;

            if (visited[x, y, z] || !cub[x, y, z]) return;

            visited[x, y, z] = true;
            cnt++;

            DFS(x, y - 1, z, n, cub, visited, ref cnt);
            DFS(x, y + 1, z, n, cub, visited, ref cnt);
            DFS(x - 1, y, z, n, cub, visited, ref cnt);
            DFS(x + 1, y, z, n, cub, visited, ref cnt);
            DFS(x, y, z - 1, n, cub, visited, ref cnt);
            DFS(x, y, z + 1, n, cub, visited, ref cnt);
        }
    }
}
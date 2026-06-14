using System;
using System.Collections.Generic;
using System.IO;
namespace P4923
{
    class StarryNight
    {
        // Structură pentru a reprezenta o stea/punct în matrice
        struct Point : IComparable<Point>
        {
            public int X, Y;
            public Point(int x, int y) { X = x; Y = y; }

            public int CompareTo(Point other)
            {
                if (this.X != other.X) return this.X.CompareTo(other.X);
                return this.Y.CompareTo(other.Y);
            }
        }

        // Listă în care salvăm formele unice găsite, împreună cu litera lor
        static List<(List<Point> Shape, char Label)> uniqueShapes = new List<(List<Point>, char)>();
        static char nextLabel = 'a';

        static int W, H;
        static char[,] grid;
        static bool[,] visited;

        // Cele 8 direcții pe verticală, orizontală și diagonală
        static int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
        static int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

        static void Main(string[] args)
        {
            // Citirea datelor de intrare
            if (!File.Exists("starrynight.in")) return;

            string[] lines = File.ReadAllLines("starrynight.in");
            if (lines.Length == 0) return;

            // pbinfo specifică dimensiunile. Presupunem că prima linie conține lățimea (W) și a doua înălțimea (H), sau invers.
            // În problema originală IOI, ordinea este W (coloane) și H (linii).
            string[] dimensions = lines[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (dimensions.Length < 2)
            {
                W = int.Parse(lines[0].Trim());
                H = int.Parse(lines[1].Trim());
                grid = new char[H, W];
                for (int i = 0; i < H; i++)
                {
                    string row = lines[i + 2].Replace(" ", "");
                    for (int j = 0; j < W; j++) grid[i, j] = row[j];
                }
            }
            else
            {
                W = int.Parse(dimensions[0]);
                H = int.Parse(dimensions[1]);
                grid = new char[H, W];
                for (int i = 0; i < H; i++)
                {
                    string row = lines[i + 1].Replace(" ", "");
                    for (int j = 0; j < W; j++) grid[i, j] = row[j];
                }
            }

            visited = new bool[H, W];

            // Parcurgem matricea pentru a găsi roiurile de stele
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    if (grid[i, j] == '1' && !visited[i, j])
                    {
                        List<Point> cluster = new List<Point>();
                        FloodFill(i, j, cluster);

                        char label = GetLabelForShape(cluster);

                        // Marcăm roiul pe hartă cu litera corespunzătoare
                        foreach (var p in cluster)
                        {
                            grid[p.X, p.Y] = label;
                        }
                    }
                }
            }

            // Scrierea rezultatului în fișierul de ieșire
            using (StreamWriter sw = new StreamWriter("starrynight.out"))
            {
                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++)
                    {
                        sw.Write(grid[i, j]);
                    }
                    sw.WriteLine();
                }
            }
        }

        // Algoritmul BFS pentru extragerea unui roi (grup conex)
        static void FloodFill(int startX, int startY, List<Point> cluster)
        {
            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(new Point(startX, startY));
            visited[startX, startY] = true;

            while (queue.Count > 0)
            {
                Point curr = queue.Dequeue();
                cluster.Add(curr);

                for (int i = 0; i < 8; i++)
                {
                    int nx = curr.X + dx[i];
                    int ny = curr.Y + dy[i];

                    if (nx >= 0 && nx < H && ny >= 0 && ny < W)
                    {
                        if (grid[nx, ny] == '1' && !visited[nx, ny])
                        {
                            visited[nx, ny] = true;
                            queue.Enqueue(new Point(nx, ny));
                        }
                    }
                }
            }
        }

        // Normalizează o listă de puncte mutându-le în originea (0,0) și sortându-le
        static List<Point> Normalize(List<Point> points)
        {
            int minX = int.MaxValue, minY = int.MaxValue;
            foreach (var p in points)
            {
                if (p.X < minX) minX = p.X;
                if (p.Y < minY) minY = p.Y;
            }

            List<Point> normalized = new List<Point>();
            foreach (var p in points)
            {
                normalized.Add(new Point(p.X - minX, p.Y - minY));
            }

            normalized.Sort();
            return normalized;
        }

        // Verifică dacă două forme normalizate sunt perfect identice
        static bool AreIdentical(List<Point> shape1, List<Point> shape2)
        {
            if (shape1.Count != shape2.Count) return false;
            for (int i = 0; i < shape1.Count; i++)
            {
                if (shape1[i].X != shape2[i].X || shape1[i].Y != shape2[i].Y)
                    return false;
            }
            return true;
        }

        // Determină litera potrivită pentru formă (nouă sau existentă)
        static char GetLabelForShape(List<Point> cluster)
        {
            // Generăm cele 8 reprezentări posibile ale formei curente
            List<List<Point>> symmetries = new List<List<Point>>();

            // T0..T3: Rotații. T4..T7: Reflexii + Rotații
            for (int i = 0; i < 8; i++) symmetries.Add(new List<Point>());

            foreach (var p in cluster)
            {
                int x = p.X;
                int y = p.Y;

                symmetries[0].Add(new Point(x, y));   // Identitate
                symmetries[1].Add(new Point(y, -x));  // Rotație 90
                symmetries[2].Add(new Point(-x, -y)); // Rotație 180
                symmetries[3].Add(new Point(-y, x));  // Rotație 270

                symmetries[4].Add(new Point(x, -y));  // Reflexie orizontală
                symmetries[5].Add(new Point(-x, y));  // Reflexie verticală
                symmetries[6].Add(new Point(y, x));   // Reflexie diagonală 1
                symmetries[7].Add(new Point(-y, -x)); // Reflexie diagonală 2
            }

            // Normalizăm toate cele 8 variații
            for (int i = 0; i < 8; i++)
            {
                symmetries[i] = Normalize(symmetries[i]);
            }

            // Căutăm dacă vreuna dintre simetrii se potrivește cu o formă deja salvată
            foreach (var unique in uniqueShapes)
            {
                foreach (var sym in symmetries)
                {
                    if (AreIdentical(unique.Shape, sym))
                    {
                        return unique.Label; // Am găsit o formă similară, returnăm litera ei
                    }
                }
            }

            // Dacă forma este complet nouă, o înregistrăm cu o literă nouă
            char assignedLabel = nextLabel;
            uniqueShapes.Add((symmetries[0], assignedLabel));
            nextLabel++;
            return assignedLabel;
        }
    }
}
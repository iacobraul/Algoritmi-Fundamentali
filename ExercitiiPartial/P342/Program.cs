using System;
using System.IO;

namespace P342
{
    internal class Program
    {
        // Folosim o variabilă statică pentru a fi accesibilă din Backtracking
        public static int solutii = 0;

        static void Main(string[] args)
        {
            // Folosim direct fișierele din folderul curent (sau calea dorită)
            // Este recomandat să folosim "using" pentru a închide automat fluxurile
            
               
                StreamReader load = new StreamReader(@"../../soarece.in");
                StreamWriter save = new StreamWriter(@"../../soarece.out");
                int n, m;
                int[,] tabla;
                int isrc, jsrc, idest, jdest;
                int[] di = { -1, 0, 1, 0 };
                int[] dj = { 0, 1, 0, -1 };

                string line1 = load.ReadLine();
                if (line1 == null) return;

                string[] dim = line1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                n = int.Parse(dim[0]);
                m = int.Parse(dim[1]);

                tabla = new int[n + 1, m + 1];

                for (int i = 1; i <= n; i++)
                {
                    string[] valori = load.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 1; j <= m; j++)
                    {
                        tabla[i, j] = int.Parse(valori[j - 1]);
                    }
                }

                string[] coord = load.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                isrc = int.Parse(coord[0]);
                jsrc = int.Parse(coord[1]);
                idest = int.Parse(coord[2]);
                jdest = int.Parse(coord[3]);

                // Marcăm punctul de start
                tabla[isrc, jsrc] = 1;

                Backtracking(isrc, jsrc, idest, jdest, tabla, n, m, di, dj);

                save.Write(solutii);

            load.Close();
            save.Close();
        }

        static void Backtracking(int i, int j, int idest, int jdest, int[,] tabla, int n, int m, int[] di, int[] dj)
        {
            if (i == idest && j == jdest)
            {
                solutii++; // Modifică variabila statică globală
                return;
            }

            for (int d = 0; d < 4; d++)
            {
                int nextI = i + di[d];
                int nextJ = j + dj[d];

                if (nextI >= 1 && nextI <= n && nextJ >= 1 && nextJ <= m && tabla[nextI, nextJ] == 0)
                {
                    tabla[nextI, nextJ] = 1;
                    Backtracking(nextI, nextJ, idest, jdest, tabla, n, m, di, dj);
                    tabla[nextI, nextJ] = 0; // Backtrack
                }
            }
        }
    }
}
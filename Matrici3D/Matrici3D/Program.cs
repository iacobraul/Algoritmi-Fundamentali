using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrici3D
{
    internal class Program
    {
        static void Main(string[] args)
        {   int[,,] matrice3D = new int[2, 3, 4]; // Exemplu de inițializare a unei matrice 3D
            int straturi = matrice3D.GetLength(0);
            int randuri = matrice3D.GetLength(1);
            int coloane = matrice3D.GetLength(2);

            for (int i = 0; i < straturi; i++)
            {
                for (int j = 0; j < randuri; j++)
                {
                    for (int k = 0; k < coloane; k++)
                    {
                        Console.Write($"{matrice3D[i, j, k]} ");
                    }
                    Console.WriteLine(); // Linie nouă după fiecare rând
                }
                Console.WriteLine("--- Sfârșit Strat ---");
            }
        }
    }
}

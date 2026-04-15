using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P267
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextReader load = new StreamReader(@"../../data.in");
            TextWriter save = new StreamWriter(@"../../data.out");
            string buffer;
            int n = int.Parse(load.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0]);
            int[] v = new int[100];
            while ((buffer = load.ReadLine()) != null) 
            {
                string[] local = buffer.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < local.Length; i++) 
                {
                    v[int.Parse(local[i])]++;
                }
            }

            for (int i = 0; i < 100; i++) 
            {
                if (v[i] == 1)
                {
                    save.Write($"{i} ");
                }
            }
            
            load.Close();
            save.Close();
        }
    }
}

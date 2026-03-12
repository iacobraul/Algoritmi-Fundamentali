using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace P187
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextReader load = new StreamReader(@"..\..\ciffrecv.in");
            TextWriter save = new StreamWriter(@"..\..\ciffrecv.out");
            int[] v = new int[10];

            string buffer;
            while ((buffer = load.ReadLine()) != null)
            {
                string[] local = buffer.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string str in local)
                {
                    int t = int.Parse(str);
                    v[t]++;
                }
            }

            int MAX = 0, NR_AP = 0;
            if (v[7] != 0)
            {
                MAX = 7;
                NR_AP = v[7];
            }
            else if (v[5] != 0)
            {
                MAX = 5;
                NR_AP = v[5];
            }
            else if (v[3] != 0)
            {
                MAX = 3;
                NR_AP = v[3];
            }
            else if (v[2] != 0)
            {
                MAX = 1;
                NR_AP = v[1];
            }
            save.Write(MAX + " " + NR_AP);

            save.Close();
        }
    }
}

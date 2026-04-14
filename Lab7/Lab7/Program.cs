 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextReader load = new StreamReader(@"../../data.in");
            string buffer;
            List<string> data = new List<string>();
            while((buffer = load.ReadLine()) != null)
            {
                data.Add(buffer);
            }
            load.Close();

            int[] v = new int[101];
            int[] nr = new int[101];
            foreach (string s in data)
            {
                string[] local = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach(string l in local)
                {
                    v[int.Parse(l)]++;
                }
            }

            for(int i = 0; i < 101; i++)
            {
                nr[i] = i;
            }

            for(int i = 0; i < 100; i++)
            {
                for(int j = i + 1; j < 101; j++)
                {
                    if (v[i] < v[j])
                    {
                        (v[i], v[j]) = (v[j], v[i]);
                        (nr[i], nr[j]) = (nr[j], nr[i]);
                    }
                }
            }

            for (int i = 0; i < 100; i++)
            {
                if(v[i] != 0)
                {
                    Console.WriteLine(nr[i] + ":" + v[i]);
                }
            }
        }
    }
}

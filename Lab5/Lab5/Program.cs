using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{   
    internal class Program
    {
        public class Spectacol
        {
            public int ti;
            public int tf;
            public Spectacol(int ti, int tf)
            {
                this.ti = ti;
                this.tf = tf;
            }
            public Spectacol(string data)
            {
                this.ti = int.Parse(data.Split(' ')[0]);
                this.tf = int.Parse(data.Split(' ')[1]);
            }

            public string View()
            {
                return ti + " " + tf;
            }
        }
        public class T
        {
            List<Spectacol> list;
            public T()
            {
                list = new List<Spectacol>();
            }
            public void Load(string fileName)
            {
                list = new List<Spectacol>();
                TextReader load = new StreamReader(fileName);
                string buffer;
                while ((buffer = load.ReadLine()) != null)
                {
                    list.Add(new Spectacol(buffer));
                }
                load.Close();
            }
            public List<string> View()
            {
                List<string> tor = new List<string>();
                foreach (Spectacol s in list)
                {
                    tor.Add(s.View());
                }
                return tor;
            }
            public void Sort()
            {
                for (int i = 0; i < list.Count - 1; i++)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        if (list[i].tf > list[j].tf)    (list[i], list[j]) = (list[j], list[i]);
                    }
                }
            }
            public void Selectie()
            {
                Sort();
                Console.WriteLine(list[0].View());
                int t = list[0].tf;
                for (int i = 1; i < list.Count; i++)
                {
                    if (list[i].ti >= t)
                    {
                        Console.WriteLine(list[i].View());
                        t = list[i].tf;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            T demo = new T();
            demo.Load(@"..\..\data.in");
            
            demo.Selectie();
            Console.ReadKey();
        }
    }
}

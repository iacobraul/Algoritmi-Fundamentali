using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1Partial
{
    public class Array
    {
        private int[] v;
        public Array(int[] v)
        {
            this.v = v;
        }
        public Array PowerOfArray()
        {
            int[] P = new int[v.Length];
            for(int i = 0; i < v.Length; i++)
            {
                P[v[i]]++;
            }
            for(int i = 0; i < P.Length - 1; i++)
            {
                for(int j = i + 1; j < P.Length ; j++)
                 if (P[j] > P[i])
                    {
                        int temp = P[i];
                        P[i] = P[j];
                        P[j] = temp;
                    }
            }
            return new Array(P);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < v.Length; i++)
            {
                if (v[i] != 0)
                sb.Append(v[i] + " ");
            }
            return sb.ToString();
        }
        public static bool operator >(Array a, Array b)
        {
            int[] Pa = a.PowerOfArray().v;
            int[] Pb = b.PowerOfArray().v;
            for (int i = 0; i < Pa.Length; i++)
            {
                if (Pa[i] > Pb[i]) return true;
                if (Pa[i] < Pb[i]) return false;
            }
            return false;
        }
        public static bool operator <(Array a, Array b)
        {
            if (!(a > b)) return true;
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Array v1 = new Array(new int[] { 1, 2, 3, 4, 5, 5, 5, 3 });
            Array v2 = new Array(new int[] { 1, 1, 2, 2, 3, 3});
            Console.WriteLine("P(v1) = " + v1.PowerOfArray());
            Console.WriteLine("P(v2) = " + v2.PowerOfArray());
            Console.WriteLine(v1 > v2 ? "v1 > v2" : "v1 <= v2");
        }
    }
}

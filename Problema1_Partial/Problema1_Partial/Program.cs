using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Problema1_Partial
{
    internal class Program
    {
        public class INTL
        {
            public int[] digits;
            public INTL(int n)
            {
                int sn = n;
                int nd = 0;
                while(sn != 0)
                {
                    sn /= 10;
                    nd++;
                }

                digits = new int[nd];
                int ct = nd - 1;
                while(n != 0)
                {
                    digits[ct] = n % 10;
                    n /= 10;
                    ct--;
                }
            }
            public INTL(int[] digits)
            {
                this.digits = digits;
            }
            public string View()
            {
                string tor = "";
                for(int i = 0; i < digits.Length; i++)
                {
                    tor += digits[i];
                }
                return tor;
            }
            public void Reverse()
            {
                for(int i = 0; i < digits.Length / 2; i++)
                {
                    int aux = digits[i];
                    digits[i] = digits[digits.Length - 1 - i];
                    digits[digits.Length - 1 - i] = aux;
                }
            }
            public static INTL operator+(INTL a, INTL b)
            {
                a.Reverse();
                b.Reverse();

                int max = a.digits.Length > b.digits.Length ? a.digits.Length : b.digits.Length;
                int[] T = new int[max];
                int depasire = 0;
                for(int i = 0; i < max; i++)
                {
                    int t1 = 0;
                    int t2 = 0;
                    if(i < a.digits.Length) t1 = a.digits[i];
                    if(i < b.digits.Length) t2 = b.digits[i];
                    T[i] = (t1 + t2 + depasire) % 10;
                    depasire = (t1 + t2 + depasire) / 10;
                }

                int[] tmp;
                if(depasire != 0)
                {
                    tmp = new int[max + 1];
                    for(int i = 0; i < max; i++)
                    {
                        tmp[i] = T[i];
                    }
                    tmp[max] = depasire;
                }
                else
                {
                    tmp = new int[max];
                    for (int i = 0; i < max; i++)
                    {
                        tmp[i] = T[i];
                    }
                }
                INTL tor = new INTL(tmp);

                //for ( int i = 0; i < tmp.Length; i++)
                //{
                //    Console.Write(tmp[i] + " ");
                //}

                return tor;
            }
            public long Get(int k)
            {
                long tor = 0;
                for(int i = 0; i < 10; i++)
                {
                    tor = tor * 10 + digits[k+i];
                }
                return tor;
            }
        }
        public static class Algorithms
        {
            public static bool IsPrime(long n)
            {
                if (n < 2) return false;
                if (n == 2) return true;
                if (n % 2 == 0) return false;
                for (long i = 3; i * i <= n; i+=2)
                {
                    if (n % i == 0) return false;
                }
                return true;
            }
        }
        class Array
        {
            public int[] values;
            public Array(int[] values)
            {
                this.values = values;
            }
            public string View()
            {
                string tor = "";
                for(int i = 0; i < values.Length; i++)
                {
                    tor += values[i] + " ";
                }
                return tor;
            }
            public Array Power()
            {
                int[] frecv = new int[201];
                
                for(int i = 0; i < values.Length; i++)
                {
                    frecv[values[i] + 100]++;
                }

                int n = 0;
                for (int i = 0; i <= 200; i++)
                {
                    if (frecv[i] != 0) n++;
                }

                int[] tmp = new int[n];
                int k = 0;
                for(int i =0; i<= 200; i++)
                {
                    if (frecv[i] != 0)
                    {
                        tmp[k] = frecv[i];
                        k++;
                    }
                }

                for (int i = 0;  i < k - 1; i++)
                {
                    for(int j = i + 1; j < k; j++)
                    {
                        if (tmp[i] < tmp[j])
                        {
                            int aux = tmp[i];
                            tmp[i] = tmp[j];
                            tmp[j] = aux;
                        }
                    }
                }
                return new Array(tmp);
            }
            public static bool operator <(Array a, Array b)
            {
                Array p1 = a.Power();
                Array p2 = b.Power();
                int k = 0;
                while(k < p1.values.Length && k < p2.values.Length)
                {
                    if (p1.values[k] < p2.values[k]) return true;
                    else
                    {
                        if (p1.values[k] == p2.values[k]) k++;
                        else return false;
                    }   
                }
                if (k == p1.values.Length) return false;
                else return true;
            }
            public static bool operator >(Array a, Array b)
            {
                return !(a < b);
            }
        }

        public static void View(int[,] ToView)
        {
            for (int i = 0; i < ToView.GetLength(0); i++)
            {
                for (int j = 0; j < ToView.GetLength(1); j++)
                {
                    Console.Write(ToView[i, j] + " ");
                }
            }
        }
        static void Main(string[] args)
        {
            #region Ex1
            //Ex1
            /*Array v1 = new Array(new int[] { 1, 2, 3, -12, 3, 5, 5, 5, -100, 2, 2, 1, 100 });
            Array v2 = new Array(new int[] { -1, 2, 3, 12, 3, 5, 100, 2, 2, 100, 1, 2, -100 });
            Array v1p = v1.Power();
            Array v2p = v2.Power();
            Console.WriteLine(v1.View());
            Console.WriteLine(v2.View());
            Console.WriteLine(v1p.View());
            Console.WriteLine(v2p.View());
            Console.WriteLine(v1 > v2);
            Console.ReadKey();
            */
            #endregion
            #region Ex2
            /*INTL a = new INTL(1);
            INTL b = new INTL(1);
            INTL c = a + b;
            for(int i = 3; i < 400; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            Console.WriteLine(c.View());
            for(int i = 0; i < c.digits.Length - 10; i++)
            {
                long tmp = c.Get(i);
                if(Algorithms.IsPrime(tmp))
                {
                    Console.WriteLine(tmp);
                }
            }
            Console.ReadKey();*/
            #endregion
            #region Ex3
            int[,] a =new int[,] { {1, 2, 3},{2, 3, 4},{3, 4, 5},{4, 5, 6} };
            int[,] b =new int[a.GetLength(1), a.GetLength(0)];
            for(int i = 0; i < a.GetLength(0); i++)
            {
                for(int j = 0; j < a.GetLength(1); j++)
                {
                    b[a.GetLength(1) - j - 1, i] = a[i, j];
                }
            }
            View(a);
            View(b);
            #endregion
        }
    }
}

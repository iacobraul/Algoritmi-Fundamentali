using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex5_R2
{
    public class MyQueue
    {
        public int[] data;
        public int front, back;
        public int count;
        public MyQueue()
        {
            data = new int[16];
            front = 0; back = 0;
            count = 0;
        }
        public void Enqueue(int value)
        {
            if (count == data.Length) Resize();
            for (int i = 0; i < data.Length; i++) 
            {
                if (data[i] == value) return;
            }
            data[front] = value;
            front++;
            count++;
        }
        public int Dequeue()
        {
            if (count == 0) throw new InvalidOperationException("Queue is empty");

            int tmp = data[back];
            back++;
            count--;
            return tmp;
        }
        private void Resize()
        {
            int[] newData = new int[data.Length * 2];
            for (int i = 0; i < data.Length; i++)
            {
                newData[i] = data[i];
            }
            data = newData;
        }
        public int Count => count;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = back; i < front; i++)
            {
                sb.Append(data[i] + " ");
            }
            return sb.ToString();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> A = new Stack<int>();
            Stack<int> C = new Stack<int>();
            MyQueue B = new MyQueue();
            TextReader load = new StreamReader(@"../../data.in");
            string buffer;
            while ((buffer = load.ReadLine()) != null)
            {
                string[] data = buffer.Split(',');
                foreach (string s in data)
                {
                    string operation;
                    int value = 0;
                    if (s.Length > 2)
                    {
                        string[] parts = s.Split(' ');
                        operation = parts[0];
                        value = int.Parse(parts[1]);
                    }
                    else
                    {
                        operation = s;
                    }
                    if (operation == "M1")
                    {
                        A.Push(value);
                    }
                    else if (operation == "M2")
                    {
                        value = A.Pop();
                        B.Enqueue(value);
                    }
                    else if (operation == "M3")
                    {
                        value = B.Dequeue();
                        C.Push(value);
                    }
                    else if (operation == "M4")
                    {
                        Console.WriteLine(C.Pop());
                    }
                }//foreach
            }//while
            Console.Write("A: ");
            foreach (int a in A)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();

            Console.WriteLine($"B: {B}");

            Console.Write("C: ");
            foreach (int c in C)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }
    }
}

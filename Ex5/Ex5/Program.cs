using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ex5
{   
    public class MyStack
    {
        public int[] stack;
        public int count = 0;
        public int size;
        public MyStack()
        {
            stack = new int[16]; // Default size
            this.size = 16;
        }
        public void Push(int value)
        {
            for (int i = 0; i < stack.Length; i++)
            {
                if (stack[i] == value)
                {
                    return;
                }
            }
            if (count == size) Resize();
            stack[count] = value;
            count++;
        }
        public int Pop()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Stiva este goala");
            }
            count--;
            return stack[count];
        }
        public void Resize()
        {
            int newSize = size * 2;
            int[] newStack = new int[newSize];
            for (int i = 0; i < count; i++)
            {
                newStack[i] = stack[i];
            }
            stack = newStack;
            size = newSize;
        }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                s.Append(stack[i] + " ");
            }
            return s.ToString();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> A = new Queue<int>();
            Stack<int> C = new Stack<int>();
            MyStack B = new MyStack();
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
                        A.Enqueue(value);
                    }
                    else if (operation == "M2")
                    {
                        value = A.Dequeue();
                        B.Push(value);
                    }
                    else if (operation == "M3")
                    {
                        value = B.Pop();
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
        }//main
    }//Program
}//Ex5

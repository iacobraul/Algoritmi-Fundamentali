using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class Form1 : Form
    {
        int[,] a;
        public Form1()
        {
            InitializeComponent();
        }
        void LoadMatrix(string filename)
        {
            TextReader load = new StreamReader(filename);
            List <string> strings = new List<string>();
            string buffer;
            while((buffer = load.ReadLine()) != null)
            {
                strings.Add(buffer);
            }
            load.Close();
            int n = strings.Count;
            int m = strings[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
            a = new int[n, m];
            for(int i = 0; i < n; i++)
            {
                string[] local = strings[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = int.Parse(local[j]);
                }
            }
        }
        List <string> ViewMatrix()
        {
            List<string> tor = new List<string>();
            string buffer;
            for(int i = 0; i < a.GetLength(0); i++ )
            {
                buffer = "";
                for(int j = 0; j < a.GetLength(1); j++)
                {
                    buffer += a[i, j] + " ";
                }
                tor.Add(buffer);
            }
            return tor;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadMatrix(@"../../data.in");
            foreach (string str in ViewMatrix())
                listBox1.Items.Add(str);
            Lee();
            foreach (string str in ViewMatrix())
                listBox1.Items.Add(str);
            listBox1.Items.Add(RPN("2 5 + 3 / 7 + 2 7 * -"));
        }
        public string RPN(string str)
        {
            StackTD stackTD = new StackTD();
            string[] local = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < local.Length; i++)
            {
                if (local[i] == "+")
                {
                    int a = stackTD.Pop();
                    int b = stackTD.Pop();
                    stackTD.Push(a + b);
                }
                else if (local[i] == "-")
                {
                    int a = stackTD.Pop();
                    int b = stackTD.Pop();
                    stackTD.Push(b - a);
                }
                else if (local[i] == "*")
                {
                    int a = stackTD.Pop();
                    int b = stackTD.Pop();
                    stackTD.Push(a * b);
                }
                else if (local[i] == "/")
                {
                    int a = stackTD.Pop();
                    int b = stackTD.Pop();
                    stackTD.Push(b / a);
                }
                else
                {
                    stackTD.Push(int.Parse(local[i]));
                }
            }
            return stackTD.Pop().ToString();
        }
        public void Lee()
        {
            QueueTD queueTD = new QueueTD();
            queueTD.Push(new TriData(0, 0, 1));
            a[0, 0] = 1;
            while(!queueTD.IsEmpty())
            {
                TriData x = queueTD.Pop();
                if(x.row - 1 >= 0 && a[x.row - 1, x.col] == 0)
                {
                    queueTD.Push(new TriData(x.row - 1, x.col, x.val + 1));
                    a[x.row - 1, x.col] = x.val + 1;
                }
                if(x.row + 1 < a.GetLength(0) && a[x.row + 1, x.col] == 0)
                {
                    queueTD.Push(new TriData(x.row + 1, x.col, x.val + 1));
                    a[x.row + 1, x.col] = x.val + 1;
                }
                if(x.col - 1 >= 0 && a[x.row, x.col - 1] == 0)
                {
                    queueTD.Push(new TriData(x.row, x.col - 1, x.val + 1));
                    a[x.row, x.col - 1] = x.val + 1;
                }
                if(x.col + 1 < a.GetLength(1) && a[x.row, x.col + 1] == 0)
                {
                    queueTD.Push(new TriData(x.row, x.col + 1, x.val + 1));
                    a[x.row, x.col + 1] = x.val + 1;
                }
            }
        }
    }
    public class TriData
    {
        public int row, col, val;
        public TriData() { }
        public TriData(int row, int col, int val) 
        {
            this.row = row;
            this.col = col;
            this.val = val;
        }
        public string View()
        {
            return "(" + row + " " + col + " " + val + ")";
        }
    }
    public class QueueTD
    {
        TriData[] values;
        public QueueTD() 
        {
            values = new TriData[0];
        }
        public bool IsEmpty() 
        {
            return values.Length == 0;
        }
        public void Push(TriData value) 
        {
            TriData[] tmp = new TriData[values.Length + 1];
            for (int i = 0; i < values.Length; i++) 
            {
                tmp[i + 1] = values[i];
            }
            tmp[0] = value;
            values = tmp;
        }
        public TriData Pop() 
        {
            TriData tor = values[values.Length - 1];
            TriData[] tmp = new TriData[values.Length - 1];
            for(int i  = 0; i < values.Length - 1;i++)
            {
                tmp[i] = values[i];
            }
            values = tmp;
            return tor;
        }
        public string View()
        {
            string tor = "";
            for(int i =0; i < values.Length; i++)
            {
                tor += values[i];
            }
            return tor;
        }
    }
    public class StackTD
    {
        int[] values;
        public StackTD() 
        { 
            values = new int[0];
        }
        public StackTD(int[] values)
        { 
            this.values = values;
        }
        public bool IsEmpty()
        {
            return values.Length == 0;
        }
        public void Push(int value)
        {
            int[] tmp = new int[values.Length + 1];
            for (int i = 0; i < values.Length; i++)
            {
                tmp[i + 1] = values[i];
            }
            tmp[0] = value;
            values = tmp;
        }
        public int Pop()
        {
            int tor = values[0];
            int[] tmp = new int[values.Length - 1];
            for (int i = 0; i < values.Length - 1; i++)
            {
                tmp[i] = values[i + 1];
            }
            values = tmp;
            return tor;
        }
        public string View()
        {
            string tor = "";
            for (int i = 0; i < values.Length; i++)
            {
                tor += values[i] + " ";
            }
            return tor;
        }
    }
}

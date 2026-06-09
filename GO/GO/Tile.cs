using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GO
{
    public class Tile
    {
        public int value;
        public PointF center;
        private void DrawBase(Graphics handler, Color fillColor, Color drawColor, int drawSize)
        {
            handler.FillEllipse(new SolidBrush(fillColor), center.X - drawSize, center.Y - drawSize, drawSize * 2, drawSize * 2);
            handler.DrawEllipse(new Pen(drawColor), center.X - drawSize, center.Y - drawSize, drawSize * 2, drawSize * 2);
        }
        public Tile(int value, PointF center)
        {
            this.value = value;
            this.center = center;
        }
        public void DrawAsActive(Graphics handler, Color Owner)
        {
            DrawBase(handler, Owner, Color.Black, 3);
        }
        public void Draw(Graphics handler)
        {
            handler.DrawLine(Pens.Black, center.X, center.Y, center.X, center.Y - 15);
            handler.DrawLine(Pens.Black, center.X, center.Y, center.X, center.Y + 15);
            handler.DrawLine(Pens.Black, center.X, center.Y, center.X - 15, center.Y);
            handler.DrawLine(Pens.Black, center.X, center.Y, center.X + 15, center.Y);
            switch (value)
            {
                case 1:
                    DrawBase(handler, Color.White, Color.Black, 10); break;
                case 2:
                    DrawBase(handler, Color.Black, Color.Black, 10); break;
            }
        }
    }

    public class Map
    {
        public static Random random = new Random();
        public Tile[,] tiles;
        public bool[,] visited;
        public bool f1, f2;
        public int nr, t1, t2;
        List<Tile> ter1;
        List<Tile> ter2;
        List<Tile> crt;
        public Map(int rows, int columns)
        {
            tiles = new Tile[rows, columns];
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for(int j = 0; j < tiles.GetLength(1); j++)
                {
                    tiles[i, j] = new Tile(random.Next(3),new PointF(j * 30, i * 30));
                }
            }
        }
        public void DFS_utils(int i, int j)
        {
            if (i >= 0 && j >= 0 && i < tiles.GetLength(0) && j < tiles.GetLength(1) && !visited[i,j])
            {
                if (tiles[i, j].value == 0)
                {
                    nr++;
                    crt.Add(tiles[i, j]);
                    visited[i, j] = true;
                    DFS_utils(i - 1, j);
                    DFS_utils(i, j + 1);
                    DFS_utils(i + 1, j);
                    DFS_utils(i, j - 1);
                }
                else
                {
                    if (tiles[i, j].value == 1) f1 = true;
                    if (tiles[i, j].value == 2) f2 = true;
                }
            }
        }
        public void DFS()
        {
            t1 = 0; t2 = 0;
            ter1 = new List<Tile>();
            ter2 = new List<Tile>();
            crt = new List<Tile>();
            visited = new bool[tiles.GetLength(0) , tiles.GetLength(1)];
            for(int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (tiles[i,j].value == 0 && !visited[i,j])
                    {
                        nr = 0; 
                        crt.Clear();
                        f1 = false;
                        f2 = false;
                        DFS_utils(i, j);
                        if (f1 && !f2) 
                        { 
                            t1 += nr;
                            foreach(Tile tile in crt)
                            {
                                ter1.Add(tile);
                            }
                        }
                        if (!f1 && f2) 
                        { 
                            t2 += nr;
                            foreach(Tile tile in crt)
                            {
                                ter2.Add(tile);
                            }
                        }
                    }
                }
            }
        }
        public Map(string filename)
        {
            TextReader load = new StreamReader(filename);
            List<string> data = new List<string>();
            string buffer;
            while((buffer = load.ReadLine()) != null)
            {
                data.Add(buffer);
            }
            load.Close();

            int rows = data.Count;
            int columns = data[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
            tiles = new Tile[rows,columns];

            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                string[] local = data[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    tiles[i, j] = new Tile(int.Parse(local[j]),new PointF(j * 30, i * 30));
                }
            }
        }
        public void Draw(Graphics handler)
        {
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    tiles[i, j].Draw(handler);
                }
            }

            foreach(Tile tile in ter1)
            {
                tile.DrawAsActive(handler, Color.White);
            }
            foreach(Tile tile in ter2)
            {
                tile.DrawAsActive(handler, Color.Black);
            }
        }
    }
}

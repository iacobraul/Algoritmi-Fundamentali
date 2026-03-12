
TextReader load = new StreamReader(@"..\..\unice.in");
TextWriter save = new StreamWriter(@"..\..\unice.out");
int n = int.Parse(load.ReadLine());
int[] v = new int[100];

string buffer;
while((buffer = load.ReadLine()) != null)
{
    string[] local = buffer.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
    foreach(string str in local)
    {
        int t = int.Parse(str);
        v[t]++;
    }
}

for(int i = 0; i < 100; i++)
{
    if(v[i] == 1)
    {
        save.Write(i + " ");
    }
}
save.Close();

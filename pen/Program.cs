using System;

namespace pen
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Enumerator t = new Enumerator("input.txt");
                t.First();
                while (!t.End())
                {
                    if (t.Current().total > 70)
                    {
                        Console.WriteLine($"{t.Current().brand}");
                    }
                    t.Next();
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File not Found!");
            }
        }
    }
}

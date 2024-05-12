using System;
namespace easiestSemester
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Enumerator t = new Enumerator("input.txt");

                t.First();
                string minSemester = t.Current().semester;
                int minHours = t.Current().total;
                t.Next();
                while (!t.End())
                {
                    if (t.Current().total < minHours)
                    {
                        minSemester = t.Current().semester;
                        minHours = t.Current().total;
                    }
                    t.Next();
                }
                Console.WriteLine(minSemester);
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File not Found!");
            }
        }
    }
}

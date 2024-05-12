using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace pen
{
    public struct Pen
    {
        public string name;
        public string colour;
        public int amount;
    }
    public struct Custom
    {
        public string brand;
        public int total;
    }
    public enum Status
    {
        norm, abnorm
    }

    internal class Enumerator
    {
       
        private TextFileReader x;
        private Pen dx;
        Status sx;
        Custom curr;
        bool end;
        public Enumerator(string name)
        {
            x = new TextFileReader(name);
        }
        public void Read() 
        {
            if(!(x.ReadString(out dx.name) && x.ReadString(out dx.colour) && x.ReadInt(out dx.amount)))
            {
                sx = Status.abnorm;
            }
            else
            {
                sx = Status.norm;
            }
        }
        public void First()
        {
            Read();
            Next();
        }
        public Custom Current()
        {
            return curr;
        }
        public bool End()
        {
            return end;
        }
        public void Next()
        {
            end = (sx == Status.abnorm);
            if (!end)
            {
                curr.brand = dx.name;
                curr.total = 0;
                while (curr.brand == dx.name)
                {
                    curr.total += dx.amount;
                    Read();
                }
            }
        }
    }
}

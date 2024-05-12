using System;
using TextFile;
namespace easiestSemester
{
    public enum Status
    {
        norm, abnorm
    }
    public struct Database
    {
        public string semester;
        public string neptun;
        public int th;
    }
    public struct Custom
    {
        public string semester;
        public int total;
    }

    internal class Enumerator
    {
        private TextFileReader _x;
        private Database _dx;
        private Status _sx;
        private Custom _current;
        private bool _end;


        public Enumerator(string name)
        {
            _x = new TextFileReader(name);
        }
        void Read()
        {
            if (!(_x.ReadString(out _dx.semester) && _x.ReadString(out _dx.neptun) && _x.ReadInt(out _dx.th)))
            {
                _sx = Status.abnorm;
            }
            else
            {
                _sx = Status.norm;
            }
        }
        public Custom Current()
        {
            return _current;
        }
        public bool End()
        {
            return _end;
        }
        public void First() {
            Read();
            Next();
        }
        public void Next()
        {
            _end = (_sx == Status.abnorm);
            if (!_end)
            {
                _current.semester = _dx.semester;
                _current.total = _dx.th;
                Read();
                while (_sx == Status.norm && _dx.semester == _current.semester)
                {
                    _current.total += _dx.th;
                    Read();
                }
            }
        }

    }
}

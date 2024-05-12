using System;
using System.Collections.Generic;
using System.IO;
using TextFile;

namespace matrix
{
    public class LTMatrix
    {
        public class InvalidIndexException : Exception { };
        public class OutOfTriangleException : Exception { };
        public class DimensionMismatchException : Exception { };
        public class InvalidVectorException : Exception { };

        public List<int> _vec;
        private int _size;

        public int ind(int i, int j)
        {
            return (j + i * (i - 1) / 2) - 1;
        }
        private double calcSizeFromLength(int length)
        {
            return (-1 + Math.Sqrt(1 + 8 * length)) / 2;
        }
        private bool inLowerTrngle(int i, int j)
        {
            return (j <= i && 1 <= j && i <= _size);
        }
        //constructors
        public LTMatrix() //basic 3x3 matrix
        {
            _vec = new List<int>() { 1, 2, 3, 4, 5, 6 };
            _size = 3;
        }
        public LTMatrix (in List<int> vec) //matrix with given vector
        {
            SetVec(vec);
        }
        public LTMatrix(int size) //zero matrix with given size
        {
            _size = size;
            _vec = new List<int>();
            int length = (size * (size + 1)) / 2;
            for (int i=0; i<length; i++)
            {
                _vec.Add(0);
            }
        }
        public LTMatrix(in String fileName) //read from file
        {
            try
            {
                _vec = new List<int>();
                TextFileReader f = new TextFileReader(fileName);
                while(f.ReadInt(out int e))
                {
                    _vec.Add(e);
                }
                double calcSize = calcSizeFromLength(_vec.Count);
                if (calcSize == Math.Floor(calcSize)) //check if calcSize is integer
                {
                    _size = Convert.ToInt32(calcSize);
                }
                else
                {
                    _size = 0;
                    _vec.Clear();
                    throw new InvalidVectorException();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Something wrong with the file :" + fileName);
                _size = 0;
                _vec.Clear();
            }
        }
        public LTMatrix(in LTMatrix m) //copying matrix
        {
            _size = m._size;
            _vec = m._vec;
        }
        //Getters
        public int GetSize()
        {
            return _size;
        }
        public int GetElement(int i, int j) //get matrix element by indices
        {
            if (inLowerTrngle(i, j)) //in the lower triangle
            {
                return _vec[ind(i, j)];
            }
            else if(1<=j &&j<=_size && i<=_size) //other valid indices
            {
                return 0;
            }
            else
            {
                throw new InvalidIndexException();
            }
        }
        //Setter
        public void SetVec(in List<int> vec)
        {
            double calcSize = calcSizeFromLength(_vec.Count);
            if (calcSize == Math.Floor(calcSize))
            {
                _size = Convert.ToInt32(calcSize);
                _vec = vec;
            }
            else
            {
                throw new InvalidVectorException();
            }
        }
        void SetElement(int i, int j, int e)
        {
            if (inLowerTrngle(i, j))
            {
                _vec[ind(i, j)] = e; //vector indexing starts at 0
            }
            else
            {
                throw new OutOfTriangleException();
            }
        }
        //static methods
        public static LTMatrix Add(in LTMatrix a, in LTMatrix b)
        {
            if(a.GetSize() == b.GetSize())
            {
                LTMatrix sum = new LTMatrix(a);
                for (int i = 0; i<a._vec.Count; i++)
                {
                    sum._vec[i] += b._vec[i];
                }
                return sum;
            }
            else
            {
                throw new DimensionMismatchException();
            }
        }
        public static LTMatrix Multiply(in LTMatrix a, in LTMatrix b)
        {
            if (a.GetSize() == b.GetSize())
            {
                LTMatrix mul = new LTMatrix(a.GetSize());
                for (int i=1; i<=a._size; i++)
                {
                    for(int j=1; j<=a._size; j++)
                    {
                        if (a.inLowerTrngle(i, j)) //only the lower triangle needs calculation
                        {
                            for(int k = j; k<=i; k++)
                            {
                                mul.SetElement(i,j, mul.GetElement(i,j) + a.GetElement(i,k) * b.GetElement(k,j));
                            }
                        }
                    }
                }
                return mul;
            }
            else
            {
                throw new DimensionMismatchException();
            }
        }

        public override string ToString()
        {
            String str = "";
            str += _size + "x" + _size+"\n";
            for (int i =1; i<=_size; i++)
            {
                for (int j=1; j<=_size; j++)
                {
                    str += GetElement(i, j) + " ";
                }
                str += "\n";
            }
            return str;
        }
    }
}

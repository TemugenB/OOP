using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class Nmat
    {
        #region Exceptions
        public class InvalidSizeException : Exception { };
        public class InvalidVectorException : Exception { };
        public class InvalidIndexException : Exception { };
        public class InvalidElementException : Exception { };
        #endregion

        #region Attributes
        private List<int> _vec = new List<int>();
        private int _size;
        #endregion

        #region Helpers
        public int Index(int i, int j) //starts from 0
        {
            if (i == j)
            {
                return (i - 1) * 3;
            }
            else if (j == 1)
            {
                return (i - 1) * 3 - 1;
            }
            else
            {
                return (i - 1) * 3 + 1;
            }
        }
        private double CalcSizeFromLength(int length)
        {
            return (double)((length + 2)/ 3.0);
        }
        private bool InN(int i, int j)
        {
            return (i<=_size && j<=_size && i >0 && j>0 && (i == j || j == 1 || j==_size)); 
        }
        #endregion

        #region Constructors
        public Nmat() //basic 3x3 matrix
        {
            _size = 3;
            _vec = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
        }
        public Nmat(int size) // 0 matrix from the size
        {
            if (size <= 0) throw new InvalidSizeException();
            else
            {
                _size = size;
                int length = 3 * size - 2;
                for (int i = 0; i < length; ++i)
                {
                    _vec.Add(0);
                }
            }
        }
        public Nmat(in List<int> vec) // matrix from vector
        {
            SetVector(vec);
        }
        public Nmat(in Nmat a) //copying matrix
        {
            _size = a._size;
            _vec = a._vec;
        }

        #endregion

        #region Getters and Setters
        public int GetSize()
        {
            return _size;
        }
        public int GetEntry(int i, int j)
        {
            if (InN(i, j))
            {
                return _vec[Index(i, j)];
            }
            else if (1 <= j && j <= _size && 1 <= i && i <= _size)
            {
                return 0;
            }
            else
            {
                throw new InvalidIndexException();
            }
        }
        public void SetVector(in List<int> vec)
        {
            double calcSize = CalcSizeFromLength(vec.Count);
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
        void SetEntry(int i, int j, int el)
        {
            if (InN(i, j))
            {
                _vec[Index(i, j)] = el;
            }
            else
            {
                throw new InvalidIndexException();
            }
        }
        #endregion

        #region Static Methods
        public static Nmat Addition(in Nmat a, in Nmat b)
        {
            if (a.GetSize() == b.GetSize())
            {
                Nmat sum = new Nmat(a._size);
                for (int i = 0; i < a._vec.Count; i++)
                {
                    sum._vec[i] = a._vec[i] + b._vec[i];
                }
                return sum;
            }
            else
            {
                throw new InvalidSizeException();
            }
        }

        public static Nmat Multiplication(in Nmat a, in Nmat b)
        {
            if (a._size == b._size)
            {
                Nmat prod = new Nmat(a._size);
                for (int i = 1; i <= a._size; i++)
                {
                    for (int j = 1; j <= a._size; j++)
                    {
                        int sum = 0;
                        for (int k = 1; k <= a._size; k++)
                        {
                            sum += a.GetEntry(i, k) * b.GetEntry(k, j);
                        }
                        if (prod.InN(i, j))
                        {
                            prod.SetEntry(i, j, sum);
                        }
                    }
                }
                return prod;
            }
            else
            {
                throw new InvalidSizeException();
            }
        }

        public override String ToString()
        {
            String str = "";
            str += "[" + _size + " x " + _size + "]" + "\n";
            for (int i = 1; i <= _size; i++)
            {
                for (int j = 1; j <= _size; j++)
                {
                    str += GetEntry(i, j) + " ";
                }
                str += "\n";
            }
            return str;
        }
        #endregion
    }
}


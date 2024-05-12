using System;
using System.Collections.Generic;

namespace task3
{
    class Menu
    {
        private List<Nmat> mat = new List<Nmat>();
        private static int GetMenuEntry()
        {
            int v;
            Console.WriteLine("\n-------------------------------------");
            Console.WriteLine("0. - quit");
            Console.WriteLine("1. - get the element");
            Console.WriteLine("2. - set the matrix");
            Console.WriteLine("3. - print the matrix");
            Console.WriteLine("4. - add matrices");
            Console.WriteLine("5. - multiply matrices");
            Console.WriteLine("\n-------------------------------------");
            try
            {
                v = Convert.ToInt32(Console.ReadLine()!);
            }
            catch (System.FormatException) { v = -1; }
            return v;
        }
        public Menu() { }
        public void Run()
        {
            int userChoice;
            do
            {
                userChoice = GetMenuEntry();
                switch (userChoice){
                    case 1:
                        GetEntry();
                        break;
                    case 2:
                        SetMatrix();
                        break;
                    case 3:
                        PrintMatrix();
                        break;
                    case 4:
                        Add();
                        break;
                    case 5:
                        Multiply();
                        break;
                }
            }
            while (userChoice != 0);
        }
        private int Index()
        {
            if (mat.Count == 0)
            {
                return -1;
            }
            int userIndex;
            while (true)
            {
                try
                {
                    Console.Write("Please enter index of the matrix: ");
                    userIndex = Convert.ToInt32(Console.ReadLine()!);
                    if (userIndex <= 0 || userIndex > mat.Count)
                    {
                        throw new Nmat.InvalidIndexException();
                    }
                    break;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter valid index");
                }
                catch (Nmat.InvalidIndexException)
                {
                    Console.WriteLine("Invalid input. Please enter valid index");
                }
            }
            return userIndex - 1;
        }
        private void GetEntry()
        {
            if (mat.Count == 0)
                {
                    Console.WriteLine("Please set matrix!");
                    return;
                }
            int index = Index();
            while (true)
            {
                try
                {
                    Console.Write("Please enter row number: ");
                    int userRow = Convert.ToInt32(Console.ReadLine()!);
                    Console.Write("Please enter column number: ");
                    int userColumn = Convert.ToInt32(Console.ReadLine()!);
                    if (userRow > mat[index].GetSize() || userColumn > mat[index].GetSize() || userRow <=0 || userColumn <= 0)
                    {
                        throw new Nmat.InvalidIndexException();
                    }
                    Console.WriteLine($"matrix[{userRow}, {userColumn}] is {mat[index].GetEntry(userRow, userColumn)}");
                    break;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine($"Invalid input. Please enter number between 1 and {mat[index].GetSize()}");
                }
                catch (Nmat.InvalidIndexException)
                {
                    Console.WriteLine($"Invalid input. Please enter number between 1 and {mat[index].GetSize()}");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"Invalid input. Please enter number between 1 and {mat[index].GetSize()}");
                }
            }
        }
        private void SetMatrix()
        {
            int ind = mat.Count;
            int userSize;
            while (true)
            {
                try
                {
                    Console.Write("Please enter size of the matrix: ");
                    userSize = Convert.ToInt32(Console.ReadLine()!);
                    if (userSize <= 0)
                    {
                        throw new Nmat.InvalidSizeException();
                    }
                    break;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter positive integer");
                }
                catch (Nmat.InvalidSizeException)
                {
                    Console.WriteLine("Invalid input. Please enter positive integer");
                }
            }
            List<int> matrixElements = new List<int>();
            bool helper = true;
            int length = 3 * userSize - 2;
            for (int i = 0; i < length; i++)
            {
                Console.Write("Enter the element of the matrix: ");
                try
                {
                    int userElement = Convert.ToInt32(Console.ReadLine()!);
                    if(userElement == 0)
                    {
                        throw new Nmat.InvalidElementException();
                    }
                    matrixElements.Add(userElement);
                }
                    catch (System.FormatException)
                    {
                    Console.WriteLine("Invalid input. Please enter integer");
                    helper = false;
                    break;
                    }
                catch (Nmat.InvalidElementException)
                {
                    Console.WriteLine("Invalid input. Element can not be zero");
                    helper = false;
                    break;
                }
            }
            if (helper)
            {
                Nmat a = new Nmat(matrixElements);
                mat.Add(a);
            }
        }

        private void PrintMatrix()
        {
            if (mat.Count == 0)
            {
                Console.WriteLine("Please set matrix!");
                return;
            }
            int index = Index();
            Console.WriteLine($"{mat[index]}");
        }

        private void Add()
        {
            if (mat.Count < 2)
            {
                Console.WriteLine("Set at least 2 matrices!");
                return;
            }
            Console.WriteLine("Choose 1st matrix: ");
            int index1 = Index();
            Console.WriteLine("Choose 2nd matrix: ");
            int index2 = Index();
            try
            {
                Console.WriteLine($"{Nmat.Addition(mat[index1], mat[index2])}");
            }
            catch (Nmat.InvalidSizeException)
            {
                Console.WriteLine("The 2 matrices must have same size!");
                return;
            }
        }
        private void Multiply()
        {
            if (mat.Count < 2)
            {
                Console.WriteLine("Set at least 2 matrices!");
                return;
            }
            Console.WriteLine("Choose 1st matrix: ");
            int index1 = Index();
            Console.WriteLine("Choose 2nd matrix: ");
            int index2 = Index();
            try
            {
                Console.WriteLine($"{Nmat.Multiplication(mat[index1], mat[index2])}");
            }
            catch (Nmat.InvalidSizeException)
            {
                Console.WriteLine("The 2 matrices must have same size!");
            }
        }
    }
}
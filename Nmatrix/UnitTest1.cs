using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using task3;


namespace TestNmat
{
    [TestClass]
    public class TestNmat
    {
        [TestMethod]
        public void TestConstructor()
        {
            Assert.ThrowsException<Nmat.InvalidSizeException>(() => _ = new Nmat(-1));
            Assert.ThrowsException<Nmat.InvalidSizeException>(() => _ = new Nmat(0));
            Nmat a = new Nmat();
            Assert.AreEqual(3, a.GetSize());
            Nmat b = new Nmat(3);
            Assert.AreEqual(3, b.GetSize());
            Nmat c = new Nmat(7); 
            Assert.AreEqual(7, c.GetSize());
            Nmat d = new Nmat(100);
            Assert.AreEqual(100, d.GetSize());
        }
        [TestMethod]
        public void TestSet()
        {
            List<int> vec = new List<int>() { 1, 2, 3, 4, 5, 6, 7};
            Nmat a = new Nmat(3);

            Assert.AreEqual(a.GetEntry(1, 1), 0);
            Assert.AreEqual(a.GetEntry(1, 2), 0);
            Assert.AreEqual(a.GetEntry(1, 3), 0);
            Assert.AreEqual(a.GetEntry(2, 1), 0);
            Assert.AreEqual(a.GetEntry(2, 2), 0);
            Assert.AreEqual(a.GetEntry(2, 3), 0);
            Assert.AreEqual(a.GetEntry(3, 1), 0);
            Assert.AreEqual(a.GetEntry(3, 2), 0);
            Assert.AreEqual(a.GetEntry(3, 3), 0);
            a.SetVector(vec);
            Assert.AreEqual(a.GetEntry(1, 1), 1);
            Assert.AreEqual(a.GetEntry(1, 2), 0);
            Assert.AreEqual(a.GetEntry(1, 3), 2);
            Assert.AreEqual(a.GetEntry(2, 1), 3);
            Assert.AreEqual(a.GetEntry(2, 2), 4);
            Assert.AreEqual(a.GetEntry(2, 3), 5);
            Assert.AreEqual(a.GetEntry(3, 1), 6);
            Assert.AreEqual(a.GetEntry(3, 2), 0);
            Assert.AreEqual(a.GetEntry(3, 3), 7);
            List<int> invalidVec = new List<int>() { 1, 2, 3 };
            Assert.ThrowsException<Nmat.InvalidVectorException>(() => _ = new Nmat(invalidVec));
        }
        [TestMethod]
        public void TestGet()
        {
            List<int> vec = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            Nmat a = new Nmat(3);
            a.SetVector(vec);
            Assert.AreEqual(a.GetEntry(2, 3), 5);
            Assert.AreEqual(a.GetEntry(3, 1), 6);
            Assert.AreEqual(a.GetEntry(3, 2), 0);
            Assert.ThrowsException<Nmat.InvalidIndexException>(() => _ = a.GetEntry(0, 3));
        }
        [TestMethod]
        public void TestAddition()
        {
            Nmat a = new Nmat(2);
            Nmat b = new Nmat(3);
            Nmat c = new Nmat(3);
            List<int> vecA = new List<int>() { 1, 2, 3, 4 };
            List<int> vecB = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            List<int> vecC = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            a.SetVector(vecA);
            b.SetVector(vecB);
            c.SetVector(vecC);
            Assert.ThrowsException<Nmat.InvalidSizeException>(() => _ = Nmat.Addition(a, b));
            Nmat d = Nmat.Addition(b, c);
            Nmat e = Nmat.Addition(c, b);
            Assert.AreEqual(d.GetEntry(1, 1), 2);
            Assert.AreEqual(e.GetEntry(1, 1), 2);
            Nmat zero = new Nmat(3);
            Assert.AreNotEqual(zero.GetEntry(2, 1), (Nmat.Addition(b, zero)).GetEntry(2, 1));
        }
        [TestMethod]
        public void TestMultiplication()
        {
            Nmat a = new Nmat(2);
            Nmat b = new Nmat(3);
            Nmat c = new Nmat(3);
            List<int> vecA = new List<int>() { 1, 2, 3, 4 };
            List<int> vecB = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            List<int> vecC = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            a.SetVector(vecA);
            b.SetVector(vecB);
            c.SetVector(vecC);
            Assert.ThrowsException<Nmat.InvalidSizeException>(() => _ = Nmat.Multiplication(a, b));
            Nmat d = Nmat.Multiplication(b, c);
            Nmat e = Nmat.Multiplication(c, b);
            Assert.AreEqual(d.GetEntry(2, 1), 45);
            Assert.AreEqual(e.GetEntry(2, 1), 45);
            Nmat zero = new Nmat(3);
            Assert.AreEqual(zero.GetEntry(2, 1), (Nmat.Multiplication(b, zero)).GetEntry(2, 1));
        }
    }
}

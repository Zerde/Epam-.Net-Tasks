using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicCoding;

namespace BasicCodingMSTest.Tests
{
    [TestClass]
    public class BasicCodingMSTest
    {
        
        [DataTestMethod]
        [DataRow(15, 15, 0, 0, 15)]
        [DataRow(8, 15, 0, 0, 9)]
        [DataRow(8, 15, 3, 8, 120)]
        public void CheckInsertNumber(int numSource, int numIn, int i, int j, int expected)
        {
            var actual = Program.InsertNumber(numSource, numIn, i, j);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 7, new int[] { 7, 7, 70, 17 })]
        [DataRow(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 6, new int[] { 6, 68, 69 })]
        [DataRow(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 9, new int[] { 69 })]
        public void CheckFilterDigit(int[] sourceArray, int number, int[] expected)
        {
            int[] actual = Program.FilterDigit(sourceArray, number);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}

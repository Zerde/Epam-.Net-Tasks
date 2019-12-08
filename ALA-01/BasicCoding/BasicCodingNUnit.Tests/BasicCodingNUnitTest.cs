using NUnit.Framework;
using BasicCoding;

namespace BasicCodingNUnit.Tests
{
    [TestFixture]
    public class BasicCodingNUnitTest
    {
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        public int CheckInsertNumber(int numSource, int numIn, int i, int j)
        {
            return Program.InsertNumber(numSource, numIn, i, j);
        }

        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int CheckFindNextBiggerNumber(int number)
        {
            int result;
            double time;
            Program.FindNextBiggerNumber(number, out result, out time);
            return result;
        }

        [TestCase(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 7, ExpectedResult = new int[] { 7, 7, 70, 17 })]
        [TestCase(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, -69, 70, 15, 17 }, 6, ExpectedResult = new int[] { 6, 68, -69 })]
        [TestCase(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 9, ExpectedResult = new int[] { 69 })]
        public int[] CheckFilterDigit(int[] sourceArray, int number)
        {
            return Program.FilterDigit(sourceArray, number);
        }
    }
}
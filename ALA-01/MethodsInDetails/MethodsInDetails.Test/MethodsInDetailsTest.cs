using NUnit.Framework;
using MethodsInDetails;

namespace MethodsInDetails.Test
{
    [TestFixture]
    public class MethodsInDetailTests
    {
        [TestCase(24, 18, ExpectedResult = 6)]
        [TestCase(1071, 462, ExpectedResult = 21)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        [TestCase(0, 8, ExpectedResult = 8)]
        public int CheckGCDEuclid(int a, int b)
        {
            return CalcGCD.GCDEuclid(a, b);
        }

        [TestCase(new int[] {1071, 462, 49, 35}, ExpectedResult = 7)]
        [TestCase(new int[] { 1024, 48, 256, 32 }, ExpectedResult = 16)]
        public int CheckGCDEuclidMultiple(int[] a)
        {
            return CalcGCD.GCDEuclid(a);
        }

        [TestCase(24, 18, ExpectedResult = 6)]
        [TestCase(1071, 462, ExpectedResult = 21)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        [TestCase(0, 8, ExpectedResult = 8)]
        [TestCase(0, 0, ExpectedResult = 0)]
        public int CheckGCDBinary(int a, int b)
        {
            return CalcGCD.GCDBinary(a, b);
        }

        [TestCase(new int[] { 1071, 462, 49, 35 }, ExpectedResult = 7)]
        [TestCase(new int[] { 1024, 48, 256, 32 }, ExpectedResult = 16)]
        public int CheckGCDBinaryMultiple(int[] a)
        {
            return CalcGCD.GCDBinary(a);
        }
    }
}
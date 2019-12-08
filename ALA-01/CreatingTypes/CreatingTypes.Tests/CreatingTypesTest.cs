using NUnit.Framework;
using CreatingTypes;
using System;

namespace CreatingTypes.Tests
{
    [TestFixture]
    public class CreatingTypeTest
    {
        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(0.008, 3, 0.1, ExpectedResult = 0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double CheckFindNthRoot(double number, int degree, double precision)
        {
            return Math.Round(Program.FindNthRoot(number, degree, precision), precision.ToString().Length - 2);
        }

        [TestCase(-0.01, 2, 0.00001)]
        [TestCase(0.01, -2, 0.00001)]
        public void FindNthRoot_ArgumentException(double number, int degree, double precision)
        {
            Assert.Throws<ArgumentException>(() => Program.FindNthRoot(number, degree, precision));
        }

        [TestCase(0.01, 2, 11)]
        public void FindNthRoot_ArgumentOutOfRangeException(double number, int degree, double precision)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Program.FindNthRoot(number, degree, precision));
        }

    }
}
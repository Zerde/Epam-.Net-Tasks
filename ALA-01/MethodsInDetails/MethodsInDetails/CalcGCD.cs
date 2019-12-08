using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MethodsInDetails
{
    //class containing methods to calculate GCD 
    public class CalcGCD
    {
        #region GCDEuclid
        /// <summary>
        /// Euclid's algorithm to find GCD of two numbers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>GCD of a and b</returns>
        public static int GCDEuclid(int a, int b)
        {
            if (b == 0)
                return Math.Abs(a);
            else
                return GCDEuclid(b, a % b);
        }

        /// <summary>
        /// Euclid's algorithm to find GCD of multiple numbers
        /// </summary>
        /// <param name="a">array of numbers</param>
        /// <returns>GCD</returns>
        public static int GCDEuclid(params int[] a)
        {
            if (a == null)
            {
                throw new ArgumentNullException($"params can not be null.");
            }
            if (a.Length < 2)
            {
                throw new ArgumentException($"The length of param must be more than two.");
            }

            int tempGCD = GCDEuclid(a[0], a[1]);
            int index = 2;
            while (index < a.Length)
            {
                tempGCD = GCDEuclid(tempGCD, a[index]);
                index++;
            }

            return tempGCD;
        }

        /// <summary>
        /// Euclid's algorithm to find GCD of multiple numbers with calculation time
        /// </summary>
        /// <param name="calcTime"></param>
        /// <param name="a"></param>
        /// <returns>GCD and calulation time</returns>
        public static int GCDEuclid(out double calcTime, params int[] a)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int result = GCDEuclid(a);
            stopwatch.Stop();
            calcTime = stopwatch.Elapsed.TotalMilliseconds;
            return result;
        }
        #endregion 

        #region GCDBinary
        /// <summary>
        /// Finds GCD of two numbers using binary method
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>GCD</returns>
        public static int GCDBinary(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == b)
                return a;
            if (a == 0 || b == 0)
                return a == 0 ? b : a;
            if (a % 2 == 0)
            {
                if (b % 2 == 0)
                    return 2 * GCDBinary(a / 2, b / 2);
                else
                    return GCDBinary(a / 2, b);
            }
            else
            {
                if (b % 2 == 0)
                    return GCDBinary(a, b / 2);
                else
                {
                    if (a > b)
                        return GCDBinary((a - b) / 2, b);
                    else
                        return GCDBinary((b - a) / 2, a);
                }
            }
        }

        /// <summary>
        /// Finds GCD of multiple numbers using binary method
        /// </summary>
        /// <param name="a">array of numbers</param>
        /// <returns>GCD</returns>
        public static int GCDBinary(params int[] a)
        {
            if (a == null)
            {
                throw new ArgumentNullException($"params can not be null.");
            }
            if (a.Length < 2)
            {
                throw new ArgumentException($"The length of param must be more than two.");
            }

            int tempGCD = GCDBinary(a[0], a[1]);
            int index = 2;
            while (index < a.Length)
            {
                tempGCD = GCDBinary(tempGCD, a[index]);
                index++;
            }

            return tempGCD;
        }

        /// <summary>
        /// Finds GCD of multiple numbers using binary method, also returns calculation time
        /// </summary>
        /// <param name="calcTime"></param>
        /// <param name="a"></param>
        /// <returns>GCD and calulation time</returns>
        public static int GCDBinary(out double calcTime, params int[] a)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int result = GCDBinary(a);
            stopwatch.Stop();
            calcTime = stopwatch.Elapsed.TotalMilliseconds;
            return result;
        }
        #endregion
    }
}

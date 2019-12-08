using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BasicCoding
{
    
    public class Program
    {
        static void Main(string[] args)
        {
            //InsertNumber
            Console.WriteLine(InsertNumber(8, 15, 0, 0));
            //FindMaxElement
            int[] a = { 5, 4, -9, 11, 0};
            Console.WriteLine(FindMaxElement(a));
            //LeftRightEqualSum
            decimal[] d = { 0.7M, 0.3M, 0.2M, 1.0M , 1.2M };
            Console.WriteLine(LeftRightEqualSum(d));
            //ConcatStrings
            Console.WriteLine(ConcatStrings("Good", "afternoon"));
            //FindNextBiggerNumber
            int nextNumber;
            double calcTime;
            FindNextBiggerNumber(3456432, out nextNumber, out calcTime);
            Console.WriteLine("Next bigger number is {0}, calculation time is {1} ms", nextNumber, calcTime);
            //FilterDigit
            int[] x = { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17};
            Console.WriteLine("[{0}]", string.Join(", ", FilterDigit(x, 7)));
           
        }

        #region InsertNumber
        /// <summary>
        /// Inserts bits from the j-th to the i-th bit of one number to another
        /// so that the bits of the second number take positions from bit j to bit i,
        /// returning resulted number
        /// </summary>
        /// <param name="numSource"></param>
        /// <param name="numIn"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns>changed number</returns>
        public static int InsertNumber(int numSource, int numIn, int i, int j)
        {
            if (i > j)
                throw new ArgumentException("i cannot be bigger than j", "i");
            if (i > 31 || j > 31)
                throw new ArgumentException("i and j cannot be bigger than 31", "");

            // Converting numbers to bit arrays of char
            char[] numSourceArray = Convert.ToString(numSource, 2).PadLeft(32, '0').ToCharArray();
            char[] numInArray = Convert.ToString(numIn, 2).PadLeft(32, '0').ToCharArray();
            // Reversing the arrays
            Array.Reverse(numSourceArray);
            Array.Reverse(numInArray);

            // Inserting second number to first from i to j
            for (int count = 0; i <= j; i++, count++)
            {
                numSourceArray[i] = numInArray[count];
            }
            Array.Reverse(numSourceArray);

            // return int value
            return Convert.ToInt32(new string(numSourceArray), 2);    
        }
        #endregion

        #region FindMaxElement
        /// <summary>
        /// Finds and returns maximum element in given array, uses recursion
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int FindMaxElement(int [] arr, int count = 0)
        {
            if (arr.Length == 0 || arr == null)
                throw new ArgumentException("array can't be empty or null", "a");
            // traveled through the whole array if count is equal to last element index
            if (count == arr.Length - 1)
                return arr[count];
            else
                return Math.Max(arr[count], FindMaxElement(arr, count + 1));
        }
        #endregion

        #region LeftRightEqualSum
        /// <summary>
        /// Returns index of the element if sum of the elements on the left and
        /// the sum of the elements on the right are equal. Otherwise returns -1
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int LeftRightEqualSum(decimal [] arr)
        {
            decimal sum = 0, left = 0 , right = 0;
            //calculating the total sum
            foreach (decimal element in arr)
                sum += element;
            // for each element calculate left and right sums
            for(int i = 0; i < arr.Length; i++)
            {
                right = sum - arr[i];
                if (left == right)
                    return i;
                left += arr[i];
                sum -= arr[i];
            }
            return -1;
        }
        #endregion

        #region ConcatStrings
        /// <summary>
        /// Adds to string removing duplicated characters
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static string ConcatStrings(string s1, string s2)
        {
            string concat = s1 + s2;
            string res = "";
            for (int i = 0; i < concat.Length; i++)
                if (!res.Contains(concat[i]))
                    res += concat[i];
            return res;
        }
        #endregion

        #region FindNextBiggerNumber
        /// <summary>
        /// Finds next biggest number with same digits
        /// </summary>
        /// <param name="number"></param>
        /// <param name="nextBigger"></param>
        /// <param name="calcTime"></param>
        public static void FindNextBiggerNumber(int number, out int nextBigger, out double calcTime)
        {
            //stopwatch to calculate compute time
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            char[] arr = number.ToString().ToCharArray();
            int n = arr.Length;
            
            //starting from right find first digit that is smaller than its neighbour
            int i = n-1;
            while(i > 0)
            {
                if (arr[i - 1] < arr[i])
                    break;
                i--;
            }
            // if such digit exists
            if (i != 0)
            {
                //find the smallest digits on the right of arr[i-1] and is bigger than it
                int minDigit = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] > arr[i - 1] && arr[j] < arr[minDigit])
                        minDigit = j;
                }

                //swapping found digits
                char temp = arr[i - 1];
                arr[i - 1] = arr[minDigit];
                arr[minDigit] = temp;

                //sort digits on the right side
                Array.Sort(arr, i, n - i);

                nextBigger = Convert.ToInt32(new string(arr));
                stopwatch.Stop();
            }
            //if there is no such pair(i==0), it means all digits are in descending order,
            //no bigger number can be found  
            else
            {
                nextBigger = -1;
                stopwatch.Stop();
            }
            calcTime = stopwatch.Elapsed.TotalMilliseconds;
        }
        #endregion

        #region FilterDigit
        /// <summary>
        /// filters array of integers so that only numbers containing the given digit remain on the output array
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int[] FilterDigit(int [] arr, int num)
        {
            List<int> resultList = new List<int>();
            // for each element of array check if contains digit
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].ToString().Contains(num.ToString()))
                    resultList.Add(arr[i]);
            }
            return resultList.ToArray();
        }
        #endregion
    }
}

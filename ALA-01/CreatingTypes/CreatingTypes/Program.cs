using System;

namespace CreatingTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            // FindNthRoot
            Console.WriteLine(FindNthRoot(0.004241979, 9, 0.00000001));
            //BubbleSort
            int[][] a = new int[][]
            {
                new int[] {4,1,2},
                new int[] {3,4,5, -1},
                new int[] {0,7,8,9}
            };
            Matrix matrix = new Matrix(a);
            matrix.print();
            matrix.Sort(SortType.MinValue, SortOrder.Ascending);
            Console.WriteLine("Sorted matrix type: {0}, order: {1}", SortType.MinValue.ToString(), SortOrder.Ascending.ToString() );
            matrix.print();
    
        }

        #region FindNthRoot
        /// <summary>
        /// Finds n-th(degree) root of given number, with given precision using Newton's method
        /// </summary>
        /// <param name="number"></param>
        /// <param name="degree"></param>
        /// <param name="precision"></param>
        /// <returns>root</returns>
        public static double FindNthRoot(double number, int degree, double precision)
        {
            //exceptions
            if (number < 0)
                throw new ArgumentException("number should be greater than zero");
            if (degree <= 0)
                throw new ArgumentException("degree should be greater than zero");
            if (precision >= 1 || precision <= 0)
                throw new ArgumentOutOfRangeException("precision should be a number between 0 and 1");

            double x1 = 2.0;
            double x2,delta;
            do
            {
                x2 = 1.0 / degree * (x1 * (degree - 1) + number / Math.Pow(x1, degree - 1));
                delta = Math.Abs(x2 - x1);
                x1 = x2;
                
            } while (delta  > precision);

            return x2;
        }
        #endregion 
    }

    #region BubbleSortMatrix
    enum SortType { MinValue, MaxValue, Sum}
    enum SortOrder { Ascending, Descending}
    class Matrix
    {
        private int[][] array;
        public Matrix(int[][] a)
        {
            if (a == null)
                throw new ArgumentNullException();
            this.array = a;
        }
        
        /// <summary>
        /// returns minimum value in given array
        /// </summary>
        /// <param name="a">array</param>
        /// <returns>min value</returns>
        int MinValue(int[] a)
        {
            int min = int.MaxValue;
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i] < min)
                    min = a[i];
            }
            return min;
        }

        /// <summary>
        /// returns maximum value in given array
        /// </summary>
        /// <param name="a">array</param>
        /// <returns>maximum value</returns>
        int MaxValue(int[] a)
        {
            int max = int.MinValue;
            for (int i = 0; i < a.Length; i++)
                if (a[i] > max)
                    max = a[i];
            return max;
        }

        /// <summary>
        /// returns sum of vaues of given array
        /// </summary>
        /// <param name="a">array</param>
        /// <returns>sum</returns>
        int Sum(int[] a)
        {
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
                sum += a[i];
            return sum;
        }

        /// <summary>
        /// swaps two arrays
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        void Swap(ref int[] a1, ref int[] a2)
        {
            int[] temp = a1;
            a1 = a2;
            a2 = temp;
        }

        /// <summary>
        /// sorts matrix by given type and order
        /// </summary>
        /// <param name="type"></param>
        /// <param name="order"></param>
        public void Sort(SortType type, SortOrder order)
        {
            int orderIndex = order == SortOrder.Ascending ? 1 : -1;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if ((ComparedValue(array[j], type) - ComparedValue(array[j + 1], type)) * orderIndex > 0)
                        Swap(ref array[j], ref array[j + 1]);
                }
            }
        }

        /// <summary>
        /// returns value to be compared in the array depending on given sort type
        /// </summary>
        /// <param name="a"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        int ComparedValue(int[] a, SortType type)
        {
            switch (type)
            {
                case SortType.MaxValue:
                    return MaxValue(a);
                case SortType.MinValue:
                    return MinValue(a);
                case SortType.Sum:
                    return Sum(a);
                default:
                    return Sum(a);              
            }
        }     
        
        public void print()
        {
            for(int i = 0; i < array.Length ; i++)
            {
                for(int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
    #endregion
}

using System;

namespace MethodsInDetails
{
    class Program
    {
        static void Main(string[] args)
        {
            //GCD
            double time;
            Console.WriteLine(CalcGCD.GCDEuclid(out time, new int[] { 462, 1071, 21, 9 }));
            Console.WriteLine($"calc time is {time} milliseconds");
            Console.WriteLine(CalcGCD.GCDBinary(1071, 462));
            //IsNull
            int? a = 123;
            //int x = 0;
            string b = null;
            Console.WriteLine(a.IsNull());
            // Console.WriteLine(x.IsNull()); Error
            Console.WriteLine(b.IsNull());
        }
    }
}

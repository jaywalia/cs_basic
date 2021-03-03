using System;
using System.Numerics;

namespace Step03
{
    public class SmartCalculator
    {
        public static void RunDiagnostics()
        {
            AddLargeNumbers();
        }

        public static void AddLargeNumbers()
        {
            BigInteger x32 = new BigInteger(UInt32.MaxValue);
            int y = 1;
            var z = x32 + y;
            var zz = y + x32;
            Console.WriteLine($"UInt32.MaxValue: {UInt32.MaxValue} |||| z: {z}");
            Console.WriteLine($"z.GetType(): {z.GetType()}");
            Console.WriteLine($"zz.GetType(): {zz.GetType()}");

            BigInteger x64 = new BigInteger(UInt64.MaxValue);
            z = x64 + y;
            Console.WriteLine($"UInt64.MaxValue: {UInt64.MaxValue} |||| z: {z}");
        }
    }
}
using System;

namespace Step01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RunCalculatorTests();
        }

        static void RunCalculatorTests()
        {
            Console.WriteLine(Calculator.add(2,3));
            Console.WriteLine(Calculator.sub(2,3));
            Console.WriteLine(Calculator.mul(2,3));
            Console.WriteLine(Calculator.div(2,3));
            Console.WriteLine(Calculator.div(2,0));
        }


    }

    class Calculator
    {
        internal static int add(int x, int y) => x + y;
        internal static int sub(int x, int y) => x - y;
        internal static int mul(int x, int y) => x * y;
        internal static int div(int x, int y)
        {
            if (y == 0) throw new DivideByZeroException();
            return x/y;
        }

    }
}

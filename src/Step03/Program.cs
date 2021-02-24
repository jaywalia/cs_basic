using System;

namespace Step03
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Operator overloading:");
            var a = new Fraction(5, 4);
            var b = new Fraction(1, 2);
            var c = new Fraction(1, 3);
            Console.WriteLine($"a is: {a}, b is: {b}, c is: {c}");   // output: -5 / 4
            Console.WriteLine($"a+b: {a + b}");  // output: 14 / 8
            Console.WriteLine($"a-b: {a - b}");  // output: 6 / 8
            Console.WriteLine($"a*b: {a * b}");  // output: 5 / 8
            Console.WriteLine($"a/b: {a / b}");  // output: 10 / 4

            //========================================================
            // precendence test
            //https://stackoverflow.com/questions/12945142/operator-overloading-and-precedence
            var d = b * c;
            Console.WriteLine($"b * c: {d}"); 
            Console.WriteLine($"a + b * c: {a + d}");
            Console.WriteLine($"a + b * c: {a + b * c}"); 

            //========================================================
            // extension methods and operator overloading
            Console.WriteLine($"2^3: {Math.Pow(2,3)}");
            Console.WriteLine($"2^3: {(2.0).power(3)}");

            //========================================================
            // var o = new Point(0,0);
            var p1 = new Point(3, 4);
            var p2 = new Point(4, 3);
            Console.WriteLine($"Point p1: {p1}, p2: {p2}");
            Console.WriteLine($"p1+p2: {p1+p2}");

            //========================================================
            // Is operator overloading used a lot in C#
            //https://stackoverflow.com/questions/43548897/is-overloading-operators-in-c-sharp-actually-good-practice


            //========================================================
            // guidelines
            // c++ :: https://docs.microsoft.com/en-us/cpp/cpp/general-rules-for-operator-overloading?view=msvc-160
            // https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/operator-overloads
        
            //========================================================
            // design discussions
            // https://softwareengineering.stackexchange.com/questions/136519/examples-of-operator-overloading-which-make-sense/136606
        
            // == ???
            // https://accu.org/conf-docs/PDFs_2011/Steve-Love-Roger-Orr-equals.pdf

            //========================================================
            // BigInteger
            // https://visualstudiomagazine.com/articles/2011/01/25/biginteger.aspx
            // https://github.com/microsoft/referencesource/tree/master/System.Numerics/System/Numerics
            // Complex
            // https://github.com/microsoft/referencesource/blob/master/System.Numerics/System/Numerics/Complex.cs
            
            SmartCalculator.RunDiagnostics();

            //========================================================
            Console.WriteLine($"1,2,3,4 mean is : {Adder.Mean_IntDiv(1,2,3,4)}");
            Console.WriteLine($"1,2,3,4 mean is : {Adder.Mean_FloatDiv(1,2,3,4)}");
            Console.WriteLine($"1.1,2.1,3.1,4.1 mean is : {Adder.Mean_Doubles(1.1,2.1,3.1,4.1)}");

            // double d2 = 2.0;
            // int i2 = d2; 
            Console.WriteLine($"1.1,2.1,3.1,4.1 mean is : {Adder.Mean_Foreach(1.1,2.1,3.1,4.1)}");
        }
    }

}

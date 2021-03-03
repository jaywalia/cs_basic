using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

// ildasm :
// https://github.com/pjbgf/dotnet-ildasm
// dotnet tool install -g dotnet-ildasm
// export PATH="$PATH:/root/.dotnet/tools"
// dotnet ildasm Step04.dll -o Step04.il

// http://www.albahari.com/valuevsreftypes.aspx
namespace Step04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Value vs Reference");
            RunTests();
        }

        static sVector Add(sVector v1, sVector v2)
            => new sVector(v1.X + v2.X, v1.Y + v2.Y );
        
        static void RunTests()
        {
            RunTests_Struct();
            RunTests_Class();
            RunTests_Tuples();

            RunTests_ArrayList();
            RunTests_GenericList();

            RunTests_GenericMethod();
        }

        static void RunTests_Struct()
        {
            Console.WriteLine("---------Value-------------");
            Stopwatch w = new Stopwatch();

            sVector v1 = new sVector(1,1);
            sVector v2 = new sVector(2,2);

            w.Start();
            // sVector v3 = Add(v1,v2);
            sVector v3 = v1 + v2;
            
            w.Stop();
            Console.WriteLine($"Time elapsed = {w.ElapsedTicks} ticks");
            Console.WriteLine($"{v1} + {v2} = {v3}");

            // copy by value, different objects
            var v4 = v3;
            Console.WriteLine($"v3 & v4 are same: {Object.ReferenceEquals(v3,v4)}");
            v4.X = 5;
            Console.WriteLine($"Modified v4. {v3} != {v4}");

            // hash codes - dictionary - maybe internally for gc
            Console.WriteLine($"Hashcodes : v1:{v1.GetHashCode()}, v2: {v2.GetHashCode()},"+
                                        $"v3:{v3.GetHashCode()}, v4: {v4.GetHashCode()}");
        }

        static void RunTests_Class()
        {
            Console.WriteLine("---------Reference-------------");
            Stopwatch w = new Stopwatch();

            var v1 = new cVector(1,1);
            var v2 = new cVector(2,2);

            w.Start();
            // sVector v3 = Add(v1,v2);
            var v3 = v1 + v2;
            
            w.Stop();
            Console.WriteLine($"Time elapsed = {w.ElapsedTicks} ticks");
            Console.WriteLine($"{v1} + {v2} = {v3}");

            // copy by reference, same object
            var v4 = v3;
            Console.WriteLine($"v3 & v4 are same: {Object.ReferenceEquals(v3,v4)}");
            v4.X = 5;
            Console.WriteLine($"Modified v4. {v3} == {v4}");

            // hash codes - dictionary - maybe internally for gc
            Console.WriteLine($"Hashcodes : v1:{v1.GetHashCode()}, v2: {v2.GetHashCode()},"+
                                        $"v3:{v3.GetHashCode()}, v4: {v4.GetHashCode()}");
        }

        public static void RunTests_ArrayList()
        {
            Console.WriteLine("---------Array List-------------");
            // add a value vector object to an array list 100 times
            ArrayList l = new ArrayList();
            for(int i = 0; i < 100; i++)
            {
                var sV = new sVector(1,1);
                l.Add(sV);
            }
        }

        public static void RunTests_GenericList()
        {
            Console.WriteLine("---------Generic List-------------");
            // add a value vector object to a generice list
            // List<sVector> l = new List<sVector>();
            var l = new List<sVector>();
            for(int i = 0; i < 100; i++)
            {
                var sV = new sVector(1,1);
                l.Add(sV);
            }
        }

        public static void RunTests_GenericMethod()
        {
            Console.WriteLine("---------Generic Methods-------------");
            Console.WriteLine($"max : {Max(new int[]{1,2,3,4})}");
            Console.WriteLine($"max : {Max(new float[]{1.0F,2.0F,3.0F,4.0F})}");
            // how to find max double
            Console.WriteLine($"max : {Max<double>(new double[]{1.0,2.0,3.0,4.0})}");
            // how to find max vector
            Console.WriteLine($"max : {Max<cVector>(new cVector[]{ new cVector(1,1), new cVector(2,2) })}");
        }

        public static int Max(int[] numbers)
        {
            if( numbers.Length == 0 ) throw new ArgumentException("Empty nummbers list!");
            int max = numbers[0];
            for(int i = 1; i < numbers.Length; i++)
            {
                if(max < numbers[i]) max = numbers[i];
            }
            return max;
        }

        public static float Max(float[] numbers)
        {
            if( numbers.Length == 0 ) throw new ArgumentException("Empty nummbers list!");
            float max = numbers[0];
            for(int i = 1; i < numbers.Length; i++)
            {
                if(max < numbers[i]) max = numbers[i];
            }
            return max;
        }

        public static T Max<T>(T[] numbers) where T : IComparable
        {
            if( numbers.Length == 0 ) throw new ArgumentException("Empty nummbers list!");
            T max = numbers[0];
            for(int i = 1; i < numbers.Length; i++)
            {
                if( max.CompareTo(numbers[i]) < 0 ) max = numbers[i];
            }
            return max;
        }

        // public static void RunTests_AddToList(var list)
        // {

        // }

        public static void RunTests_Tuples()
        {
            Console.WriteLine("---------Tuples-------------");
            (double, int) tup1 = (4.5, 3);
            Console.WriteLine($"({tup1.Item1} , {tup1.Item2})");
            (double mean, int count) stats = GetStats(1, 2, 3, 4, 5);
            Console.WriteLine($"mean: {stats.mean} , count: {stats.count}");
        }

        public static 
        (double mean, int count) GetStats(params int[] numbers)
        {
            double mean = 0;
            foreach(int n in numbers) mean += n;
            int count = numbers.Length;
            mean /= count;
            return (mean, count);
        }

        
    }

    // structs should be immutable
    // passed by value
    // https://softwareengineering.stackexchange.com/questions/92339/when-do-you-use-a-struct-instead-of-a-class
    struct sVector
    {
        public int X ;//{get; private set;}
        public int Y ;//{get; private set;}

        public sVector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static sVector operator +(sVector v1, sVector v2)
            => new sVector(v1.X + v2.X, v1.Y + v2.Y);

        public override string ToString() 
            => $"<{X},{Y}>";
        
        //public override int GetHashCode() => X * 10 + Y;
    }

    class cVector : IComparable
    {
        public int X;
        public int Y;

        public cVector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static cVector operator +(cVector v1, cVector v2)
            => new cVector(v1.X + v2.X, v1.Y + v2.Y);

        public override string ToString() 
            => $"<{X},{Y}>";

        public double Magnitude => Math.Sqrt(X*X+Y*Y);

        public int CompareTo(object obj) 
        {
            if (obj == null) return 1;

            cVector v2 = obj as cVector;
            if (v2 != null)
                return this.Magnitude.CompareTo(v2.Magnitude);
            else
                throw new ArgumentException("Object is not a cVector");
        }
        
    }
}

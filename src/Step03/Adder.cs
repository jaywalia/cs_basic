using System;

namespace Step03
{
    public class Adder
    {
        // integer division
        public static int Mean_IntDiv(params int[] numbers)
        {
            int m = 0;
            foreach(int n in numbers) m +=n ;
            return m/numbers.Length;
        }

        public static float Mean_FloatDiv(params int[] numbers)
        {
            float m = 0;
            foreach(int n in numbers) m += n;
            return m/numbers.Length;
        }

        public static double Mean_Doubles(params double[] numbers)
        {
            double m = 0;
            foreach(double n in numbers) m += n;
            // Console.WriteLine($"{m}/{numbers.Length}");
            return m/numbers.Length;
        }

        // foreach : implicit casting : quietly converts
        // https://ericlippert.com/2013/07/22/why-does-a-foreach-loop-silently-insert-an-explicit-conversion/#more-1315
        public static double Mean_Foreach(params double[] numbers)
        {
            double m = 0;
            foreach(int n in numbers) m += n;
            // Console.WriteLine($"{m}/{numbers.Length}");
            return m/numbers.Length;
        }

        // following doesn't exist yet
        // public static T Mean<T>(params T[] numbers) where T : int,double,...
        // {
        //     T m;
        //     foreach(T n in numbers) m += n;
        //     return m/numbers.Length;
        // }
    }
}